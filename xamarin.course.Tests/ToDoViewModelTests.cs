using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace xamarin.course.Tests
{
    public class ToDoViewModelTests
    {
        [Fact]
        public void ViewModel_populates_items_correctly()
        {
            var viewmodel = new ToDoViewModel(new DialogMessageMock());

            Assert.Equal(5, viewmodel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_adds_new_item_to_the_list()
        {
            var dialogMessage = new DialogMessageMock();
            dialogMessage.DialogResponse = "course Item 6";
            var viewModel = new ToDoViewModel(dialogMessage);

            viewModel.AddItemCommand.Execute(null);

            Assert.Equal(6, viewModel.Items.Count);
            Assert.Equal("course Item 6", viewModel.Items.Last().Name);
        }

        [Fact]
        public void MarkAsCompletedCommand_marks_item_as_completed_and_puts_it_at_the_end_of_list()
        {
            var viewModel = new ToDoViewModel(new DialogMessageMock());

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.True(viewModel.Items.Last().Completed);
        }

        [Fact]
        public void MarkAsCompletedCommand_updates_progress()
        {
            var viewModel = new ToDoViewModel(new DialogMessageMock());

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.Equal("Completed 1/5", viewModel.CompletedHeader);
            Assert.Equal(0.2, viewModel.CompletedProgress);
        }
    }

    class DialogMessageMock : IDialogMessage
    {
        public int DisplayAlertCallCount { get; set; }
        public string DialogResponse { get; set; }

        public Task DisplayAlert(string title, string message, string cancel)
        {
            DisplayAlertCallCount++;
            return Task.CompletedTask;
        }

        public Task<string> DisplayActionSheet(string title, string destruction, params string[] buttons)
        {
            return Task.FromResult(DialogResponse);
        }


        public Task<string> DisplayPrompt(string title, string message)
        {
            return Task.FromResult(DialogResponse);
        }
    }
}