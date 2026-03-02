using Supabase.Postgrest;
using Supabase.Postgrest.Attributes;

namespace DYS.FinanceTracker.Shared.Data
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


}
