using xamarin.quest.course.Main;

namespace xamarin.quest.course.tests.Main
{
    public class MainViewModelTests
    {
        [Fact]
        public void DisplayAlertCommand_WhenCalled_DisplaysAlert()
        {
            var dialogMessage = new DialogMessageMock();
            var viewModel = new MainViewModel(dialogMessage);

            viewModel.DisplayAlertCommand.Execute(null);

            Assert.Equal(1, dialogMessage.DisplayAlertCallCount);
        }
    }
}
