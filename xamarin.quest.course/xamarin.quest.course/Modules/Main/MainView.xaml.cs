using Xamarin.Forms;

namespace xamarin.quest.course.Modules.Main
{
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
