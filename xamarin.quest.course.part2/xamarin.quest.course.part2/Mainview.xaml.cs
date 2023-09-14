using Xamarin.Forms;

namespace xamarin.quest.course.part2
{
    public partial class Mainview : ContentPage
    {
        public Mainview()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel(new NetworkService());
        }
    }
}

