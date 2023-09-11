using System.Collections.ObjectModel;
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
    }
}
