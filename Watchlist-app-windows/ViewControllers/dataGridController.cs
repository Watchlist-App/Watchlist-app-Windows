using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist_app_windows.DataFetchers;
using System.Windows.Controls;


namespace Watchlist_app_windows.ViewControllers
{
    class dataGridController
    {
        public void toDataGrid(Movies myMovies)
        {
            Data.EventHandler(myMovies);
        }
    }
}
