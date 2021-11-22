using System;
using System.Collections.Generic;
using System.Linq;
using Repository1.Entities;
using Repository1.FileOperations;

namespace Repository1.AlbumRepositories
{
    public class XMLAlbumRepository : AlbumRepository
    {
        public XMLAlbumRepository() { }
        public XMLAlbumRepository(string path)
        {
            Albums = (List<Album>)new AlbumFileOperation(path).Read();
            Path = path; 
            try
            {
                NextId = Albums.Select(album => album.Id).Max();
            }
            catch (InvalidOperationException)
            {
                NextId = 0;
            }
        }

        public override bool Save()
        {
            var name = Path.Substring(0, Path.LastIndexOf('.'));
            var path = $"{name}_Updated";
            path += Path.Substring(Path.LastIndexOf("."));
            new AlbumFileOperation(path).Write(Albums);
            return true;
        }
    }
}
