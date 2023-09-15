using System.Threading.Tasks;
using xamarin.quest.course.part2.Common.Base;
using xamarin.quest.course.part2.Common.Models;
using xamarin.quest.course.part2.Common.Models.Api;
using xamarin.quest.course.part2.Common.Navigation;
using xamarin.quest.course.part2.Common.Network;

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

        public MovieDetailsViewModel(INavigationService navigationService, INetworkService networkService)
        {
            this._navigationService = navigationService;
            this._networkService = networkService;
        }

        public override async Task InitializeAsync(object parameter)
        {
            this.MovieData = parameter as MovieData;
            var uri = ApiConstants.GetMoviesByIdUri(this.MovieData.ImdbID);
            this.MovieInformation = await this._networkService.GetAsync<FullMovieInformation>(uri);
        }
    }
}
