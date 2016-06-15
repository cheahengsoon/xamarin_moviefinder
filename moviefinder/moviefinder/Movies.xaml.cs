using System;
using Xamarin.Forms;

namespace moviefinder
{
    public partial class Movies : ContentPage
    {
        public Movies()
        {
            InitializeComponent();
        }

        private async void OnSearch(object sender, EventArgs args)
        {
            DataService db = new DataService();
            Movie movie = new Movie();

            if (txtTitle.Text != "")
            {
                movie = await db.GetMovieByTitleAsync(txtTitle.Text);
                if (movie != null)
                {
                    txtMovieTitle.Text = movie.Title + " (" + movie.Year + ")";
                    txtGenre.Text = movie.Genre;
                    imgPoster.Source = movie.Poster;
                    txtPlot.Text = movie.Plot;
                    txtRated.Text = "Rated: " + movie.Rated;
                    txtActors.Text = "Actors: " + movie.Actors;
                    txtImdbRating.Text = "IMDB Rating: " + movie.imdbRating;
                }
            }
        }
    }
}
