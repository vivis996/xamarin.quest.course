using System.Threading.Tasks;
using xamarin.quest.course.part2.Common.Base;

namespace xamarin.quest.course.part2.Common.Navigation
{
    public interface INavigationService
    {
        Task PushAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel;
        Task PopAsync();
    }
}
