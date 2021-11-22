using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Repository1.Entities
{
    [XmlRoot("Albums")]
    [XmlInclude(typeof(Album))]
    public class AlbumList
    {
        [XmlElement("Album")]
        public List<Album> Albums { get; set; }

        public AlbumList() { }
        public AlbumList(IEnumerable<Album> albums) => Albums = (List<Album>)albums;

        public override bool Equals(object albumsList) {
            var albumsList2 = ((AlbumList)albumsList).Albums;

            if (!Albums.Any() && !albumsList2.Any()) return true;
            if (!Albums.Any() || !albumsList2.Any()) return false;
            foreach (var album in albumsList2) {
                if (Albums.IndexOf(album) == -1)
                    return false;
            }
            return true;
        }
    }
}
