using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository1.AlbumRepositories;

namespace Repository1.Menu
{
    class MenuWelcome : Menu
    {
        private string fileNames;
        public MenuWelcome()
        {
            GetFileNames();
            Options = GetOptions("Welcome").Replace("{fileNames}",fileNames);
        }

        private void GetFileNames()
        {
            string[] fileEntries = Directory.GetFiles("../../../CSV");
            string fileName;
            foreach (var file in fileEntries)
            {
                fileName = file.Substring(file.LastIndexOf('\\') + 1);
                fileNames += $"\n {fileName}";
            }

            fileEntries = Directory.GetFiles("../../../XML");
            foreach (var file in fileEntries)
            {
                fileName = file.Substring(file.LastIndexOf('\\') + 1);
                fileNames += $"\n {fileName}";
            }

        }

        public override void Show()
        {
            bool isValid = false;
            string fileName;
            string path;
            AlbumRepository repository;
            Menu menu;

            while (!isValid) {
                fileName = ReadData(Options,true);
                var extension = Path.GetExtension(fileName);

                switch (extension)
                {
                    case ".csv":
                        path = "../../../CSV/" + fileName;
                        repository = new CSVAlbumRepository(path);
                        menu = new MainMenu(repository);
                        isValid = true;
                        menu.Show();
                        break;
                    case ".xml":
                        path = "../../../XML/" + fileName;
                        repository = new XMLAlbumRepository(path);
                        menu = new MainMenu(repository);
                        isValid = true;
                        menu.Show();
                        break;
                    default:
                        Console.WriteLine(GetOptions("InvalidFile"));
                        break;
                }
            }
        }

    }
}
