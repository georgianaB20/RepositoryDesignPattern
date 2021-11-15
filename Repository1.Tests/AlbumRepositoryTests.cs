using System;
using System.Collections.Generic;
using Xunit;

namespace Repository1.Tests
{
    public class AlbumRepositoryTests
    {
        private readonly AlbumRepository Repository=new(@"../../../AlbumsTest.csv");
       
        [Theory]
        [InlineData(1)]
        public void GetById_ShouldReturnAlbum(int id) {
            Album result = Repository.GetById(id);

            Assert.Equal(id, result.Id);
        }

        [Theory]
        [InlineData(45)]
        public void GetById_ShouldReturnNull(int id) {
            Album actual = Repository.GetById(id);

            Assert.Null(actual);
        }

        [Theory]
        [MemberData(nameof(AlbumTestData))]
        public void InsertNewAlbum_ShouldReturnTrue(Album album)
        {
            bool result = Repository.Insert(album);

            Assert.True(result);
        }

        public static IEnumerable<object[]> AlbumTestData()
        {
            yield return new object[] { new Album("Madonna", "New songs", 2001, "Pop", 40000, false, "Atlantic") };
            yield return new object[] { new Album("Michael Jackson", "Dangerous", 1997, "Pop", 3018372, true, "Best Record Label") };
        }

        [Theory]
        [InlineData(30)]
        [InlineData(57)]
        public void DeleteAlbum_ShouldReturnFalse(int albumId) 
        {
            bool actual = Repository.Delete(albumId);

            Assert.False(actual);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(1)]
        public void DeleteAlbum_ShouldReturnTrue(int albumId) 
        { 
            bool actual = Repository.Delete(albumId);

            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(AlbumTestData))]
        public void UpdateAlbum_ShouldReturnTrue(Album album) 
        {
            album.Id = 1;

            bool actual = Repository.Update(album);

            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(AlbumTestData))]
        public void UpdateAlbum_ShouldReturnFalse(Album album)
        {
            album.Id = -7;

            bool actual = Repository.Update(album);

            Assert.False(actual);
        }

        [Theory]
        [InlineData("The Neighbourhood")]
        [InlineData("Palaye Royale")]
        public void GetByArtist_ShouldReturnListOfAlbums(string expected)
        {
            IEnumerable<Album> list = Repository.GetByArtist(expected);
            string actual = ((List<Album>)list)[0].Artist;


            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("sdgsfsfs")]
        [InlineData("Not an artist")]
        public void GetByArtist_ShouldReturnEmptyList(string artist)
        {
            IEnumerable<Album> list = Repository.GetByArtist(artist);

            Assert.Empty(list);
        }

        [Theory]
        [InlineData("These Two Windows")]
        [InlineData("Exit")]
        public void GetByTitle_ShouldReturnListOfAlbums(string expected)
        {
            IEnumerable<Album> list = Repository.GetByTitle(expected);
            string actual = ((List<Album>)list)[0].Title;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Not an album")]
        [InlineData("tralala")]
        public void GetByTitle_ShouldReturnEmptyList(string title)
        {
            IEnumerable<Album> list = Repository.GetByTitle(title);

            Assert.Empty( list);
        }

        [Theory]
        [InlineData(2018)]
        [InlineData(2020)]
        public void GetByYear_ShouldReturnListOfAlbums(int expected)
        {
            IEnumerable<Album> list = Repository.GetByYear(expected);
            int actual = ((List<Album>)list)[0].Year;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(-37)]
        [InlineData(1809)]
        public void GetByYear_ShouldReturnEmptyList(int year)
        {
            IEnumerable<Album> list = Repository.GetByYear(year);

            Assert.Empty(list);
        }

        [Theory]
        [InlineData("Pop")]
        [InlineData("Rock")]
        public void GetByGenre_ShouldReturnListOfAlbums(string expected)
        {
            IEnumerable<Album> list = Repository.GetByGenre(expected);
            string actual = ((List<Album>)list)[0].Genre;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("not a genre")]
        [InlineData("tralala")]
        public void GetByGenre_ShouldReturnEmptyList(string genre)
        {
            IEnumerable<Album> list = Repository.GetByGenre(genre);

            Assert.Empty(list);
        }

        [Theory]
        [InlineData("Fueled by Ramen")]
        [InlineData("Free Space Records")]
        public void GetByRecordLabel_ShouldReturnListOfAlbums(string expected)
        {
            IEnumerable<Album> list = Repository.GetByRecordLabel(expected);
            string actual = ((List<Album>)list)[0].RecordLabel;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Not a record label")]
        [InlineData("A record label")]
        public void GetByRecordLabel_ShouldReturnEmptyList(string recordLabel)
        {
            IEnumerable<Album> list = Repository.GetByRecordLabel(recordLabel);

            Assert.Empty(list);
        }

        [Fact]
        public void GetOwned_ShouldReturnListOfOwnedAlbums()
        {
            IEnumerable<Album> list = Repository.GetOwned();
            bool actual = ((List<Album>)list)[0].Owned;

            Assert.True(actual);
        }

        [Fact]
        public void GetNotOwned_ShouldReturnListOfNotOwnedAlbums()
        {
            IEnumerable<Album> list = Repository.GetNotOwned();
            bool actual = ((List<Album>)list)[0].Owned;

            Assert.False(actual);
        }






    }
}
