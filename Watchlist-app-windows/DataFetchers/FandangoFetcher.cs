using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;
using System.Xml;
using System.IO;

using System.Collections.ObjectModel;

namespace Watchlist_app_windows.DataFetchers
{
  public  class FandangoFetcher
    {
      public static Dictionary<string, string> getShowTime(string title,string city)
        {
            string urlCity = "http://www.fandango.com/rss/moviesnearme_" + city + ".rss";       //обращение по месту в городе
            int CounterToCheck = 2;                                                      //перечисление по rss странице
            string tempCinema;                                              //текущее имя театра
            string tempTitle;                                               //текущие фильмы в театре
            string tempCinemaLink;                                          //ссылка на фильм
            Dictionary<string, string> titleCinema = new Dictionary<string, string>();  //временный справочник для формирования списка театров
            
            


            System.Net.HttpWebRequest request = null;                   //создание запроса
            StreamReader responseReader = null;                         //создание ридера
            string responseData = "";                                   //сохранение данных из запроса

            request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(urlCity); //откуда берем наш rss
            responseReader = new StreamReader(request.GetResponse().GetResponseStream()); //читаем наш поток
            responseData = responseReader.ReadToEnd();      //временная строка


            //---------------------------------------------------------------

            XmlDocument doc = new XmlDocument(); // объявляем переменную Док, как ХМЛ документ и создаем ее.
            doc.LoadXml(responseData);   // загружаем файл "responseData" в документ

            CounterToCheck = 2;
            try
            {
                do                                               //начало бесконечного цикла для проверки фильмов и записи в справочник
                {
                    tempCinema = doc.GetElementsByTagName("title")[CounterToCheck].FirstChild.Value; // загоняем очередное название театра строку
                    tempTitle = doc.GetElementsByTagName("description")[CounterToCheck - 1].FirstChild.Value; // загоняем список фильмов в очередном театре в строку;
                    tempCinemaLink = doc.GetElementsByTagName("link")[CounterToCheck - 1].FirstChild.Value; // ссылув на фильм

                    if (tempTitle.IndexOf(title) > -1)              //проверка, что фильм найден среди списка фильмов очередного театра
                    {
                        titleCinema.Add(tempCinemaLink, tempCinema);         //заносим в справочник Dictionary Фильм и ссылку на него
                    }
                    else
                    {
                        //игнорируем
                    }

                    CounterToCheck++;                                    //переход к следующему элементу


                } while (true);                              //уловие бесконечного цикла
            }
            catch (System.NullReferenceException e)     //ловим исключение на этапе конца страницы
            {


            }


            request.GetResponse().GetResponseStream().Close();      //закрытие потока
            responseReader.Close();                                 //закрытие ридера
            responseReader = null;





            doc = null;         //закрытие дока

            return titleCinema;                 //возращаем справочник
        }

     // public ObservableCollection<titleCinema> movieCall = new ObservableCollection<titleCinema>();
    }
}
