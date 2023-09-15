using System;
using System.Reflection;
using Autofac;
using Plugin.SharedTransitions;
using xamarin.quest.course.part2.Common.Database;
using xamarin.quest.course.part2.Common.Models.Api;
using xamarin.quest.course.part2.Common.Navigation;
using xamarin.quest.course.part2.Modules.Main;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Application
{
    public partial class App : Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            //class used for registration
            var builder = new ContainerBuilder();
            //scan and register all classes in the assembly
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess)
                   .AsImplementedInterfaces()
                   .AsSelf();
            builder.RegisterType<Repository<FullMovieInformation>>()
                   .As<IRepository<FullMovieInformation>>();

            //register navigation service
            SharedTransitionNavigationPage navigationPage = null;
            Func<INavigation> navigationFunc = () =>
            {
                return navigationPage.Navigation;
            };
            builder.RegisterType<NavigationService>().As<INavigationService>()
                   .WithParameter("navigation", navigationFunc);
            //get container
            var container = builder.Build();
            // set first page
            navigationPage = new SharedTransitionNavigationPage(container.Resolve<Mainview>());
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
