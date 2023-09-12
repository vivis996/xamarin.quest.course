using System.Threading.Tasks;

namespace xamarin.quest.course.Dialog
{
    public interface IDialogMessage
	{
		Task DisplayAlert(string title, string message, string cancel);
	}
}
