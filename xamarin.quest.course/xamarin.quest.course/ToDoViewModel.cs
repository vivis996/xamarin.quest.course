using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.quest.course
{
    public class ToDoViewModel : BindableObject
    {
        public ToDoViewModel()
        {
            this.Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            this.CalculateCompletedHeader();
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
        private string _completedHeader;
        public string CompletedHeader
        {
            get => this._completedHeader;
            set
            {
                this._completedHeader = value;
                this.OnPropertyChanged();
            }
        }

        private double _completedProgress;
        public double CompletedProgress
        {
            get => this._completedProgress;
            set
            {
                this._completedProgress = value;
                this.OnPropertyChanged();
            }
        }

        public event EventHandler<double> UpdateProgressBar;

        public ICommand AddItemCommand => new Command(this.AddNewItem);
        public ICommand MarkAsCompletedCommand => new Command<ToDoItem>(this.MarkAsCompleted);

        private void AddNewItem()
        {
            this.Items.Add(new ToDoItem($"Todo Item {this.Items.Count + 1}"));
            this.CalculateCompletedHeader();
        }

        private void MarkAsCompleted(ToDoItem item)
        {
            item.Completed = !item.Completed;
            this.Items.Remove(item);
            this.Items.Add(item);
            this.CalculateCompletedHeader();
        }

        private void CalculateCompletedHeader()
        {
            this.CompletedHeader = $"Completed {this.Items.Count(x => x.Completed)}/{this.Items.Count}";
            this.CompletedProgress = (double)this.Items.Count(x => x.Completed) / (double)this.Items.Count;
            this.UpdateProgressBar?.Invoke(this, this.CompletedProgress);
        }
    }
}
