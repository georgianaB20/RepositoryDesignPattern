using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository1
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = new AlbumRepository(@"../../../CSV/Albums.csv");
            var menu = new MainMenu(rep);
            menu.Show();
        }
    }
}
