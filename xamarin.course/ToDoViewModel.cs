using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamarin.course
{
    public class ToDoViewModel : BindableObject
    {
        private ToDoItem _selectedItem;
        private string _completedHeader;
        private double _completedProgress;

        public event EventHandler<double> UpdateProgressBar;

        private IDialogMessage _dialogMessage;

        public ToDoViewModel(IDialogMessage dialogMessage)
        {
            this._dialogMessage = dialogMessage;
            this.Items = new ObservableCollection<ToDoItem>(ToDoItem.GetToDoItems());
            this.CalculateCompletedHeader();
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
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                PageTitle = value?.Name;
                OnPropertyChanged("PageTitle");
            }
        }
        public ICommand AddItemCommand => new Command(async () => { await AddNewItem(); });

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
            this.CompletedHeader = $"Completed {Items.Count(x => x.Completed)}/{Items.Count}";
            this.CompletedProgress = (double)Items.Count(x => x.Completed) / (double)Items.Count;
            this.UpdateProgressBar?.Invoke(this, this.CompletedProgress);
        }

        private async Task AddNewItem()
        {
            string newItem = await _dialogMessage.DisplayPrompt("New Task", "Please enter a new task name");
            Items.Add(new ToDoItem(newItem));
        }
    }
}
