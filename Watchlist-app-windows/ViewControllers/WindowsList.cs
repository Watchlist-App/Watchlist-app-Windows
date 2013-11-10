using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watchlist_app_windows.Views;


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
        private Amazon pag6;
        private Youtube pag7;
        private Registration pag8;
        private Login pag9;
        private WindowsList()
        {

            pag1 = new Window1();
            pag2 = new ProfileWindow();
            pag3 = new Watchlist();
            pag4 = new Favorites();
            pag5 = new Tickets();
            pag6 = new Amazon();
            pag7 = new Youtube();
            pag8 = new Registration();
            pag9 = new Login();
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

        public Amazon page6
        {
            get { return pag6; }
        }

        public Youtube page7
        {
            get { return pag7; }
        }

        public Registration page8
        {
            get { return pag8; }
        }

        public Login page9
        {
            get { return pag9; }
        }
        
    }
}

