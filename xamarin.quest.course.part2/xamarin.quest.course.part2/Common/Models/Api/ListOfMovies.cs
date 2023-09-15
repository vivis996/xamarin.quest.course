using Newtonsoft.Json;
using System.Collections.Generic;

namespace xamarin.quest.course.part2.Common.Models.Api
{
    public class ListOfMovies
    {
        [JsonProperty("Search")]
        public List<BaseMovieInformation> Search { get; set; }

        [JsonProperty("totalResults")]
        public string TotalResults { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }
    }
}
