using Xamarin.Forms;

namespace xamarin.quest.course
{
    public partial class ToDoView : ContentPage
    {
        public ToDoView()
        {
            InitializeComponent();
            var toDoViewModel = new ToDoViewModel();
            this.BindingContext = toDoViewModel;
            toDoViewModel.UpdateProgressBar += ToDoViewModel_UpdateProgressBar;
        }

        private async void ToDoViewModel_UpdateProgressBar(object sender, double e)
        {
            await this.progressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}
