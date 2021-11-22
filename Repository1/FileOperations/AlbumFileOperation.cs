using Repository1.Entities;
using Repository1.AlbumRepositories;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Repository1.FileOperations
{
    public class AlbumFileOperation
    {
        public string FilePath { get; set; }
        public AlbumFileOperation(string path) => FilePath = path;

        public IEnumerable<Album> Read()
        {
            var extension = Path.GetExtension(FilePath);
            return extension switch
            {
                ".csv" => ReadCSV(),
                ".xml" => ReadXML(),
                _ => new List<Album>(),
            };
        }

        public void Write(IEnumerable<Album> albums)
        {
            var extension = Path.GetExtension(FilePath);
            switch (extension)
            {
                case ".csv":
                    WriteCSV(albums);
                    break;
                case ".xml":
                    WriteXML(albums);
                    break;
                default:
                    return;
            }
        }

        private static string GetValue(string[] values, string colName, List<string> columns) => Album.GetStringValue(values[columns.IndexOf(colName)]);

        private IEnumerable<Album> ReadCSV()
        {
            var albums = new List<Album>();
            if (File.Exists(FilePath))
            {
                using var sr = File.OpenText(FilePath); string line;
                var keys = new List<string>(sr.ReadLine().Split(','));
                while ((line = sr.ReadLine()) != null)
                {
                    string[] values = line.Split(",");

                    int id = int.Parse(GetValue(values, "Id", keys));
                    string artist = GetValue(values, "Artist", keys);
                    string title = GetValue(values, "Title", keys);
                    int year = int.Parse(GetValue(values, "Year", keys));
                    string genre = GetValue(values, "Genre", keys);
                    int sales = int.Parse(GetValue(values, "Sales", keys));
                    bool owned = GetValue(values, "Owned", keys) == "Yes" ? true : false;
                    string recordLabel = GetValue(values, "Record Label", keys);

                    albums.Add(new Album(id, artist, title, year, genre, sales, owned, recordLabel));
                }
            }
            return albums;
        }

        private IEnumerable<Album> ReadXML()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    var stream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
                    var serializer = new XmlSerializer(typeof(AlbumList));
                    AlbumList list = (AlbumList)serializer.Deserialize(stream);
                    return list.Albums;
                }
                catch
                {
                    return new List<Album>();
                }
            }
            else return new List<Album>();
        }

        private void WriteCSV(IEnumerable<Album> albums)
        {
            using (var outputFile = new StreamWriter(FilePath))
            {
                outputFile.WriteLine("Id,Artist,Title,Year,Genre,Sales,Record Label,Owned");
                foreach (var album in albums)
                {
                    outputFile.WriteLine(album.ToCSVString());
                }
            }
        }

        private void WriteXML(IEnumerable<Album> albums)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(AlbumList));
                var stream = new FileStream(FilePath, FileMode.Create);
                serializer.Serialize(stream, new AlbumList(albums));
                stream.Close();
            }
            catch { }
        }
    }
}
