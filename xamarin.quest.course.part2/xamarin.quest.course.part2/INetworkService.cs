using System.Threading.Tasks;

namespace xamarin.quest.course.part2
{
    public interface INetworkService
    {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
