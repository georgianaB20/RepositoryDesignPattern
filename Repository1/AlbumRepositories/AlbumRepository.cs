using System;
using System.Collections.Generic;
using System.Linq;
using Repository1.Entities;

namespace Repository1.AlbumRepositories
{
    
    public abstract class AlbumRepository : IAlbumRepository
    {

        protected List<Album> Albums { get; set; }
        public string Path { get; set; }
        protected int NextId { get; set; }
        public abstract bool Save();

        public AlbumRepository() { }

        public bool Delete(int id)
        {
            int beforeDeleteCount = Albums.Count();
            Albums = Albums.Where(album => album.Id != id).ToList();
            int afterDeleteCount = Albums.Count();
            return beforeDeleteCount != afterDeleteCount;
        }

        public IEnumerable<Album> GetAll()
        {
            return Albums;
        }

        public IEnumerable<Album> GetByArtist(string artistName)
        {
            return Albums.Where(album => album.Artist == artistName).ToList();
        }

        public IEnumerable<Album> GetByGenre(string genre)
        {
            return Albums.Where(album => album.Genre == genre).ToList();
        }

        public Album GetById(int id)
        {
            return Albums.Where(album => album.Id == id).FirstOrDefault();
        }

        public IEnumerable<Album> GetByTitle(string title)
        {
            return Albums.Where(album => album.Title == title).ToList();
        }

        public IEnumerable<Album> GetByYear(int year)
        {
            return Albums.Where(album => album.Year== year).ToList();
        }

        public IEnumerable<Album> GetOwned()
        {
            return Albums.Where(album => album.Owned == true).ToList();
        }

        public IEnumerable<Album> GetNotOwned()
        {
            return Albums.Where(album => album.Owned == false).ToList();
        }
        
        public IEnumerable<Album> GetByRecordLabel(string recordLabel)
        {
            return Albums.Where(album => album.RecordLabel == recordLabel).ToList();
        }

        public bool Insert(Album newAlbum)
        {
            newAlbum.Id = ++NextId;
            Albums.Add(newAlbum);
            return GetById(NextId - 1)!=null;
        }

        public bool Update(Album updatedAlbum)
        {
            var album = GetById(updatedAlbum.Id);
            if (album!=null) {
                Albums[Albums.IndexOf(album)] = updatedAlbum;
                return true;
            }
            return false;
            
        }

    }
}
