using Xamarin.Forms;

namespace xamarin.quest.course.Modules.History
{
    public partial class HistoryView : ContentPage
    {
        public HistoryView(HistoryViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
