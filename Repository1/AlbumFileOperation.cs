using System;
using System.Collections.Generic;
using System.IO;

namespace Repository1
{
    class AlbumFileOperation
    {
        public string FilePath { get; set; }
        public AlbumFileOperation(string path) => FilePath = path;

        public IEnumerable<Album> Read()
        {
            string extension = Path.GetExtension(FilePath);
            return extension switch
            {
                ".csv" => ReadCSV(),
                ".xml" => ReadXML(),
                _ => new List<Album>(),
            };
        }

        public void Write(IEnumerable<Album> albums)
        {
            string extension = Path.GetExtension(FilePath);
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
                using StreamReader sr = File.OpenText(FilePath); string line;
                List<string> keys = new List<string>(sr.ReadLine().Split(','));
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
            var albums = new List<Album>();
            return albums;
        }

        private void WriteCSV(IEnumerable<Album> albums)
        {
            using (var outputFile = new StreamWriter(FilePath))
            {
                outputFile.WriteLine("Id,Artist,Title,Year,Genre,Sales,Owned,Record Label");
                foreach (var album in albums)
                {
                    outputFile.WriteLine(album.ToCSVString());
                }
            }
        }

        private void WriteXML(IEnumerable<Album> albums)
        {
        }
    }
}
