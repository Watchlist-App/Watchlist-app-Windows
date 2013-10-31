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
using System.Windows.Controls;
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
        public Favorites()
        {
           // Data.EventHandler = new Data.MyEvent(toDataGrid);
            //InitializeComponent();
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
        }

        public void toDataGrid(Movies myMovies)
        {
            if (dataGrid2.Dispatcher.Thread == Thread.CurrentThread)
            {
                dataGrid2.ItemsSource = myMovies.watchlist;
                dataGrid2.Items.Refresh();
            }
            else
            {
                dataGrid2.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    dataGrid2.ItemsSource = myMovies.watchlist;
                    dataGrid2.Items.Refresh();
                }));
            }

        }


    }
}
