using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin.quest.course.Dialog
{
    public class DialogMessage : IDialogMessage
    {
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }
    }
}
