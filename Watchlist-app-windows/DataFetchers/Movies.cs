using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Watchlist_app_windows.DataFetchers
{
    public class Movies
    {

        public List<MovieInfo> results { get; set; }
        public List<MovieInfo> watchlist  { get; set; } 

    }

    public class MovieInfo                          
    {

        public MovieInfo()
        {
            ID = "empty";
        }
        public string ID { get; set; }
        public string Title { get; set; }
        public string Release_Date { get; set; }     
        public string Vote_Average { get; set; }

        public ObservableCollection<MovieInfo> movieCall = new ObservableCollection<MovieInfo>();


       
    }

}


public class Movie
{
    public Movie()
        {
            id = "empty";
        }
    public string Title { get; set; }
    public string overview { get; set; }
    public string poster_path { get; set; }

    public int Watch_flag;

    public string source { get; set; }

    public string id { get; set; }

    public ObservableCollection<Movie> movieCall = new ObservableCollection<Movie>();
}
