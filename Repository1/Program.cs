using Repository1.AlbumRepositories;
using Repository1.Menu;
using System;

namespace Repository1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var rep = new CSVAlbumRepository(@"../../../CSV/Albums.csv");
            //var xmlRep = new XMLAlbumRepository(@"../../../XML/Albums2.xml");
            //Console.WriteLine(xmlRep.GetById(1).ToString());
            //xmlRep.Save();
            //Console.WriteLine("Done");
            var menu = new MenuWelcome();
            menu.Show();
        }
    }
}
