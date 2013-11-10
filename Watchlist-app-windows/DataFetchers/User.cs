using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Watchlist_app_windows.DataFetchers
{

    public class UsersList
    {

        public List<User> results { get; set; }    

    }
    
    public class User
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        public string email { get; set; }
        
        public ObservableCollection<User> userCall = new ObservableCollection<User>();
    }
}
