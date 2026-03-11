

using Supabase.Postgrest.Models;
using Supabase.Postgrest;
using Supabase.Postgrest.Attributes;


namespace DYS.FinanceTracker.Shared.Services
{
    public interface ISupabaseService<T> where T : IHasId
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(List<(string Column, Constants.Operator Operator, object Value)> filters = null);
        Task<List<T>> GetPagedAsync(int page, int pageSize);
        Task<List<T>> GetFilteredAsync(Func<T, bool> predicate);
        Task<T> GetAsync(Func<T, bool> predicate);
        Task<T?> InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }

    public interface IHasId
    {
        [Column("id")]
        Guid Id { get; set; }

        [Column("user_id")]
        Guid? UserId { get; set; }
    }

    public class SupabaseService<T> : ISupabaseService<T> where T : BaseModel, IHasId, new()
    {
        private readonly Supabase.Client _client;

        public SupabaseService(Supabase.Client client)
        {
            _client = client;
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                var result = await _client.From<T>().Get();
                return result.Models;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        /// <summary>
        /// Get all records with optional filters.
        /// </summary>
        /// <param name="filters">List of filters: column, operator, value</param>
        public async Task<List<T>> GetAllAsync(List<(string Column, Constants.Operator Operator, object Value)> filters = null)
        {
            try
            {
                var query = _client.From<T>();

                if (filters != null)
                {
                    foreach (var (column, op, value) in filters)
                    {
                        var stringValue = value switch
                        {
                            Guid g => g.ToString(),
                            int i => i.ToString(),
                            float f => f.ToString(),
                            bool b => b.ToString().ToLower(),
                            DateTime dt => dt.ToString("o"), // ISO 8601 format
                            string s => s,
                            _ => value.ToString()
                        };
                        query = (Supabase.Interfaces.ISupabaseTable<T, Supabase.Realtime.RealtimeChannel>)query.Filter(column, op, stringValue);
                    }
                }

                var result = await query.Get();
                return result.Models;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //public async Task<(List<T> Items, int TotalCount)> GetAllAsync(
        //List<(string Column, Constants.Operator Operator, object Value)> filters = null,
        //int page = 1,
        //int pageSize = 20)
        //{
        //    try
        //    {
        //        var query = _client.From<T>();

        //        // Apply filters if provided
        //        if (filters != null)
        //        {
        //            foreach (var (column, op, value) in filters)
        //            {
        //                var stringValue = value switch
        //                {
        //                    Guid g => g.ToString(),
        //                    int i => i.ToString(),
        //                    float f => f.ToString(),
        //                    bool b => b.ToString().ToLower(),
        //                    DateTime dt => dt.ToString("o"), // ISO 8601 format
        //                    string s => s,
        //                    _ => value.ToString()
        //                };

        //                query = (Supabase.Interfaces.ISupabaseTable<T, Supabase.Realtime.RealtimeChannel>)
        //                    query.Filter(column, op, stringValue);
        //            }
        //        }

        //        // Paging logic
        //        int from = (page - 1) * pageSize;
        //        int to = from + pageSize - 1;

        //        query = (Supabase.Interfaces.ISupabaseTable<T, Supabase.Realtime.RealtimeChannel>)query.Range(from, to);

        //        // Request total count along with results
        //        // Correct way: request count
        //        var result = await query.Count();

        //        return (result.Models, result.Count ?? 0);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public async Task<T?> InsertAsync(T entity)
        {
            var output = await _client.From<T>().Insert(entity);
            return output.Model;
        }
        public async Task UpdateAsync(T entity)
        {
            try
            {
                if (entity.Id == Guid.Empty)
                    throw new ArgumentException("Entity must have a valid Id to update.");

                var response = await _client
                               .From<T>()
                               .Where(x => x.Id == entity.Id && x.UserId == entity.UserId)
                               .Update(entity);

                if (response.Models.Count == 0)
                    throw new InvalidOperationException("No rows updated. Check Id or RLS policies.");
            }
            catch (Exception ex)
            {
                var test = ex.InnerException;
                throw;
            }
            
        }


        public async Task DeleteAsync(Guid id)
        {
            await _client.From<T>().Where(x => x.Id == id).Delete();
        }

        public async Task<List<T>> GetFilteredAsync(Func<T, bool> predicate)
        {
            var result = await _client.From<T>().Get();
            return result.Models.Where(predicate).ToList();
        }

        public async Task<T> GetAsync(Func<T, bool> predicate)
        {
            var result = await _client.From<T>().Get();
            return result.Models.Where(predicate)?.FirstOrDefault();
        }

        public async Task<List<T>> GetPagedAsync(int page, int pageSize)
        {
            var result = await _client.From<T>()
                .Range((page - 1) * pageSize, page * pageSize - 1)
                .Get();
            return result.Models;
        }

        public async Task<(List<T> Items, int TotalCount)> GetPagedAsync(
            int page,
            int pageSize,
            Dictionary<string, object> filters = null)
        {
            var query = _client.From<T>();

            // Apply filters if any
            if (filters != null)
            {
                foreach (var filter in filters)
                    query.Filter(filter.Key,
                        Supabase.Postgrest.Constants.Operator.ILike, $"%{filter.Value}%");
            }

            var response = await query
                             .Range((page - 1) * pageSize, page * pageSize - 1)
                             .Get();

            var result = response.Models;
            return (result, result.Count());
        }

        private string FormatValue(object value) => value switch
        {
            Guid g => g.ToString(),
            int i => i.ToString(),
            float f => f.ToString(),
            bool b => b.ToString().ToLower(),
            DateTime dt => dt.ToString("yyyy-MM-dd"), // Use simple date format, not ISO 8601 for date columns
            string s => s,
            _ => value.ToString()
        };
    }

}
