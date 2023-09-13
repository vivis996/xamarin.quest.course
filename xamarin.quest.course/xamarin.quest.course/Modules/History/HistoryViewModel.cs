using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using xamarin.quest.course.Common.Navigation;
using Xamarin.Forms;

namespace xamarin.quest.course.Modules.History
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }

        public HistoryViewModel()
        {
            this.Items = new ObservableCollection<string>
            {
                "44 + 5 = 49",
                "36 / 9 = 4",
                "21 + 4 = 25",
            };
        }

        public override Task InitializeAsync(object parameter)
        {
            var operations = parameter as List<string>;
            operations.AddRange(this.Items);
            this.Items = new ObservableCollection<string>(operations);
            this.OnPropertyChanged(nameof(this.Items));
            return base.InitializeAsync(parameter);
        }

        public ICommand DeleteCommand => new Command<string>(this.DeleteItems);

        private void DeleteItems(string item)
        {
            this.Items.Remove(item);
        }
    }
}
