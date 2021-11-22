using System;
using System.Collections.Generic;
using System.Linq;
using Repository1.Entities;
using Repository1.AlbumRepositories;
using System.Text;

namespace Repository1.Menu
{
    class MenuListAlbums : Menu
    {
        private IEnumerable<Album> Albums { get; set; }

        public MenuListAlbums(IAlbumRepository repository, IEnumerable<Album> albums) : base(repository)
        {
            Options = GetOptions("ListAlbums");
            Albums = albums;
        }

        public override void Show()
        {
            Print();
            var option = ReadNumber(Options, true);

            while (option != 0)
            {
                if (!IsValidIndex(option - 1)) Print(GetOptions("InvalidSong"));

                var album = Albums.ToList()[option-1];
                new MenuAlbum(album, Repository).Show();
                CheckIfDeleted(album);
                Print();
                option = ReadNumber(Options, true);
            }
        }

        private void CheckIfDeleted(Album album)
        {
            if (Repository.GetById(album.Id) == null)
            {
                Albums = Albums.Where(queryAlbum => album.Id != queryAlbum.Id).ToList();
            }
        }

        private bool IsValidIndex(int number) => number >= 0 && number < Albums.Count();

        private void Print()
        {
            if (!Albums.Any())
            {
                Print("No albums found for your search.");
                return;
            }

            var i = 1;
            var albumsToPrint = new StringBuilder();
            albumsToPrint.AppendLine(GetOptions("AlbumListHeader").Replace("\\t","\t"));
            foreach (var album in Albums)
            {
                albumsToPrint.AppendLine($"{i++}. {album}");
            }
            Print(albumsToPrint.ToString());
        }
    }
}
