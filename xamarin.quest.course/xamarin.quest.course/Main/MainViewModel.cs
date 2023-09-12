using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.Dialog;
using Xamarin.Forms;

namespace xamarin.quest.course.Main
{
    public class MainViewModel
    {
        private readonly IDialogMessage _dialogMessage;

        public MainViewModel(IDialogMessage dialogMessage)
        {
            this._dialogMessage = dialogMessage;
        }

        public ICommand DisplayAlertCommand => new Command(async () => await ShowAlert());

        private async Task ShowAlert()
        {
            await this._dialogMessage.DisplayAlert("Hello", "Hello there!", "Ok");
        }
    }
}
