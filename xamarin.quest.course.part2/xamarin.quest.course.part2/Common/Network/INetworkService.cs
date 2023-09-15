using System.Threading.Tasks;

namespace xamarin.quest.course.part2.Common.Network
{
    public interface INetworkService
    {
        Task<TResult> GetAsync<TResult>(string uri);
        Task<TResult> PostAsync<TResult>(string uri, string jsonData);
        Task<TResult> PutAsync<TResult>(string uri, string jsonData);
        Task DeleteAsync(string uri);
    }
}
