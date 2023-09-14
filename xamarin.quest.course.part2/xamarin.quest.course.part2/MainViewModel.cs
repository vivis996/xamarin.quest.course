using System.Collections.ObjectModel;
using System.Linq;
using xamarin.quest.course.part2.Models;
using Xamarin.Forms;

namespace xamarin.quest.course.part2
{
    public class MainViewModel : BindableObject
    {
        private INetworkService _networkService;

        public ObservableCollection<string> Items { get; set; }

        public MainViewModel(INetworkService networkService)
        {
            this._networkService = networkService;
            this.GetMovieData();
        }

        private async void GetMovieData()
        {
            var uri = Constants.GetMoviesUri("avengers");
            var result = await this._networkService.GetAsync<RootObject>(uri);
            this.Items = new ObservableCollection<string>(result.Search.Select(s => s.Title));
            this.OnPropertyChanged(nameof(this.Items));
        }
    }
}
