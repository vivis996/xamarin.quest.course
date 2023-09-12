using Xamarin.Forms;

namespace xamarin.quest.course.Main
{
    public partial class MainView : ContentPage
    {
        public MainView()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}
