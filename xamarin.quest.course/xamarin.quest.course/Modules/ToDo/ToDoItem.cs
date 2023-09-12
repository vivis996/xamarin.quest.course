using System.Collections.Generic;

namespace xamarin.quest.course.Modules.ToDo
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public bool Completed { get; set; }

        public ToDoItem(string name)
        {
            this.Name = name;
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
