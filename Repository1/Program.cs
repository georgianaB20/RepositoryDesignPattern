using Repository1.AlbumRepositories;
using Repository1.Menu;
using System;

namespace Repository1
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new MenuWelcome();
            menu.Show();
        }
    }
}
