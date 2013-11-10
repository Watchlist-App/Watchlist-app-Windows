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
    public partial class Login : Page
    {
        public Login()
        {           
            InitializeComponent();
            this.WindowHeight = 240;
            this.WindowWidth = 480; 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page8);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((Name.Text != "") && (Pass.Text != ""))
            {
                Ser a = new Ser();
                Get request = new Get("http://watchlist-server.herokuapp.com/user?name=" + Name.Text + "&password=" + Pass.Text);
                User currentUser = a.Serialization_User(request.GetInfo());
                if (currentUser!= null)
                {
                    MessageBox.Show("Welcome, " + currentUser.name);
                    WindowsList Singleton = WindowsList.GetInstance();
                    this.NavigationService.Navigate(Singleton.page1);

                }
                else
                {
                    MessageBox.Show("Wrong name or password!");
                    return;
                }
                   

            }
        }
    }
}
