using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.part2.Common.Base;
using xamarin.quest.course.part2.Common.Database;
using xamarin.quest.course.part2.Common.Models;
using xamarin.quest.course.part2.Common.Models.Api;
using xamarin.quest.course.part2.Common.Navigation;
using xamarin.quest.course.part2.Common.Network;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.MovieDetails
{
    public class MovieDetailsViewModel : BaseViewModel
    {
        #region Properties

        private readonly INavigationService _navigationService;
        private readonly INetworkService _networkService;
        private readonly IRepository<FullMovieInformation> _movieInformationRepository;

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
        #endregion

        public MovieDetailsViewModel(INavigationService navigationService,
                                     INetworkService networkService,
                                     IRepository<FullMovieInformation> movieInformationRepository)
        {
            this._navigationService = navigationService;
            this._networkService = networkService;
            this._movieInformationRepository = movieInformationRepository;
        }

        public ICommand GoBackCommand => new Command(async () => await this.GoBack());
        public ICommand FavoriteCommand => new Command(async () => await this.SetMovieFavorite());

        private async Task SetMovieFavorite()
        {
            this.IsFavorite = !this.IsFavorite;
            this.MovieInformation.IsFavorite = this.IsFavorite;
            await this._movieInformationRepository.SaveAsync(this.MovieInformation);
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
            var dbInfo = (await this._movieInformationRepository.GetAllAsync())
                            .FirstOrDefault(x => x.ImdbID == this.MovieInformation.ImdbID);
            if (dbInfo != null)
            {
                this.MovieInformation = dbInfo;
                this.IsFavorite = this.MovieInformation.IsFavorite;
            }
        }
    }
}
