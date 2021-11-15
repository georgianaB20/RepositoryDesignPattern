using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1
{
    class MenuListAlbums : Menu
    {
        private IEnumerable<Album> Albums { get; set; }

        public MenuListAlbums(IAlbumRepository rep,IEnumerable<Album> albums):base(rep)
        {
            Options = "\nSelect album by inserting the position(e.g: 1,2,3) or go back by pressing 0.\nOption: ";
            Albums = albums;
        }

        public override void Show()
        {
            Print();

            int option = int.Parse(ReadData(Options));
            while (option != 0)
            {
                if (IsValidIndex(option-1))
                {
                    var albums2 = Albums.ToList();
                    new MenuAlbum(albums2[option - 1], Repository).Show();
                }
                else
                {
                    Console.WriteLine("Invalid song position.");
                }
                Print();
                option = int.Parse(ReadData(Options));
            }
        }

        private bool IsValidIndex(int number) => number >= 0 && number < Albums.Count();

        private void Print()
        {
            int i = 1;
            Console.WriteLine(SectionDelimiter);
            Console.WriteLine("\t Artist \t Title \t Year \t Genre \t Sales \t Record Label \t Owned");
            foreach (var album in Albums)
            {
                Console.WriteLine($"{i++}. {album}");
            }
            Console.WriteLine(SectionDelimiter);
        }
    }
}
