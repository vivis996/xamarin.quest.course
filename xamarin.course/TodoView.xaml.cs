using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamarin.course
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            var toDoViewModel = new ToDoViewModel(new DialogMessage());
            BindingContext = toDoViewModel;
            toDoViewModel.UpdateProgressBar += ToDoViewModel_UpdateProgressBar;
        }

        private async void ToDoViewModel_UpdateProgressBar(object sender, double e)
        {
            await progressBar.ProgressTo(e, 300, Easing.Linear);
        }
    }
}