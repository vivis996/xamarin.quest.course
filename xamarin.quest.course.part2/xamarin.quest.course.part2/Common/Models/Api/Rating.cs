using Newtonsoft.Json;

namespace xamarin.quest.course.part2.Common.Models.Api
{
    public class Rating
    {
        [JsonProperty("Source")]
        public string Source { get; set; }

        [JsonProperty("Value")]
        public string Value { get; set; }
    }
}
