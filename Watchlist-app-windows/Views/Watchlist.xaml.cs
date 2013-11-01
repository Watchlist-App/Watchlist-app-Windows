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
using System.IO;
using System.Data;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using Watchlist_app_windows.DataFetchers;
using System.Threading;
using Watchlist_app_windows.ViewControllers;
using System.Windows.Markup;
using System.ComponentModel;
using System.Drawing;



namespace Watchlist_app_windows
{
    /// <summary>
    /// Interaction logic for Watchlist.xaml
    /// </summary>
    public partial class Watchlist : Page
    {
        Movie currentMovie = new Movie();
        public Watchlist()
        {           
            Data.EventHandler = new Data.MyEvent(toDataGrid);
            MetaData.EventHandler = new MetaData.MyEvent(toViewBox);     
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
        }
        private void SearchPopular(object sender, RoutedEventArgs e)
        {
            Get request = new Get("http://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803");
            ThreadClass tc = new ThreadClass(request);
            Thread searchThread = new Thread(new ThreadStart(tc.func));
            searchThread.Start();
          
        }
        private void SearchByTitle(object sender, RoutedEventArgs e)
        {           
            string temp = searchBox.Text;
            if (temp != "")
            {
                Get request = new Get("http://api.themoviedb.org/3/search/movie?query=" + temp + "&api_key=86afaae5fbe574d49418485ca1e58803");
                ThreadClass tc = new ThreadClass(request);
                Thread searchThread = new Thread(new ThreadStart(tc.func));
                searchThread.Start();
            }
        }
        public void toDataGrid(Movies myMovies)
        {
            if (dataGrid1.Dispatcher.Thread == Thread.CurrentThread)
            {
                dataGrid1.ItemsSource = myMovies.results;
                dataGrid1.Items.Refresh();
            }
            else
            {
                dataGrid1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                dataGrid1.ItemsSource = myMovies.results;
                dataGrid1.Items.Refresh();            
            }));
            }
           
            
        }
        void toFavorites(object sender, RoutedEventArgs e)
        {
            FavoritesListData.EventHandler(currentMovie);
        }
        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

            MovieInfo Movie = (MovieInfo)dataGrid1.SelectedItem;
            if (Movie != null)
            {
                Get request = new Get("http://api.themoviedb.org/3/movie/" + Movie.ID + "?api_key=86afaae5fbe574d49418485ca1e58803");
                ThreadClass tc = new ThreadClass(request);
                Thread searchThread = new Thread(new ThreadStart(tc.func2));
                searchThread.Start();
            }
            
        }
        public void toViewBox(Movie myMovie)
        {
            currentMovie = myMovie;
            if (TextBlock1.Dispatcher.Thread == Thread.CurrentThread)
            {                
                Uri pictureUri = new Uri("http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w300" + myMovie.poster_path);
                BitmapImage image = new BitmapImage(pictureUri);
                picture.Source = image;
                TextBlock1.Text = myMovie.overview;
                TextBlock2.Text = myMovie.Title;
            }
            else
            {
                TextBlock1.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    
                    Uri pictureUri = new Uri("http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w300" + myMovie.poster_path);              
                    BitmapImage image = new BitmapImage(pictureUri);                                       
                    image.DownloadCompleted += objImage_DownloadCompleted;
                    picture.Source = image;
                    TextBlock1.Text = myMovie.overview;
                    TextBlock2.Text = myMovie.Title;
                }));

            }

        }      
        private void ToWatchlist(object sender, RoutedEventArgs e)
        {
            WatchListData.EventHandler(currentMovie);
        }
        private void objImage_DownloadCompleted(object sender, EventArgs e)
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            Guid photoID = System.Guid.NewGuid();
            String photolocation = photoID.ToString() + ".jpg";  //file name           

            encoder.Frames.Add(BitmapFrame.Create((BitmapImage)sender));

            using (var filestream = new FileStream(photolocation, FileMode.Create))
                encoder.Save(filestream);
        }
        private void SearchTopRated(object sender, RoutedEventArgs e)
        {
            Get request = new Get("http://api.themoviedb.org/3/movie/top_rated?api_key=86afaae5fbe574d49418485ca1e58803");
            ThreadClass tc = new ThreadClass(request);
            Thread searchThread = new Thread(new ThreadStart(tc.func));
            searchThread.Start();

        } 
        private void SearchUpcoming(object sender, RoutedEventArgs e)
        {
            Get request = new Get("http://api.themoviedb.org/3/movie/upcoming?api_key=86afaae5fbe574d49418485ca1e58803");
            ThreadClass tc = new ThreadClass(request);
            Thread searchThread = new Thread(new ThreadStart(tc.func));
            searchThread.Start();


        }
        private void Searchsimilar_movies(object sender, RoutedEventArgs e)
        {
            if (currentMovie.id != "empty")
            {
                Get request = new Get("http://api.themoviedb.org/3/movie/" + currentMovie.id + "/similar_movies?api_key=86afaae5fbe574d49418485ca1e58803");
                ThreadClass tc = new ThreadClass(request);
                Thread searchThread = new Thread(new ThreadStart(tc.func));
                searchThread.Start();
            }
        }
        private void SearchNowPlaying(object sender, RoutedEventArgs e)
        {
            Get request = new Get("http://api.themoviedb.org/3/movie/now_playing?api_key=86afaae5fbe574d49418485ca1e58803");
            ThreadClass tc = new ThreadClass(request);
            Thread searchThread = new Thread(new ThreadStart(tc.func));
            searchThread.Start();
        }
        private void toFandangoFetcher(object sender, RoutedEventArgs e)
        {
            //переход к поиску билетов
        }


    }
}
