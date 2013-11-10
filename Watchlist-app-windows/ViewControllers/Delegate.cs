using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist_app_windows.DataFetchers;

namespace Watchlist_app_windows
{
    public static class Data                    //делегат для передачи даннных в датагрид на FilmsSearch.xaml
    {
        public delegate void MyEvent(Movies myMovies);
        public static MyEvent EventHandler;
    }
    public static class MetaData                 //делегат для передачирасширенных данных(постер, описание) на FilmsSearch.xaml    
    {
        public delegate void MyEvent(Movie myMovies);
        public static MyEvent EventHandler;
    }
    public static class WatchListData           //делегат для передачи даннных в watchlist на window1.xaml
    {
        public delegate void MyEvent(Movie myMovies);
        public static MyEvent EventHandler;
    }
    public static class FavoritesListData       //делегат для передачи даннных в favorites
    {
        public delegate void MyEvent(Movie myMovies);
        public static MyEvent EventHandler;
    }
    public static class Fandango  
    {
        public delegate void MyEvent(Dictionary<string, string> titleCinema);
        public static MyEvent EventHandler;
    }
    public static class ToFandango
    {
        public delegate void MyEvent(Movie myMovies);
        public static MyEvent EventHandler;
    }
    public static class ToYoutube
    {
        public delegate void MyEvent(Movie myMovies);
        public static MyEvent EventHandler;
    }
}
