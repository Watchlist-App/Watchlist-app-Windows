using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Watchlist_app_windows
{
    public class GetMovie
    {
        protected string responseContent;

        public GetMovie()
        {
            responseContent = "Empty";
        }
        public void GetInfo()
        {
            var request = System.Net.WebRequest.Create("http://api.themoviedb.org/3/movie/popular?api_key=86afaae5fbe574d49418485ca1e58803") as System.Net.HttpWebRequest;
            request.Proxy = null;
            request.Method = "GET";
            request.ContentLength = 0;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
        }
        public string ReturnData()
        {
            return responseContent;
        }

    }
}
