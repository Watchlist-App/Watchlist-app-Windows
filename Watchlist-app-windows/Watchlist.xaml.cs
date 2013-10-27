﻿using System;
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
            Get request = new Get("http://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803");
            Movies myMovies = Serialization(request.GetInfo());
            foreach (var item in myMovies.results)
            {
                textbox1.Text += "Title: " + item.original_title + " ;";
            }
        }

        private void SearchByTitle(object sender, RoutedEventArgs e)
        {
            string temp = searchBox.Text;
            Get request = new Get("http://api.themoviedb.org/3/search/movie?query="+ temp + "&api_key=86afaae5fbe574d49418485ca1e58803");
            Movies myMovies = Serialization(request.GetInfo());
            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Id");
            dt.Rows.Add("1", "2");
            foreach (var item in myMovies.results)
            {               
                textbox1.Text += "Title:  " + item.original_title + " ;";          
            }
        }

        private Movies Serialization(string data)
        {
            Movies myMovies = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Movies>(data);
            /*DataGrid.DataSource = myMovies;
            DataGrid.Columns[0].DisplayIndex = 1;*/
            return myMovies;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }


    }
}
