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
using System.IO;

namespace Watchlist_app_windows
{
    public class Get
    {
        protected string responseContent;
        protected string URL;

        public Get(string INFO)
        {
            URL = INFO;
            responseContent = "Empty";
        }
        public Stream GetInfo()
        {
            Stream myStream;
            var request = System.Net.WebRequest.Create(URL) as System.Net.HttpWebRequest;
            request.Proxy = null;
            request.Method = "GET";
            request.ContentLength = 0;
            using (var response = request.GetResponse() as System.Net.HttpWebResponse)
            {
                myStream = response.GetResponseStream();
                using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                {
                    responseContent = reader.ReadToEnd();
                }
            }
            return myStream;
        }
        public string ReturnData()
        {
            return responseContent;
        }

        public void GetFilmName()
        {
            String name;
            Int32 temp1 = responseContent.Length;
            Int32 temp2 = responseContent.Length;
            while(temp1>0)
            {
                temp1 = responseContent.LastIndexOf("original_title",temp1-16) + 16;
                temp2 = responseContent.LastIndexOf("release_date", temp2) - 2;
                name = responseContent.Substring(temp1, temp2 - temp1);
                MessageBox.Show(name);       
            }
          
        }
    }
}
