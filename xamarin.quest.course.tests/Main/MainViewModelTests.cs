using Moq;
using xamarin.quest.course.Dialog;
using xamarin.quest.course.Main;

namespace xamarin.quest.course.tests.Main
{
    public class MainViewModelTests
    {
        [Fact]
        public void DisplayAlertCommand_WhenCalled_DisplaysAlert()
        {
            var dialogMessage = new Mock<IDialogMessage>();
            dialogMessage.Setup(x => x.DisplayAlert("a", "b", "c"))
                         .Returns(Task.CompletedTask);
            var viewModel = new MainViewModel(dialogMessage.Object);

            viewModel.DisplayAlertCommand.Execute(null);

            dialogMessage.Verify(x => x.DisplayAlert("a", "b", "c"), Times.Once);
        }
    }
}
