using Xamarin.Forms;

namespace xamarin.quest.course
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ToDoView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
