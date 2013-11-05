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
using System.Windows.Forms;
using Watchlist_app_windows.ViewControllers;
using System.Windows.Markup;

namespace Watchlist_app_windows
{
    /// <summary>
    /// Interaction logic for Favorites.xaml
    /// </summary>
    public partial class Favorites : Page
    {
        Movie currentMovie = new Movie();
        public List<Movie> MyFavorites = new List<Movie> { };
        int count;
        public Favorites()
        {
            FavoritesListData.EventHandler = new FavoritesListData.MyEvent(toFavorites);
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
        }
        public void toFavorites(Movie myMovie)
        {

            MyFavorites.Add(myMovie);
            toViewBox(MyFavorites[0]);
        }
        /*public void toViewBox(Movie myMovie)
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
                    picture.Source = image;
                    TextBlock1.Text = myMovie.overview;
                    TextBlock2.Text = myMovie.Title;
                }));

            }


        }*/
        private void go_back(object sender, RoutedEventArgs e)
        {
            if (count > 0)
                toViewBox(MyFavorites[--count]);
        }
        private void go_forward(object sender, RoutedEventArgs e)
        {
            if (count < MyFavorites.Count - 1)
                toViewBox(MyFavorites[++count]);
        }
        public void toViewBox(Movie myMovie)

        {
            Uri pictureUri = new Uri("http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w300" + myMovie.poster_path);
            //Uri pictureUri = new Uri("faGq4raUDFEKODYHr9Us010N3TL.jpg");
            BitmapImage image = new BitmapImage(pictureUri);
            picture.Source = image;
            //picture.Load();
            TextBlock1.Text = myMovie.overview;
            TextBlock2.Text = myMovie.Title;
            if (myMovie.Watch_flag == 1)
                TextBlock3.Text = "Seen";
            else
                TextBlock3.Text = null;
            dataGrid1.ItemsSource = MyFavorites;
            dataGrid1.Items.Refresh();

        }
        private void dataGrid1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Movie SelectedMovie = (Movie)dataGrid1.SelectedItem;
            toViewBox(SelectedMovie);
        }
    }
}
