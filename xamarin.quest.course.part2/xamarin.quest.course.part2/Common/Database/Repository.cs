using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;
using xamarin.quest.course.part2.Common.Extensions;

namespace xamarin.quest.course.part2.Common.Database
{
    public class Repository<T> : IRepository<T> where T : IDataBaseItem, new()
    {
        readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);
        });

        private SQLiteAsyncConnection Database => lazyInitializer.Value;

        public Repository()
        {
            this.InitializeAsync().SafeFireAndForget(false);
        }

        private async Task InitializeAsync()
        {
            if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(T).Name))
            {
                await Database.CreateTableAsync(typeof(T)).ConfigureAwait(false);
            }
        }

        public async Task<T> GetById(int id)
        {
            return await Database.Table<T>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> DeleteAsync(T item)
        {
            return await Database.DeleteAsync(item);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Database.Table<T>().ToListAsync();
        }

        public async Task<int> SaveAsync(T item)
        {
            if (item.Id == 0)
            {
                return await Database.InsertAsync(item);
            }
            else
            {
                return await Database.UpdateAsync(item);
            }
        }
    }
}
