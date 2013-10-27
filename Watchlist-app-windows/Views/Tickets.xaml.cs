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

namespace Watchlist_app_windows
{
    /// <summary>
    /// Interaction logic for Tickets.xaml
    /// </summary>
    public partial class Tickets : Page
    {
        public Tickets()
        {
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FandangoFetcher request = new FandangoFetcher();

            Dictionary<string, string> titleCinema = new Dictionary<string, string>();

            string titleView = ""; 
            string titleViewEnd = "";
            titleCinema = FandangoFetcher.getShowTime(TextBox_1.Text, TextBox_2.Text);

            foreach (var film in titleCinema)
            {

                titleView += string.Format("{0}; {1}\n", film.Key, film.Value);
                
            }           

            dataGrid2.ItemsSource = titleCinema;
            dataGrid2.Items.Refresh();

        }
    }
}
