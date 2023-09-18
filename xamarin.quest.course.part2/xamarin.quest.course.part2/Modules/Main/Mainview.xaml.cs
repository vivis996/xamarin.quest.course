using System;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.Main
{
    public partial class Mainview : ContentPage
    {
        public Mainview(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }

        async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await this.imageButton.ScaleTo(1.3, 200);
            await this.imageButton.ScaleTo(1, 200);
        }
    }
}
