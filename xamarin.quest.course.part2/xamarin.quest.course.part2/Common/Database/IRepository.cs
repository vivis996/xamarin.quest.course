using System.Collections.Generic;
using System.Threading.Tasks;

namespace xamarin.quest.course.part2.Common.Database
{
    public interface IRepository<T> where T : IDataBaseItem, new()
    {
        Task<T> GetById(int id);
        Task<int> DeleteAsync(T item);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T item);
    }
}
