using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist_app_windows.DataFetchers;
using Watchlist_app_windows.ViewControllers;



namespace Watchlist_app_windows
{
    class ThreadClass                           //класс нового потока
    {
        public ThreadClass(Get someRequest)     //в качестве параметра передаем класс запроса
        {
            request = someRequest;
        }

        public Get request;                     //собственно класс запроса         

        public void func()                        //метод получения предварительной инфы о фильмах для дата грида
        {
            request.GetInfo();                      //получени инфы запросом из интернета
            Ser a = new Ser();                      
            Movies myMovies = a.Serialization(request.GetInfo());   //сериализация полученных данных  (Movies содержит коллекцию)
            Data.EventHandler(myMovies);             //через делегат передаем полученные данные в датагрид
        }

        public void func2()                     //метод получения дополнительной инфы по фильму (постер, описание)
        {
            request.GetInfo();                     
            Ser a = new Ser();
            Movie myMovie = a.Serialization_owerview(request.GetInfo());    //Movie - инфа о конкретном фильме        
            MetaData.EventHandler(myMovie);   
        }
    }

    class ThreadClassFandango                           //класс нового потока
    {
        public string Film;
        public string zip;
        public ThreadClassFandango(string someFilm, string someZip)     //в качестве параметра передаем класс запроса
        {
              Film = someFilm;
              zip = someZip;
        }
        public void func_fandango()                     //метод получения дополнительной инфы по фильму (постер, описание)
        {
            FandangoFetcher request = new FandangoFetcher();

            Dictionary<string, string> titleCinema = new Dictionary<string, string>();

            string titleView = "";
            string titleViewEnd = "";          

            titleCinema = FandangoFetcher.getShowTime(Film, zip);

            foreach (var film in titleCinema)
            {

                titleView += string.Format("{0}; {1}\n", film.Key, film.Value);

            }
            Fandango.EventHandler(titleCinema);
        }
    }
}
