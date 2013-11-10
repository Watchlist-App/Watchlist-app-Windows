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

namespace Watchlist_app_windows.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Name.Text!="") && (Email.Text!="") && (Pass.Text!=""))
            {
            Get request = new Get("http://watchlist-server.herokuapp.com/user/create?name=" + Name.Text + "&email=" + Email.Text + "&password=" + Pass.Text );
            request.GetInfo();
            }
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
            MessageBox.Show("Welcome, " + Name.Text);
        }
    }
}
