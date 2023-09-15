using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using xamarin.quest.course.part2.Common.Base;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Common.Navigation
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;
        Task PopAsync();
    }

    class NavigationService : INavigationService
    {
        private readonly Func<INavigation> _navigation;
        private readonly IComponentContext _container;
        private readonly Dictionary<Type, Type> _pageMap = new Dictionary<Type, Type>
        {
            // TODO: URL mapping goes here
            //  { typeof(HistoryViewModel), typeof(HistoryView) },
        };

        public NavigationService(Func<INavigation> navigation, IComponentContext container)
        {
            this._navigation = navigation;
            this._container = container;
        }

        public async Task PopAsync()
        {
            await this._navigation().PopAsync();
        }

        public async Task PushAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            var pageType = this._pageMap[typeof(TViewModel)];
            var page = this._container.Resolve(pageType) as Page;
            await this._navigation().PushAsync(page);
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }
    }
}
