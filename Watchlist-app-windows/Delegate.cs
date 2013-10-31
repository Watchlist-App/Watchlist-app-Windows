using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist_app_windows.DataFetchers;

namespace Watchlist_app_windows
{
    public static class Data
    {
        public delegate void MyEvent(Movies myMovies);
        public static MyEvent EventHandler;
    }

    public static class Owerview
    {
        public delegate void MyEvent(Movie myMovies);
        public static MyEvent EventHandler;
    }
}
