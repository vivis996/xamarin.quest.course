using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace xamarin.quest.course.part2
{
    public class NetworkService : INetworkService
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

        public async Task<TResult> PostAsync<TResult>(string uri, string jsonData)
        {
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await this._httpClient.PostAsync(uri, content);

            var serialized = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serialized);
            return result;
        }

        public async Task<TResult> PutAsync<TResult>(string uri, string jsonData)
        {
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await this._httpClient.PutAsync(uri, content);

            var serialized = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResult>(serialized);

            return result;
        }

        public async Task DeleteAsync(string uri)
        {
            await this._httpClient.DeleteAsync(uri);
        }
    }
}
