using Xamarin.Forms;

namespace xamarin.quest.course.Calculator
{
    public partial class CalculatorView : ContentPage
    {
        public CalculatorView(CalculatorViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}
