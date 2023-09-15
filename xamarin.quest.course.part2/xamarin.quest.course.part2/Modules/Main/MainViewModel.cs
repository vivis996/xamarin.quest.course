using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.part2.Common.Base;
using xamarin.quest.course.part2.Common.Models;
using xamarin.quest.course.part2.Common.Models.Api;
using xamarin.quest.course.part2.Common.Navigation;
using xamarin.quest.course.part2.Common.Network;
using xamarin.quest.course.part2.Modules.MovieDetails;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.Main
{
    public class MainViewModel : BaseViewModel
    {
        private readonly INetworkService _networkService;
        private readonly INavigationService _navigationService;

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

        public MainViewModel(INetworkService networkService,
                             INavigationService navigationService)
        {
            this._networkService = networkService;
            this._navigationService = navigationService;
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
            var result = await this._networkService.GetAsync<ListOfMovies>(uri);
            if ((bool)!result?.Search?.Any())
                return;
            var movieData = result.Search
                                  //Eliminate duplicate movies
                                  .GroupBy(x => new { x.Title, x.Year })
                                  .Select(x => x.First())
                                  //Sort by year descending
                                  .OrderByDescending(x => x.Year)
                                  .Select(s => new MovieData(s.Title, s.Poster.Replace("SX300", "SX600"),
                                                             s.Year, s.ImdbID));
            this.Items = new ObservableCollection<MovieData>(movieData);
            this.OnPropertyChanged(nameof(this.Items));
        }
    }
}
