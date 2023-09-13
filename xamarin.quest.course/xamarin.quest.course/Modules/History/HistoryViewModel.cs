using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.quest.course.Modules.History
{
    public class HistoryViewModel : BindableObject
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

        public ICommand DeleteCommand => new Command<string>(this.DeleteItems);

        private void DeleteItems(string item)
        {
            this.Items.Remove(item);
        }
    }
}
