using System.Collections.Generic;
using Xamarin.Forms;

namespace xamarin.course
{
    public class ToDoItem : BindableObject
    {
        private bool completed;
        public string Name { get; set; }

        public ToDoItem(string name)
        {
            this.Name = name;
        }

        public bool Completed
        {
            get => completed;
            set
            {
                this.completed = value;
                OnPropertyChanged();
            }
        }

        public static IEnumerable<ToDoItem> GetToDoItems()
        {
            return new List<ToDoItem>
            {
                new ToDoItem("Go to work"),
                new ToDoItem("Have a dev meeting"),
                new ToDoItem("Lunch time"),
                new ToDoItem("Family time"),
                new ToDoItem("Go to gym"),
            };
        }
    }
}
