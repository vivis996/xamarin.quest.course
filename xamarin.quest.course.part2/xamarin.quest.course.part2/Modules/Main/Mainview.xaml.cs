using xamarin.quest.course.part2.Common.Network;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.Main
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
