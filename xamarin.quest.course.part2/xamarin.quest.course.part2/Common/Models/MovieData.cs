namespace xamarin.quest.course.part2.Common.Models
{
    public class MovieData
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }


        public MovieData(string title, string imageUrl)
        {
            this.Title = title;
            this.ImageUrl = imageUrl;
        }
    }
}
