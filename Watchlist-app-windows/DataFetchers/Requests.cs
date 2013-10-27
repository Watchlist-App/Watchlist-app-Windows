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
using System.Net;

namespace Watchlist_app_windows.DataFetchers
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
           
            public string GetInfo()
            {
                var request = System.Net.WebRequest.Create(URL) as System.Net.HttpWebRequest;
                request.Proxy = null;
                request.Method = "GET";
                request.ContentLength = 0;
                try
                {
                    using (var response = request.GetResponse() as System.Net.HttpWebResponse)
                    {

                        using (var reader = new System.IO.StreamReader(response.GetResponseStream()))
                        {
                            responseContent = reader.ReadToEnd();
                        }
                    }               
               } 
                catch(WebException exc) 
                {   
                    MessageBox.Show("Network error : " + exc.Message +        "\nStatement code: " + exc.Status);
                }  
                catch(ProtocolViolationException exc) 
                {   
                    MessageBox.Show("Protocol error: " + exc.Message);
                }  

                catch(UriFormatException exc) 
                {
                    MessageBox.Show("URL error,: " + exc.Message);
                }

                catch (NotSupportedException exc)
                {
                    MessageBox.Show("Unknown Protocol : " + exc.Message);
                }

                catch (IOException  exc)
                {
                    MessageBox.Show("I/O error : " + exc.Message);
                }


   
                return responseContent;
            }
            public string ReturnData()
            {
                return responseContent;
            }
        }
  
}
