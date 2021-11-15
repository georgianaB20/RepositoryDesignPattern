using System.Collections.Generic;

namespace Repository1
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();
        Album GetById(int id);
        IEnumerable<Album> GetByTitle(string title);
        IEnumerable<Album> GetByArtist(string artistName);
        IEnumerable<Album> GetByGenre(string genre);
        IEnumerable<Album> GetByYear(int year);
        IEnumerable<Album> GetOwned();
        IEnumerable<Album> GetNotOwned();
        IEnumerable<Album> GetByRecordLabel(string recordLabel);
        bool Insert(Album newAlbum);
        bool Update(Album updatedAlbum);
        bool Delete(int id);
        bool Save();
    }
}
