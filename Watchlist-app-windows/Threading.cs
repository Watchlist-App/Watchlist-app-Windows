using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist_app_windows.DataFetchers;
using Watchlist_app_windows.ViewControllers;



namespace Watchlist_app_windows
{
    class ThreadClass
    {
        public ThreadClass(Get someRequest)
        {
            request = someRequest;
        }

        public Get request;

        public void func()
        {
            request.GetInfo();
            Ser a = new Ser();
            Movies myMovies = a.Serialization(request.GetInfo());
            Data.EventHandler(myMovies);
        }

        public void func2()
        {
            request.GetInfo();
            Ser a = new Ser();
            Movie myMovie = a.Serialization_owerview(request.GetInfo());          
            MetaData.EventHandler(myMovie);
        }
                
      
    }

}
