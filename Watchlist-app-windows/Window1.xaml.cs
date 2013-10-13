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

namespace Watchlist_app_windows
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Window1 : Page
    {
        public Window1()
        {
            InitializeComponent();
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

      
    }
}
