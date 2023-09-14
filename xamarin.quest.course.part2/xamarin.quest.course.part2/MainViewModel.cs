using System.Collections.ObjectModel;
using System.Linq;
using xamarin.quest.course.part2.Models;
using xamarin.quest.course.part2.Models.Api;
using Xamarin.Forms;

namespace xamarin.quest.course.part2
{
    public class MainViewModel : BindableObject
    {
        private INetworkService _networkService;

        public ObservableCollection<MovieData> Items { get; set; }

        public MainViewModel(INetworkService networkService)
        {
            this._networkService = networkService;
            this.GetMovieData();
        }

        private async void GetMovieData()
        {
            var uri = Constants.GetMoviesUri("avengers");
            var result = await this._networkService.GetAsync<RootObject>(uri);
            var movieData = result.Search.Select(s => new MovieData(s.Title, s.Poster.Replace("SX300", "SX600")));
            this.Items = new ObservableCollection<MovieData>(movieData);
            this.OnPropertyChanged(nameof(this.Items));
        }
    }
}
