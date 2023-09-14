using Xamarin.Forms;

namespace xamarin.quest.course.part2
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();

            MainPage = new Mainview();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
