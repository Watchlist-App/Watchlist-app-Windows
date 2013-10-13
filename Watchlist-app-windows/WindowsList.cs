using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchlist_app_windows
{
    class WindowsList
    {
        private static WindowsList pagelist = null;
        private Window1 pag1;
        private WindowsList()
        {

            pag1 = new Window1();
        }
        public static WindowsList GetInstance()
        {
            if (pagelist == null)
                pagelist = new WindowsList();
            return pagelist;
        }
        public Window1 page1
        {
            get { return pag1; }
        }
    }
}

