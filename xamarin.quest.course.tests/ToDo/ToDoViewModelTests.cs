using xamarin.quest.course.ToDo;

namespace xamarin.quest.course.tests.ToDo
{
	public class ToDoViewModelTests
	{
        [Fact]
        public void ViewModel_WhenCalled_PopulatesItemsCorrectly()
        {
            var viewModel = new ToDoViewModel();

            Assert.Equal(5, viewModel.Items.Count);
        }

        [Fact]
        public void AddItemCommand_WhenCalled_AddsNewItemToTheList()
        {
            var viewModel = new ToDoViewModel();
            viewModel.AddItemCommand.Execute(true);

            Assert.Equal(6, viewModel.Items.Count);
            Assert.Equal("Todo Item 6", viewModel.Items.Last().Name);
        }

        [Fact]
        public void MarkAsCompletedCommand_WheCalled_MarksItemAsCompletedAndPutsItAtTheEndOfList()
        {
            var viewModel = new ToDoViewModel();
            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.True(viewModel.Items.Last().Completed);
        }

        [Fact]
        public void MarkAsCompletedCommand_WhenCalled_UpdateProgress()
        {
            var viewModel = new ToDoViewModel();

            viewModel.MarkAsCompletedCommand.Execute(viewModel.Items.First());

            Assert.Equal("Completed 1/5", viewModel.CompletedHeader);
            Assert.Equal(0.2, viewModel.CompletedProgress);
        }
    }
}
