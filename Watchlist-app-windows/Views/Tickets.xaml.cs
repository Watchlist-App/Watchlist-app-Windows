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
using Watchlist_app_windows.DataFetchers;
using Watchlist_app_windows.DataFetchers;
using System.Threading;
using Watchlist_app_windows.ViewControllers;
using System.Windows.Markup;

namespace Watchlist_app_windows
{
    /// <summary>
    /// Interaction logic for Tickets.xaml
    /// </summary>
    public partial class Tickets : Page
    {
        Movie currentMovie = new Movie();
        public Tickets()
        {
            Fandango.EventHandler = new Fandango.MyEvent(toDataGrid);
            ToFandango.EventHandler = new ToFandango.MyEvent(startSearch);
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.GoBack(); 
        }
        public void startSearch(Movie MovieToSearch)
        {
            TextBox_1.Text = MovieToSearch.Title;
            TextBox_2.Text = "90210";
            toViewBox(MovieToSearch);
            ThreadClassFandango tc = new ThreadClassFandango(MovieToSearch.Title, "90210");
            Thread searchThread = new Thread(new ThreadStart(tc.func_fandango));
            searchThread.Start();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ThreadClassFandango tc = new ThreadClassFandango(TextBox_1.Text, TextBox_2.Text);
            Thread searchThread = new Thread(new ThreadStart(tc.func_fandango));
            searchThread.Start();
        }
        public void toDataGrid(Dictionary<string, string> titleCinema)
        {
            if (dataGrid2.Dispatcher.Thread == Thread.CurrentThread)                //это проверка, к какому потоку принадлежат данные, которые мы пытаемся загнать в датагрид
            {
                dataGrid2.ItemsSource = titleCinema;
                dataGrid2.Items.Refresh();
            }
            else
            {                                                                       //если нет, то системным делегатом обеспчеиваем доступ к данным между разными потоками    
                dataGrid2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    dataGrid2.ItemsSource = titleCinema;
                    dataGrid2.Items.Refresh();
                }));
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
                    picture.Source = image;
                    TextBlock1.Text = myMovie.overview;
                    TextBlock2.Text = myMovie.Title;
                }));

            }

        }
        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }      
    }
}
