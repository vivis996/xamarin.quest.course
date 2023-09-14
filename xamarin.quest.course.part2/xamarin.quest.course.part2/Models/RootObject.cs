using Newtonsoft.Json;
using System.Collections.Generic;

namespace xamarin.quest.course.part2.Models
{
    public class RootObject
    {
        [JsonProperty("Search")]
        public List<Search> Search { get; set; }

        [JsonProperty("totalResults")]
        public string TotalResults { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }
    }
}
