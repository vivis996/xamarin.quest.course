﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.part2.Models;
using xamarin.quest.course.part2.Models.Api;
using Xamarin.Forms;

namespace xamarin.quest.course.part2
{
    public class MainViewModel : BindableObject
    {
        private INetworkService _networkService;

        public ObservableCollection<MovieData> Items { get; set; }

        public string SearchTerm { get; set; }

        public MainViewModel(INetworkService networkService)
        {
            this._networkService = networkService;
        }

        public ICommand PlatformSearchCommand => new Command(async () => await this.GetMovieData());

        private async Task GetMovieData()
        {
            var uri = Constants.GetMoviesUri(this.SearchTerm?.Trim());
            var result = await this._networkService.GetAsync<RootObject>(uri);
            if ((bool)!result?.Search?.Any())
                return;
            var movieData = result.Search
                                  //Eliminate duplicate movies
                                  .GroupBy(x => new { x.Title, x.Year })
                                  .Select(x => x.First())
                                  //Sort by year descending
                                  .OrderByDescending(x => x.Year)
                                  .Select(s => new MovieData(s.Title, s.Poster.Replace("SX300", "SX600")));
            this.Items = new ObservableCollection<MovieData>(movieData);
            this.OnPropertyChanged(nameof(this.Items));
        }
    }
}
