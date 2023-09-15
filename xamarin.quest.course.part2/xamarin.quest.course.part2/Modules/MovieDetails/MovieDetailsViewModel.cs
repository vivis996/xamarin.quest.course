using System;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.part2.Common.Base;
using xamarin.quest.course.part2.Common.Models;
using xamarin.quest.course.part2.Common.Models.Api;
using xamarin.quest.course.part2.Common.Navigation;
using xamarin.quest.course.part2.Common.Network;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.MovieDetails
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly INetworkService _networkService;

        private MovieData _movieData;

        public MovieData MovieData
        {
            get => this._movieData;
            set => this.SetProperty(ref this._movieData, value);
        }

        private FullMovieInformation _movieInformation;
        public FullMovieInformation MovieInformation
        {
            get => this._movieInformation;
            set => this.SetProperty(ref this._movieInformation, value);
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get => this._isFavorite;
            set => this.SetProperty(ref this._isFavorite, value);
        }

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService)
        {
            this._navigationService = navigationService;
            this._networkService = networkService;
        }

        public ICommand GoBackCommand => new Command(async () => await this.GoBack());
        public ICommand FavoriteCommand => new Command(async () => await this.SetMovieFavorite());

        private Task SetMovieFavorite()
        {
            this.IsFavorite = !this.IsFavorite;
            return Task.CompletedTask;
        }

        private async Task GoBack()
        {
            await this._navigationService.PopAsync();
        }

        public override async Task InitializeAsync(object parameter)
        {
            this.MovieData = parameter as MovieData;
            var uri = ApiConstants.GetMoviesByIdUri(this.MovieData.ImdbID);
            this.MovieInformation = await this._networkService.GetAsync<FullMovieInformation>(uri);
        }
    }
}
