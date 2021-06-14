using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.course
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;

        public ToDoViewModel()
        {
            this.Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
        }

        public ObservableCollection<ToDoItem> Items { get; set; }

        public string PageTitle { get; set; }
        public ToDoItem SelectedItem
        {
            get => _selectedItem; set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }
        public ICommand AddItemCommand => new Command(() => AddNewItem());
        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(MarkAsCompleted);

        private void MarkAsCompleted(ToDoItem obj)
        {
            obj.Completed = !obj.Completed;
            Items.Remove(obj);
            Items.Add(obj);
        }

        private void AddNewItem()
        {
            Items.Add(new ToDoItem($"Todo Item {Items.Count + 1}"));
        }
    }
}