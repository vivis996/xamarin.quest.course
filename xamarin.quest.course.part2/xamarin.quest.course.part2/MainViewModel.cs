using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace xamarin.quest.course.part2
{
    public class MainViewModel : BindableObject
    {
        public ObservableCollection<string> Items => new ObservableCollection<string>
        {
            "Avengers",
            "Avengers Age of Ultron",
            "Avengers Inifity Wars",
        };

        public MainViewModel()
        {
            this.OnPropertyChanged(nameof(this.Items));
        }
    }
}
