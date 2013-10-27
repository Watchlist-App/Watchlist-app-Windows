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
        private Watchlist pag3;
        private Favorites pag4;
        private Tickets pag5;
        private WindowsList()
        {

            pag1 = new Window1();
            pag2 = new ProfileWindow();
            pag3 = new Watchlist();
            pag4 = new Favorites();
            pag5 = new Tickets();
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

        public Watchlist page3
        {
            get { return pag3; }
        }

        public Favorites page4
        {
            get { return pag4; }
        }

        public Tickets page5
        {
            get { return pag5; }
        }
    }
}

