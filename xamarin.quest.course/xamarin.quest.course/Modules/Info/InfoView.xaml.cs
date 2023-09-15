using xamarin.quest.course.Modules.Info.AppInformation;
using xamarin.quest.course.Modules.Info.History;
using Xamarin.Forms;

namespace xamarin.quest.course.Modules.Info
{
    public partial class InfoView : TabbedPage
    {
        public InfoView(InfoViewModel viewModel,
            HistoryView historyView, AppInformationView appInformationView)
        {
            InitializeComponent();
            this.BindingContext = viewModel;

            historyView.BindingContext = viewModel.HistorViewModel;
            historyView.IconImageSource = "history.png";
            appInformationView.IconImageSource = "information.png";
            this.Children.Add(historyView);
            this.Children.Add(appInformationView);
        }
    }
}
