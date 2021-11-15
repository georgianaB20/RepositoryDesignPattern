using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1
{
    class MenuSearch : Menu
    {
        public MenuSearch(IAlbumRepository rep):base(rep)
        {
            Options = "\nMENU\n1. Get by artist\n2. Get by title\n3. Get by releasing year\n4. Get by genre\n5. Get by record label\n6. Not owned yet\n7. Get all albums\n0. Back\nOption: ";
        }

        public override void Show()
        {
            Console.WriteLine(SectionDelimiter);

            int option = int.Parse(ReadData(Options));
            IEnumerable<Album> list;
            string criteria;
            while (option != 0)
            {
                switch (option)
                {
                    case 0:
                        return;
                    case 1:
                        criteria = ReadData("\nArtist name: ");
                        list = Repository.GetByArtist(criteria);
                        new MenuListAlbums(Repository,list).Show();
                        break;
                    case 2:
                        criteria = ReadData("\nAlbum title: ");
                        list = Repository.GetByTitle(criteria);
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 3:
                        criteria = ReadData("\nReleasing year: ");
                        list = Repository.GetByYear(int.Parse(criteria));
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 4:
                        criteria = ReadData("\nAlbum genre: ");
                        list = Repository.GetByGenre(criteria);
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 5:
                        criteria = ReadData("\nRecord label: ");
                        list = Repository.GetByRecordLabel(criteria);
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 6:
                        list = Repository.GetNotOwned();
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 7:
                        list = Repository.GetAll();
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    default:
                        Console.WriteLine("Invalid menu option.");
                        break;
                }
                Console.WriteLine(SectionDelimiter);
                option = int.Parse(ReadData(Options));
            }
        }
    }
}
