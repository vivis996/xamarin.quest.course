using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamarin.quest.course.Common.Navigation
{
    public abstract class BaseViewModel : BindableObject
    {
        public virtual Task InitializeAsync(object parameter)
        {
            return Task.CompletedTask;
        }
    }
}