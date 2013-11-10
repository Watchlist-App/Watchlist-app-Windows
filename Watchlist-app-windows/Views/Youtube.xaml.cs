using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using Watchlist_app_windows.DataFetchers;



namespace Watchlist_app_windows.Views
{
    /// <summary>
    /// Interaction logic for Youtube.xaml
    /// </summary>
    public partial class Youtube : Page
    {
        Movie currentMovie = new Movie();
        public Youtube()
        {
            ToYoutube.EventHandler = new ToYoutube.MyEvent(toViewBox);           
            InitializeComponent();
        }
        private void GoToMain(object sender, RoutedEventArgs e)
        {
            //MyBrowser.Source = new Uri("http://www.google.by/");
            MyBrowser.VerifyAccess();
            //Thread.Sleep(500);         
            WindowsList Singleton = WindowsList.GetInstance(); 
            this.NavigationService.GoBack();  
        }
        public void toViewBox(Movie myMovie)
        {
            currentMovie = myMovie;

            MyBrowser.Source = new Uri("http://www.youtube.com/v/" + currentMovie.source);
            
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

        }
        private void toFandangoFetcher(object sender, RoutedEventArgs e)
        {
            ToFandango.EventHandler(currentMovie);
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page5);
        }
        private void ToWatchlist(object sender, RoutedEventArgs e)
        {
            WatchListData.EventHandler(currentMovie);
        }


    }
}


