using System;
using System.Collections.Generic;
using Repository1.Entities;
using Repository1.AlbumRepositories;

namespace Repository1.Menu
{
    class MenuSearch : Menu
    {
        public MenuSearch(IAlbumRepository repository):base(repository)
        {
            Options = GetOptions("Search");
        }

        public override void Show()
        {
            IEnumerable<Album> list;
            string criteria;
            var option = ReadNumber(Options,true);

            while (option != 0)
            {
                switch (option)
                {
                    case 0:
                        return;
                    case 1:
                        criteria = ReadData($"\n{GetOptions("InsertArtist")}",true);
                        list = Repository.GetByArtist(criteria);

                        new MenuListAlbums(Repository,list).Show();
                        break;
                    case 2:
                        criteria = ReadData($"\n{GetOptions("InsertTitle")}",true);
                        list = Repository.GetByTitle(criteria);
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 3:
                        int year = ReadNumber($"\n{GetOptions("InsertYear")}",true);
                        list = Repository.GetByYear(year);
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 4:
                        criteria = ReadData($"\n{GetOptions("InsertGenre")}",true);
                        list = Repository.GetByGenre(criteria);
                        new MenuListAlbums(Repository, list).Show();
                        break;
                    case 5:
                        criteria = ReadData($"\n{GetOptions("InsertRecordLabel")}", true);
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
                        Print(GetOptions("InvalidOption"));
                        break;
                }
                option = ReadNumber(Options,true);
            }
        }
    }
}
