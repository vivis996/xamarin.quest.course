namespace xamarin.quest.course.part2.Common.Network
{
	public static class ApiConstants
    {
		public const string ApiKey = "786e0536";

		public static string GetMoviesUri(string searchTerm, int page = 1)
		{
			return $"https://www.omdbapi.com/?apikey={ApiKey}&s={searchTerm}&page={page}";
        }

        public static string GetMoviesByIdUri(string imdbId)
        {
            return $"https://www.omdbapi.com/?apikey={ApiKey}&i={imdbId}&plot=full";
        }
    }
}
