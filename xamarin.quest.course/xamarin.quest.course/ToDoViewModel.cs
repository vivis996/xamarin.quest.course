using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.quest.course
{
    public class ToDoViewModel : BindableObject
    {
        public ToDoViewModel()
        {
            this.Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
        }

        public ObservableCollection<ToDoItem> Items { get; set; }

        public string PageTitle { get; set; }

        private ToDoItem _selectedItem;
        public ToDoItem SelectedItem
        {
            get => this._selectedItem;
            set
            {
                this._selectedItem = value;
                this.PageTitle = value?.Name;
                this.OnPropertyChanged(nameof(this.PageTitle));
            }
        }

        public ICommand AddItemCommand => new Command(this.AddNewItem);
        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(this.MarkAsCompleted);

        private void AddNewItem()
        {
            this.Items.Add(new ToDoItem($"Todo Item {this.Items.Count + 1}"));
        }

        private void MarkAsCompleted(ToDoItem item)
        {
            item.Completed = true;
            this.Items.Remove(item);
            this.Items.Add(item);
        }
    }
}
