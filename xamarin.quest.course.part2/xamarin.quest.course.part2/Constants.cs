namespace xamarin.quest.course.part2
{
	public static class Constants
	{
		public const string ApiKey = "786e0536";

		public static string GetMoviesUri(string searchTerm, int page = 1)
		{
			return $"https://www.omdbapi.com/?apikey={ApiKey}&s={searchTerm}&page={page}";
        }
    }
}
