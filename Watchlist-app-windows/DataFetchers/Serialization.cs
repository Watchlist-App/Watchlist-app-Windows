﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Watchlist_app_windows.DataFetchers
{
    class Ser
    {
        public Movies Serialization(string data)
        {
            Movies myMovies = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Movies>(data);
            return myMovies;
        }

        public Movie Serialization_owerview(string data)
        {
            Int32 tmp = data.IndexOf("source");
            Movie myMovies = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<Movie>(data);
            myMovies.source = data.Substring(tmp+9, 11);
            return myMovies;
        }
    }
}
