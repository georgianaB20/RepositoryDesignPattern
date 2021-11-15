using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository1
{
    public class Album
    {
        public int Id { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public int Sales { get; set; }
        public bool Owned { get; set; }
        public string RecordLabel { get; set; }

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
    }
}
