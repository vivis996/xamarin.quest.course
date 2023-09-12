using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.quest.course.Main
{
    public class MainViewModel
    {
        public ICommand DisplayAlertCommand => new Command(async () => await ShowAlert());

        private async Task ShowAlert()
        {
            // Don't do this!
            await Application.Current.MainPage.DisplayAlert("Hello", "Hello there!", "Ok");
        }
    }
}
