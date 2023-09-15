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
    }
}
