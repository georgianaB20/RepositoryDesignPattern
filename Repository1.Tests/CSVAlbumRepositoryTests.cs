using Repository1.AlbumRepositories;
using Xunit;
using Repository1.FileOperations;
using Repository1.Entities;
using System.IO;

namespace Repository1.Tests
{
    public class CSVAlbumRepositoryTests
    {

        private CSVAlbumRepository Repository;

        [Theory]
        [InlineData(@"../../../AlbumsTest.csv")]
        public void Constructor_GivenValidPath_InitializesListOfAlbums(string path) {
            Repository = new(path);
            var expected = new AlbumList(new AlbumFileOperation(path).Read());
            var actual = new AlbumList(Repository.GetAll());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"../../../AlbumsTest.csv")]
        public void Save(string path) {
            Repository = new(path);
            var expected = new AlbumList(Repository.GetAll());
            Repository.Save();

            var name = path.Substring(0,path.LastIndexOf('.'));
            var ext = Path.GetExtension(path);
            var fileName = $"{name}_Updated{ext}";
            Repository = new(fileName);
            var actual = new AlbumList(Repository.GetAll());

            Assert.Equal(expected, actual);
        }
    }
}
