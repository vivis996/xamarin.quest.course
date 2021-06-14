using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.course
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress; 

        public ToDoViewModel()
        {
            this.Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            CalculateCompletedHeader();
        }

        public string CompletedHeader
        {
            get => _completedHeader;
            set
            {
                _completedHeader = value;
                OnPropertyChanged();
            }
        }

        public double CompletedProgress
        {
            get => _completedProgress;
            set
            {
                _completedProgress = value;
                OnPropertyChanged();
            }
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
            CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            this.CompletedHeader = $"Completed {Items.Count(x => x.Completed )}/{Items.Count}";
            this.CompletedProgress = (double)Items.Count(x => x.Completed) / (double)Items.Count;
        }

        private void AddNewItem()
        {
            Items.Add(new ToDoItem($"Todo Item {Items.Count + 1}"));
            CalculateCompletedHeader();
        }
    }
}