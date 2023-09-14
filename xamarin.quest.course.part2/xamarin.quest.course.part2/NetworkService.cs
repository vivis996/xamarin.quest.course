using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace xamarin.quest.course.part2
{
    public class NetworkService
    {
        private HttpClient _httpClient;

        public NetworkService()
        {
            this._httpClient = new HttpClient();
        }

        public async Task<TResult> GetAsync<TResult>(string uri)
        {
            var response = await this._httpClient.GetAsync(uri);
            var serialized = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serialized);
            return result;
        }
    }
}
