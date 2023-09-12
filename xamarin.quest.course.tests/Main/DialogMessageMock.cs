using xamarin.quest.course.Dialog;

namespace xamarin.quest.course.tests.Main
{
    public class DialogMessageMock : IDialogMessage
    {
        public int DisplayAlertCallCount { get; set; }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            this.DisplayAlertCallCount++;
            await Task.CompletedTask;
        }
    }
}
