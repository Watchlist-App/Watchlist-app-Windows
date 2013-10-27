using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Watchlist_app_windows
{
     /*[DataContract]
    internal class Movie
    {
          [DataMember]
        internal string original_title;
          [DataMember]
        internal string id;
    }*/


    public class Movies
    {

        public List<MovieInfo> results { get; set; }
    }

    public class MovieInfo
    {

        public string id { get; set; }
        public string original_title{ get; set; }
    }
}
