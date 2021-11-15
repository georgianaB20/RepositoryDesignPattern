using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository1
{
    public class AlbumRepository : IAlbumRepository
    {
        private IEnumerable<Album> albums { get; set; } = new List<Album>();
        public string Path { get; set; }

        private int nextId { get; set; }

        public AlbumRepository(string path)
        {
            albums = new List<Album>();
            albums = new AlbumFileOperation(path).Read();
            Path = path; //@"../../../CSV/Albums.csv";
            nextId = albums.Select(album => album.Id).Max();
        }

        public bool Delete(int id)
        {
            int count1 = albums.Count();
            albums = albums.Where(album => album.Id != id);
            int count2 = albums.Count();
            return count1 != count2;          
        }

        public IEnumerable<Album> GetAll()
        {
            return albums;
        }

        public IEnumerable<Album> GetByArtist(string artistName)
        {
            return albums.Where(album => album.Artist == artistName).ToList();
        }

        public IEnumerable<Album> GetByGenre(string genre)
        {
            return albums.Where(album => album.Genre == genre).ToList();
        }

        public Album GetById(int id)
        {
            return albums.Where(album => album.Id == id).FirstOrDefault();
        }

        public IEnumerable<Album> GetByTitle(string title)
        {
            return albums.Where(album => album.Title == title).ToList();
        }

        public IEnumerable<Album> GetByYear(int year)
        {
            return albums.Where(album => album.Year== year).ToList();
        }

        public IEnumerable<Album> GetOwned()
        {
            return albums.Where(album => album.Owned == true).ToList();
        }

        public IEnumerable<Album> GetNotOwned()
        {
            return albums.Where(album => album.Owned == false).ToList();
        }
        
        public IEnumerable<Album> GetByRecordLabel(string recordLabel)
        {
            return albums.Where(album => album.RecordLabel == recordLabel).ToList();
        }

        public bool Insert(Album newAlbum)
        {
            newAlbum.Id = ++nextId;
            ((List<Album>)albums).Add(newAlbum);
            return GetById(nextId - 1)!=null;
        }

        public bool Save()
        {
            string path = $"{Path.Substring(0, Path.LastIndexOf('.'))}_Updated";
            path += Path.Substring(Path.LastIndexOf("."));
            new AlbumFileOperation(path).Write(albums);
            return true;
        }

        public bool Update(Album updatedAlbum)
        {
            var album = GetById(updatedAlbum.Id);
            if (album!=null) {
                var albums2 = albums.ToList();
                albums2[albums2.IndexOf(album)] = updatedAlbum;
                albums = albums2;
                return true;
            }
            return false;
            
        }

    }
}
