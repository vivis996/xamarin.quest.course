using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.Main
{
    public partial class Mainview : ContentPage
    {
        public Mainview(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
