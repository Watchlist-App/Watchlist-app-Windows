using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;

namespace Watchlist_app_windows.DataFetchers
{
    public class Movies
    {

        public List<MovieInfo> results { get; set; }
    }

    public class MovieInfo
    {

        public string ID { get; set; }
        public string Title { get; set; }
        public string Release_Date { get; set; }
        public string Popularity { get; set; }       

    }

    public class MovieInfoViewModel
    {
        public ObservableCollection<MovieInfo> _movies = new ObservableCollection<MovieInfo>();

        public ObservableCollection<MovieInfo> movieCall = new ObservableCollection<MovieInfo>();
        public ObservableCollection<MovieInfo> Movies
        {
            get { return _movies; }
            set { _movies = value; }
        }
    }
}
