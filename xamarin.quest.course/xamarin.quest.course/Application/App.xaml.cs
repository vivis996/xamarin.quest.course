using System;
using System.Reflection;
using Autofac;
using xamarin.quest.course.Common.Navigation;
using Xamarin.Forms;

namespace xamarin.quest.course.App
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

            NavigationPage navigationPage = null;

            Func<INavigation> navigationFunc = () => {
                return navigationPage.Navigation;
            };

            builder.RegisterType<NavigationService>().As<INavigationService>()
                .WithParameter("navigation", navigationFunc);

            // Get container
            var container = builder.Build();
            navigationPage = new NavigationPage(container.Resolve<Modules.Calculator.CalculatorView>());
            MainPage = navigationPage;
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
