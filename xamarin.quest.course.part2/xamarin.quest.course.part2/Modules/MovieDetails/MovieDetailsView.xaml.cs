using Xamarin.Forms;

namespace xamarin.quest.course.part2.Modules.MovieDetails
{
    public partial class MovieDetailsView : ContentPage
    {
        public MovieDetailsView(MovieDetailsViewModel viewModel)
        {
            InitializeComponent();

            this.BindingContext = viewModel;
        }

        async void imageButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await this.imageButton.ScaleTo(1.3, 200);
            await this.imageButton.ScaleTo(1, 200);
        }
    }
}
