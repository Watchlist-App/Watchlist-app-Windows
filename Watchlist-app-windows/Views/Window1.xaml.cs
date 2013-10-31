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
using System.Windows.Controls;

namespace Watchlist_app_windows
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Window1 : Page
    {
        public List<Movie> MyWatchList = new List<Movie> { };
        int count;
        int max_count;
        public Window1()
        {
            int count = 0;
            InitializeComponent();
            WatchListData.EventHandler = new WatchListData.MyEvent(toWatchlist);
        }

        private void ViewProfile(object sender, RoutedEventArgs e)
        {
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page2);
        }

        private void ViewWatchlist(object sender, RoutedEventArgs e)
        {
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page3);
        }

        private void ViewFavorites(object sender, RoutedEventArgs e)
        {
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page4);
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Fandango_fetch(object sender, RoutedEventArgs e)
        {
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page5);
        }

        private void AmazonFetcher(object sender, RoutedEventArgs e)
        {
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page6);
        }

        private void YoutubeFetcher(object sender, RoutedEventArgs e)
        {
          //  WindowsList Singleton = WindowsList.GetInstance();
           // this.NavigationService.Navigate(Singleton.page7);
        }

        public void toViewBox(Movie myMovie)
        {         
                    Uri pictureUri = new Uri("http://d3gtl9l2a4fn1j.cloudfront.net/t/p/w300" + myMovie.poster_path);
                    BitmapImage image = new BitmapImage(pictureUri);
                    picture.Source = image;
                    TextBlock1.Text = myMovie.overview;
                    TextBlock2.Text = myMovie.Title;
        }


        public void toWatchlist(Movie myMovie)
        {           
            MyWatchList.Add(myMovie);
            toViewBox(MyWatchList[0]);                     
        }

        private void go_back(object sender, RoutedEventArgs e)
        {
            if (count >0)
                toViewBox(MyWatchList[--count]);
        }

        private void go_forward(object sender, RoutedEventArgs e)
        {
            if (count < MyWatchList.Count-1)
                toViewBox(MyWatchList[++count]);
        }
        }
    }

