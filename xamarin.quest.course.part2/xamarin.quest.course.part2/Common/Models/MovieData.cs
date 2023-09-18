using xamarin.quest.course.part2.Common.Models.Api;

namespace xamarin.quest.course.part2.Common.Models
{
    public class MovieData
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }

        public FullMovieInformation Information { get; set; }

        public MovieData(string title, string imageUrl, string year, string imdbID)
        {
            this.Title = title;
            this.ImageUrl = imageUrl;
            this.Year = year;
            this.ImdbID = imdbID;
        }
    }
}
