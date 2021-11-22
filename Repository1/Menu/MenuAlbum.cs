using System;
using Repository1.Entities;
using Repository1.AlbumRepositories;
using System.Collections.Generic;

namespace Repository1.Menu
{
    class MenuAlbum : Menu
    {
        private Album Album { get; set; }

        public MenuAlbum(Album a,IAlbumRepository repository):base(repository)
        {
            Album = a;
            Options = GetOptions();
        }

        private string GetOptions() {
            string owned = Album.Owned == true ? GetOptions("RemoveOwned") : GetOptions("AddOwned");
            return GetOptions("Album").Replace("{owned}", owned);
        }

        public override void Show()
        {
            Print();
            var option = ReadNumber(Options,true);
            while (option != 0)
            {
                switch (option)
                {
                    case 1:
                        string artist = ReadData(GetOptions("InsertArtist"),true);
                        Album.Artist = artist;
                        break;
                    case 2:
                        string title = ReadData(GetOptions("InsertTitle"), true);
                        Album.Title = title;
                        break;
                    case 3:
                        int year = ReadNumber(GetOptions("InsertYear"), true);
                        Album.Year = year;
                        break;
                    case 4:
                        string recordLabel = ReadData(GetOptions("InsertRecordLabel"), true);
                        Album.RecordLabel = recordLabel;
                        break;
                    case 5:
                        string genre = ReadData(GetOptions("InsertGenre"), true);
                        Album.Genre = genre;
                        break;
                    case 6:
                        Album.Owned = !Album.Owned;
                        break;
                    case 7:
                        Repository.Delete(Album.Id);
                        Print(GetOptions("AlbumDeleteSuccess"));
                        return;
                    case 8:
                        Repository.Update(Album);
                        Print(GetOptions("AlbumUpdated"));
                        return;
                    case 0:
                        return;
                    default:
                        Print(GetOptions("InvalidOption"));
                        break;
                }

                Print();
                option = ReadNumber(Options,true);
            }
        }

        private void Print() {
            Options = GetOptions();
            Print(Album.ToBlockString());
        }

    }
}
