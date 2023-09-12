 using xamarin.quest.course.Dialog;
using Xamarin.Forms;

namespace xamarin.quest.course.Main
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
