using xamarin.quest.course.part2.Modules.Main;

namespace xamarin.quest.course.part2.Application
{
    public partial class App : Xamarin.Forms.Application
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
