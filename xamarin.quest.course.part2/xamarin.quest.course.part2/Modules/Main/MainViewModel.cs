using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.part2.Common.Base;
using xamarin.quest.course.part2.Common.Database;
using xamarin.quest.course.part2.Common.Models;
using xamarin.quest.course.part2.Common.Models.Api;
using xamarin.quest.course.part2.Common.Navigation;
using xamarin.quest.course.part2.Common.Network;
using xamarin.quest.course.part2.Modules.MovieDetails;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace xamarin.quest.course.part2.Modules.Main
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private readonly INetworkService _networkService;
        private readonly INavigationService _navigationService;
        private readonly IRepository<FullMovieInformation> _movieInformationRepository;

        public ObservableCollection<MovieData> Items { get; set; }

        private MovieData _selectedMovie;
        public MovieData SelectedMovie
        {
            get => this._selectedMovie;
            set => this.SetProperty(ref this._selectedMovie, value);
        }

        public string SearchTerm { get; set; }

        private string _selectedMovieId;
        public string SelectedMovieId
        {
            get => this._selectedMovieId;
            set => this.SetProperty(ref this._selectedMovieId, value);
        }
        #endregion

        public MainViewModel(INetworkService networkService,
                             INavigationService navigationService,
                                     IRepository<FullMovieInformation> movieInformationRepository)
        {
            this._networkService = networkService;
            this._navigationService = navigationService;
            this._movieInformationRepository = movieInformationRepository;
        }

        public ICommand PlatformSearchCommand => new Command(async () => await this.GetMovieData());
        public ICommand MovieChangedCommand => new Command(async () => await this.GoToMovieDetails());

        private async Task GoToMovieDetails()
        {
            if (this.SelectedMovie == null)
                return;

            this.SelectedMovieId = this.SelectedMovie.ImdbID;

            await this._navigationService.PushAsync<MovieDetailsViewModel>(this.SelectedMovie);
            this.SelectedMovie = null;
        }

        private async Task GetMovieData()
        {
            var uri = ApiConstants.GetMoviesUri(this.SearchTerm?.Trim());
            var result = (await this._networkService.GetAsync<ListOfMovies>(uri))?.Search;
            if ((bool)!result?.Any())
                return;

            var movieData = result
                                  //Eliminate duplicate movies
                                  .GroupBy(x => new { x.Title, x.Year })
                                  .Select(x => x.First())
                                  //Sort by year descending
                                  .OrderByDescending(x => x.Year)
                                  .Select(s => new MovieData(s.Title, s.Poster.Replace("SX300", "SX600"),
                                                             s.Year, s.ImdbID))
                                  .ToList();

            var fullMovies = (await this._movieInformationRepository
                                .GetAllAsync()).Where(f =>
                                     movieData.Any(s => s.ImdbID == f.ImdbID));

            movieData.ForEach(m => m.Information = fullMovies
                                            .FirstOrDefault(f => f.ImdbID == m.ImdbID) ??
                                            new FullMovieInformation());

            this.Items = new ObservableCollection<MovieData>(movieData);
            this.OnPropertyChanged(nameof(this.Items));
        }

        public ICommand FavoriteCommand => new Command<MovieData>(async (movie) => await this.SetMovieFavorite(movie));

        private async Task SetMovieFavorite(MovieData value)
        {
            var movieData = value as MovieData;

            if (movieData.Information.Id == 0)
            {
                var uri = ApiConstants.GetMoviesByIdUri(movieData.ImdbID);
                movieData.Information = await this._networkService.GetAsync<FullMovieInformation>(uri);
            }
            movieData.Information.IsFavorite = !movieData.Information.IsFavorite;
            await this._movieInformationRepository.SaveAsync(movieData.Information);
        }
    }
}
