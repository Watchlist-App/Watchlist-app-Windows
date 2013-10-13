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
        private ProfileWindow pag2;
        private WindowsList()
        {

            pag1 = new Window1();
            pag2 = new ProfileWindow();
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

        public ProfileWindow page2
        {
            get { return pag2; }
        }
    }
}

