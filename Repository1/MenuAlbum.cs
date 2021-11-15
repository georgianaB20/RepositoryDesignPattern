using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1
{
    class MenuAlbum : Menu
    {
        private Album Album { get; set; }

        public MenuAlbum(Album a,IAlbumRepository rep):base(rep)
        {
            Album = a;
            Options = GetOptions();
        }

        private string GetOptions() {
            string owned = Album.Owned == true ? "Remove from owned" : "Add to owned";
            return $"\nMENU\n1.Update artist\n2.Update title\n3.Update year\n4.Update record label\n5.Update genre\n6.{owned}\n7.Delete album\n0.Back\nOption: ";
        }

        public override void Show()
        {
            Print();
            int option = int.Parse(ReadData(Options));
            while (option != 0)
            {
                switch (option)
                {
                    case 1:
                        string artist = ReadData("Insert artist:");
                        Album.Artist = artist;
                        break;
                    case 2:
                        string title = ReadData("Insert title:");
                        Album.Title = title;
                        break;
                    case 3:
                        int year = int.Parse(ReadData("Insert year:"));
                        Album.Year = year;
                        break;
                    case 4:
                        string recordLabel = ReadData("Insert record label:");
                        Album.RecordLabel = recordLabel;
                        break;
                    case 5:
                        string genre = ReadData("Insert genre:");
                        Album.Genre = genre;
                        break;
                    case 6:
                        Album.Owned = !Album.Owned;
                        break;
                    case 7:
                        Repository.Delete(Album.Id);
                        Console.WriteLine("Album deleted!");
                        return;
                    case 0:
                        Repository.Update(Album);
                        Console.WriteLine("Album updated");
                        return;
                    default:
                        break;
                }

                Print();
                option = int.Parse(ReadData(Options));
            }
            Repository.Update(Album);
        }

        private void Print() {
            Options = GetOptions();
            Console.WriteLine(SectionDelimiter);
            Console.WriteLine(Album.ToBlockString());
            Console.WriteLine(SectionDelimiter);
        }

    }
}
