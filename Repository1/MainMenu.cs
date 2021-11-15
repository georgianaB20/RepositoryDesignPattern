using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1
{
    class MainMenu : Menu
    {
        public MainMenu(AlbumRepository rep):base(rep)
        {
            Options = "\nMENU\n1.Search albums\n2.Add album\n3.Save\n4.My albums\n0.Exit\nOption:";
        }

        public override void Show()
        {
            int number = int.Parse(ReadData(Options));
            while (number != 0)
            {
                switch (number)
                {
                    case 0:
                        return;
                    case 1:
                        new MenuSearch(Repository).Show();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Repository.Save();
                        Console.WriteLine("Changes saved");
                        break;
                    case 4:
                        new MenuListAlbums(Repository, Repository.GetOwned()).Show() ;
                        break;
                    default:
                        Console.WriteLine("Invalid menu option.");
                        break;
                }
                number = int.Parse(ReadData(Options));
            }
        }

        public void Add()
        {
            Console.WriteLine(SectionDelimiter);
            string artist = ReadData("\nLet's add a new album!\nInsert artist: ");
            string title = ReadData("Insert album title: ");
            int year = int.Parse(ReadData("Insert year of release: "));
            string genre = ReadData("Insert genres separated by space: ");
            int sales = int.Parse(ReadData("Insert number of sales: "));
            string recLab = ReadData("Insert record label: ");
            string ownedStr = ReadData("Do you have this album in your collection? (Yes/No): ");
            bool owned = ownedStr == "Yes" ? true : false;

            bool resp = Repository.Insert(new Album(artist, title, year, genre, sales, owned, recLab));
            Console.WriteLine(resp == true ? "Great! The album was added!" : "Album not added.");
            Console.WriteLine(SectionDelimiter);
        }

    }
}
