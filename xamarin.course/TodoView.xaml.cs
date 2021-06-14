using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace xamarin.course
{
    public partial class TodoView : ContentPage
    {
        public TodoView()
        {
            InitializeComponent();
            BindingContext = new ToDoViewModel();
        }
    }
}
