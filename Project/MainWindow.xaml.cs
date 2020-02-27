using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OODProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Movie> movies = new List<Movie>();
        List<Movie> selectedMovies = new List<Movie>();
        List<Movie> filteredMovies = new List<Movie>();

        decimal totalCost = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Creating the movie objects
            Movie m1 = new Movie()
            {
                Name = "1917",
                Cost = 8m,
                Actors = "George McKay, Dean-Charles Chapman, Richard Madden, Benedict Cumberbatch",
                Director = "Sam Mendes",
                Times = "17:30, 20:30",
                Rating = "15A",
                TypeOfGenre = Genre.Drama,
                ImageName = "1917.jpg"

            };

            Movie m2 = new Movie()
            {
                Name = "Bad Boys for Life",
                Cost = 8m,
                Actors = "Will Smith, Martin Lawrence",
                Director = "Bilall Fallah, Adil El Arbi",
                Times = "18:00, 20:45",
                Rating = "16",
                TypeOfGenre = Genre.Action,
                ImageName = "badboys.jpg"
            };

            Movie m3 = new Movie()
            {
                Name = "The Turning",
                Cost = 8m,
                Actors = "Mackenzie Davis, Finn Wolfhard, Brooklynn Prince",
                Director = "Floria Sigismondi",
                Times = "18:30, 21:00",
                Rating = "16",
                TypeOfGenre = Genre.Horror,
                ImageName = "theturning.jpg"
            };

            Movie m4 = new Movie()
            {
                Name = "The Grudge",
                Cost = 8m,
                Actors = "Betty Gilpin, Andrea Riseborough, William Sadler",
                Director = "Nicolas Pesce",
                Times = "17:15, 20:30",
                Rating = "18",
                TypeOfGenre = Genre.Horror,
                ImageName = "grudge.jpg"
            };

            Movie m6 = new Movie()
            {
                Name = "Just Mercy",
                Cost = 8m,
                Actors = "Michael B Jordan, Jamie Foxx, Brie Larson",
                Director = "Destin Daniel Cretton",
                Times = "20:15",
                Rating = "12A",
                TypeOfGenre = Genre.Drama,
                ImageName = "justmercy.jpg"
            };

            Movie m7 = new Movie()
            {
                Name = "Doolittle",
                Cost = 8m,
                Actors = "Robert Downey Jr, Tom Holland, Michael Sheen",
                Director = "Stephen Gaghan",
                Times = "17:45, 20:15",
                Rating = "PG",
                TypeOfGenre = Genre.Comedy,
                ImageName = "doolittle.jpg"
            };

            Movie m8 = new Movie()
            {
                Name = "Jumanji",
                Cost = 8m,
                Actors = "Dwayne Johnson, Kevin Hart, Jack Black, Karen Gillan",
                Director = "Jake Kasdan",
                Times = "17:15",
                Rating = "12A",
                TypeOfGenre = Genre.Comedy,
                ImageName = "jumanji.jpg"
            };

            Movie m9 = new Movie()
            {
                Name = "Star Wars: The Rise of Skywalker",
                Cost = 8m,
                Actors = "Daisey Ridley, Adam Driver, John Boyega, Billie Lourd",
                Director = "J.J. Abrams",
                Times = "17:00",
                Rating = "12A",
                TypeOfGenre = Genre.Action,
                ImageName = "starwars.jpg"
            };

            //Adding movies to the list
            movies.Add(m1);
            movies.Add(m2);
            movies.Add(m3);
            movies.Add(m4);
            movies.Add(m6);
            movies.Add(m7);
            movies.Add(m8);
            movies.Add(m9);

            //Sort by alphabetical order
            movies.Sort();

            //Display the activities in the listbox
            lbxMoviesOptions.ItemsSource = null;
            lbxMoviesOptions.ItemsSource = movies;
        }

        //CLicking on a movie name will display the movie details
        private void lbxMoviesOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Movie selectedMovie = lbxMoviesOptions.SelectedItem as Movie;
            if (selectedMovie != null)
            {
                tblkRatingDetails.Text = selectedMovie.Rating;
                tblkActorsDetails.Text = selectedMovie.Actors;
                tblkDirectorDetails.Text = selectedMovie.Director;
                tblkTimeDetails.Text = selectedMovie.Times;

                string imagePath = $"\\images\\{selectedMovie.ImageName}";

                imgDetails.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            }
        }

        //Button used to add to the cart
        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            //Find what movie is selected 
            Movie selectedMovie = lbxMoviesOptions.SelectedItem as Movie;

            //Null check
            if (selectedMovie != null)
            {
                //Move activity from MovieOptions box to Cart box
                movies.Remove(selectedMovie);
                selectedMovies.Add(selectedMovie);

                //Update total
                totalCost += selectedMovie.Cost;
                tblkTotalDetails.Text = totalCost.ToString();

                //Sort the seleced movies by name
                selectedMovies.Sort();

                //Refreash screen
                lbxMoviesOptions.ItemsSource = null;
                lbxMoviesOptions.ItemsSource = movies;

                lbxCart.ItemsSource = null;
                lbxCart.ItemsSource = selectedMovies;
            }

            //Message box to alert user that no movie has been slected to add to the cart
            else if (selectedMovie == null)
            {
                MessageBox.Show("No movie has been selected to add to the cart");
            }
        }//End of add to cart button click

        //Button to remove from cart
        private void BtnRemoveFromCart_Click(object sender, RoutedEventArgs e)
        {
            //Find what movie is selected 
            Movie selectedMovie = lbxCart.SelectedItem as Movie;


            //Null check
            if (selectedMovie != null)
            {
                //Move movie from MovieOptions box to Cart box
                movies.Add(selectedMovie);
                selectedMovies.Remove(selectedMovie);

                //Update total
                totalCost -= selectedMovie.Cost;
                tblkTotalDetails.Text = totalCost.ToString();

                //Sort the seleced movies by name
                movies.Sort();

                //Refreash screen
                lbxMoviesOptions.ItemsSource = null;
                lbxMoviesOptions.ItemsSource = movies;

                lbxCart.ItemsSource = null;
                lbxCart.ItemsSource = selectedMovies;
            }

            //Message box to alert user that no movie has been selected to remove
            else if (selectedMovie == null)
            {
                MessageBox.Show("No movie has been selected to remove");
            }
        }

        //All radio buttons
        private void RadioAll_Click_1(object sender, RoutedEventArgs e)
        {
            filteredMovies.Clear();

            if (radioAll.IsChecked == true)
            {
                //Show all movies
                lbxMoviesOptions.ItemsSource = null;
                lbxMoviesOptions.ItemsSource = movies;

                lbxCart.ItemsSource = null;
                lbxCart.ItemsSource = selectedMovies;
            }
            else if (radioAction.IsChecked == true)
            {
                //Show only Action movies
                foreach (Movie movie in movies)
                {
                    if (movie.TypeOfGenre == Genre.Action)
                    {
                        filteredMovies.Add(movie);
                        lbxMoviesOptions.ItemsSource = null;
                        lbxMoviesOptions.ItemsSource = filteredMovies;
                    }
                }
            }
            else if (radioComedy.IsChecked == true)
            {
                //Show only Comedy movies
                foreach (Movie movie in movies)
                {
                    if (movie.TypeOfGenre == Genre.Comedy)
                    {
                        filteredMovies.Add(movie);
                        lbxMoviesOptions.ItemsSource = null;
                        lbxMoviesOptions.ItemsSource = filteredMovies;
                    }
                }
            }
            else if (radioDrama.IsChecked == true)
            {
                //Show only Drama movies
                foreach (Movie movie in movies)
                {
                    if (movie.TypeOfGenre == Genre.Drama)
                    {
                        filteredMovies.Add(movie);
                        lbxMoviesOptions.ItemsSource = null;
                        lbxMoviesOptions.ItemsSource = filteredMovies;
                    }
                }
            }
            else if (radioHorror.IsChecked == true)
            {
                //Show only Horror movies
                foreach (Movie movie in movies)
                {
                    if (movie.TypeOfGenre == Genre.Horror)
                    {
                        filteredMovies.Add(movie);
                        lbxMoviesOptions.ItemsSource = null;
                        lbxMoviesOptions.ItemsSource = filteredMovies;
                    }
                }
            }// end of raio buttton
        }
    }
}
