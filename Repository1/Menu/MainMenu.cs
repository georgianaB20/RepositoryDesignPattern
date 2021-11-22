using System;
using System.Collections.Generic;
using Repository1.AlbumRepositories;
using Repository1.Entities;

namespace Repository1.Menu
{
    class MainMenu : Menu
    {
        public MainMenu(AlbumRepository repository):base(repository)
        {
            Options = GetOptions("Main");
        }

        public override void Show()
        {
            var option = ReadNumber(Options,true);
            while (option != 0)
            {
                switch (option)
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
                        Print("Changes saved");
                        break;
                    case 4:
                        new MenuListAlbums(Repository, Repository.GetOwned()).Show() ;
                        break;
                    default:
                        Print(GetOptions("InvalidOption"));
                        break;
                }
                option = ReadNumber(Options,true);
            }
        }
        
        public void Add()
        {
            var artist = ReadData($"\n{GetOptions("AlbumAddGreetings")} \n{GetOptions("InsertArtist")}",false);
            var title = ReadData(GetOptions("InsertTitle"),false);
            var year = ReadNumber(GetOptions("InsertYear"),false);
            var genre = ReadData(GetOptions("InsertGenres"),false);
            var sales = ReadNumber(GetOptions("InsertSales"),false);
            var recordLabel = ReadData(GetOptions("InsertRecordLabel"),false);
            var ownedStr = ReadData(GetOptions("InsertOwned"),false);
            var owned = ownedStr == "Yes" ? true : false;

            bool resp = Repository.Insert(new Album(artist, title, year, genre, sales, owned, recordLabel));
            
            Console.WriteLine(SectionDelimiter);
            Console.WriteLine(resp == true ? $"\n{GetOptions("AlbumAddSuccess")}" : $"\n{GetOptions("AlbumAddFailed")}");
            Console.WriteLine(SectionDelimiter);
        }

    }
}
