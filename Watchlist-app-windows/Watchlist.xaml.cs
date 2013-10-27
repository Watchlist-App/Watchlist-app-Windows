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
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;

namespace Watchlist_app_windows
{ 
    /// <summary>
    /// Interaction logic for Watchlist.xaml
    /// </summary>
    public partial class Watchlist : Page
    {            
        public Watchlist()
        {
            InitializeComponent();
        }

        private void GoToMain(object sender, RoutedEventArgs e)
        {

            WindowsList Singleton = WindowsList.GetInstance();
            this.NavigationService.Navigate(Singleton.page1);
        }

        private void SearchPopular(object sender, RoutedEventArgs e)
        {
            Get test = new Get("http://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803");
            test.GetInfo();
        }

        private void SearchByTitle(object sender, RoutedEventArgs e)
        {
            string temp = searchBox.Text;
            Get test = new Get("http://api.themoviedb.org/3/search/movie?query="+ temp + "&api_key=86afaae5fbe574d49418485ca1e58803");
            test.GetInfo();

            Movies myMovies = Serialization(test.ReturnData());
            foreach (var item in myMovies.results)
            {
                textbox1.Text +="id:" + item.id + "  ";
                textbox1.Text += "Title:" + item.original_title;          
            }

            //textbox1.Text = test.ReturnData();
        }

        private Movies Serialization(string data)
        {
            Movies myMovies = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Movies>(data);
            return myMovies;
        }


    }
}
