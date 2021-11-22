

using System.Xml.Serialization;

namespace Repository1.Entities
{
    [XmlType("Album")]
    public class Album
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Artist")]
        public string Artist { get; set; }

        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Year")]
        public int Year { get; set; }

        [XmlElement("Genre")]
        public string Genre { get; set; }

        [XmlElement("Sales")]
        public int Sales { get; set; }

        [XmlElement("Owned")]
        public bool Owned { get; set; }

        [XmlElement("RecordLabel")]
        public string RecordLabel { get; set; }

        public Album() { }

        public Album(string artist,string title,int year,string genre,int sales,bool owned,string recordLabel)
        {
            Artist = artist;
            Title = title;
            Year = year;
            Genre = genre;
            Sales = sales;
            Owned = owned;
            RecordLabel = recordLabel;
        }

        public Album(int id,string artist, string title, int year, string genre, int sales, bool owned, string recordLabel)
        {
            Id = id;
            Artist = artist;
            Title = title;
            Year = year;
            Genre = genre;
            Sales = sales;
            Owned = owned;
            RecordLabel = recordLabel;
        }

        public override string ToString()
        {
            string owned = Owned == true ? "Yes" : "No";
            return $"{Artist} | {Title} | {Year} | {Genre} | {Sales} | {RecordLabel} | {owned}";
        }

        public string ToBlockString() {
            string owned = Owned == true ? "Yes" : "No";
            return $"\nArtist: {Artist}\nTitle: {Title}\nYear: {Year}\nGenres: {Genre}\nSales: {Sales}\nRecord label: {RecordLabel}\nOwned: {owned}";
        }

        public static string GetStringValue(string str) => string.IsNullOrWhiteSpace(str) ? null : str.Trim();

        public string ToCSVString() {
            string owned = Owned == true ? "Yes" : "No";
            return $"{Id},{GetStringValue(Artist)},{GetStringValue(Title)},{Year},{GetStringValue(Genre)},{Sales},{GetStringValue(RecordLabel)},{owned}";
        }

        public override bool Equals(object obj)
        {
            var album = (Album)obj;
            return (album.Id == Id && album.Title == Title &&
                album.Artist == Artist && album.Year==Year &&
                album.Genre==Genre && album.Sales==Sales &&
                album.Owned==Owned && album.RecordLabel==RecordLabel);
        }
    }
}
