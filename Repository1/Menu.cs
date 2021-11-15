using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1
{
    public abstract class Menu
    {
        public string Options { get; set; }
        public static IAlbumRepository Repository { get; set; }
        public static string SectionDelimiter = "------------------------------------------------------------------------------------------";
        public Menu(IAlbumRepository rep) => Repository = rep;
        
        public abstract void Show();

        public static string ReadData(string toPrint)
        {
            Console.Write(toPrint);
            return Console.ReadLine();
        }
    }
}
