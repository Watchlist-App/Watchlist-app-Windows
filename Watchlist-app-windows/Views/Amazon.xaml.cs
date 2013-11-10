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
    /// Interaction logic for Favorites.xaml
    /// </summary>
    public partial class Amazon : Page
    {
        public Amazon()
        {
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
        }
    }
}
