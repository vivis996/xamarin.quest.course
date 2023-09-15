using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.Common.Navigation;
using Xamarin.Forms;

namespace xamarin.quest.course.Modules.Info.History
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        public HistoryViewModel()
        {
            this.Items = new ObservableCollection<string>();
        }

        public override Task InitializeAsync(object parameter)
        {
            var operations = parameter as List<string>;
            this.Items = new ObservableCollection<string>(operations);
            this.OnPropertyChanged(nameof(this.Items));
            return base.InitializeAsync(parameter);
        }

        public ICommand DeleteCommand => new Command<string>(this.DeleteItems);

        private void DeleteItems(string item)
        {
            this.Items.Remove(item);
            MessagingCenter.Send(this, "Items", new List<string>(this.Items));
        }
    }
}
