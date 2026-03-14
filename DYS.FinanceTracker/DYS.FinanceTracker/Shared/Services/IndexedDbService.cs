

using Blazor.IndexedDB;
using DYS.FinanceTracker.Shared.Models;

namespace DYS.FinanceTracker.Shared.Services
{

    public class IndexedDbHelper<TEntity> where TEntity : class, new()
    {
        private readonly IIndexedDbFactory _factory;

        public IndexedDbHelper(IIndexedDbFactory factory)
        {
            _factory = factory;
        }

        private async Task<(TDb db, IndexedSet<TEntity> set)> GetDbSetAsync<TDb>(Func<TDb, IndexedSet<TEntity>> setSelector)
            where TDb : IndexedDb
        {
            var db = await _factory.Create<TDb>();
            var set = setSelector(db);
            return (db, set);
        }

        // Save (Add)
        public async Task SaveAsync<TDb>(Func<TDb, IndexedSet<TEntity>> setSelector, TEntity record)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);
            set.Add(record);
            await db.SaveChanges();
        }

        public async Task SaveAsync<TDb>(
            Func<TDb, IndexedSet<TEntity>> setSelector,
            IEnumerable<TEntity> records)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);

            foreach (var record in records)
            {
                set.Add(record);
            }

            await db.SaveChanges();
        }

        // Edit (Update)
        public async Task EditAsync<TDb>(Func<TDb, IndexedSet<TEntity>> setSelector, TEntity record)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);

            var keyProp = typeof(TEntity).GetProperty("Id");
            if (keyProp == null) throw new InvalidOperationException("Entity must have an Id property");

            var idValue = keyProp.GetValue(record);
            var existing = set.SingleOrDefault(e => keyProp.GetValue(e)?.Equals(idValue) == true);

            if (existing != null)
            {
                foreach (var prop in typeof(TEntity).GetProperties())
                {
                    prop.SetValue(existing, prop.GetValue(record));
                }
                await db.SaveChanges();
            }
        }

        // Delete
        public async Task DeleteAsync<TDb>(Func<TDb, IndexedSet<TEntity>> setSelector, TEntity record)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);
            set.Remove(record);
            await db.SaveChanges();
        }

        public async Task DeleteAllAsync<TDb>(
            Func<TDb, IndexedSet<TEntity>> setSelector)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);

            // Clear all records in the set
            set.Clear();

            await db.SaveChanges();
        }


        // Get by Id
        public async Task<TEntity?> GetByIdAsync<TDb>(Func<TDb, IndexedSet<TEntity>> setSelector, object id)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);
            var keyProp = typeof(TEntity).GetProperty("Id");
            return set.SingleOrDefault(e => keyProp.GetValue(e)?.Equals(id) == true);
        }

        // Get all
        public async Task<List<TEntity>> GetAllAsync<TDb>(Func<TDb, IndexedSet<TEntity>> setSelector)
            where TDb : IndexedDb
        {
            var (db, set) = await GetDbSetAsync(setSelector);
            return set.ToList();
        }
    }
}
