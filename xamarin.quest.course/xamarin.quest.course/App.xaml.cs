using System.Reflection;
using Autofac;
using Xamarin.Forms;

namespace xamarin.quest.course
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Class used for building the registration
            var builder = new ContainerBuilder();
            // Scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();

            // Get container
            var container = builder.Build();

            MainPage = container.Resolve<Calculator.CalculatorView>();
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
