using System.Threading.Tasks;
using xamarin.quest.course.Common.Navigation;
using xamarin.quest.course.Modules.Info.History;

namespace xamarin.quest.course.Modules.Info
{
    public class InfoViewModel : BaseViewModel
    {
        public HistoryViewModel HistorViewModel { get; set; }

        public InfoViewModel(HistoryViewModel historViewModel)
        {
            this.HistorViewModel = historViewModel;
        }

        public override Task InitializeAsync(object parameter)
        {
            this.HistorViewModel.InitializeAsync(parameter);
            return base.InitializeAsync(parameter);
        }
    }
}
