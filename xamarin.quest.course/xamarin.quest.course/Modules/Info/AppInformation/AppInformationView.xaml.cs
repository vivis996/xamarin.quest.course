using Xamarin.Forms;

namespace xamarin.quest.course.Modules.Info.AppInformation
{
    public partial class AppInformationView : ContentPage
    {
        public AppInformationView(AppInformationViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
