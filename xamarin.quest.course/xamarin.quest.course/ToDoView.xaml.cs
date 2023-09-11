using Xamarin.Forms;

namespace xamarin.quest.course
{
    public partial class ToDoView : ContentPage
    {
        public ToDoView()
        {
            InitializeComponent();
            this.BindingContext = new ToDoViewModel();
        }
    }
}
