using System.Threading.Tasks;

namespace xamarin.quest.course.Dialog
{
    public interface IDialogMessage
    {
        Task DisplayAlert(string title, string message, string cancel);
        Task<string> DisplayPrompt(string title, string message);
        Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons);
    }
}
