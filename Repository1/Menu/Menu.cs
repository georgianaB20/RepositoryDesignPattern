using System;
using System.Collections.Generic;
using System.IO;
using Repository1.AlbumRepositories;

namespace Repository1.Menu
{
    public abstract class Menu
    {
        protected static Dictionary<string, string> Storage { get; set; }
        public string Options { get; set; }
        public static IAlbumRepository Repository { get; set; }

        public static string SectionDelimiter = "------------------------------------------------------------------------------------------";
        public Menu(IAlbumRepository repository) => Repository = repository;

        public Menu() {}

        static Menu() {
            Storage = new Dictionary<string, string>();
            using var sr = File.OpenText("../../../Menu/MenuText.txt"); string line, key, value;
            while ((line = sr.ReadLine()) != null)
            {
                key = line.Substring(0, line.IndexOf("="));
                value = line.Substring(line.IndexOf("=") + 1).Replace("\\n", System.Environment.NewLine);
                Storage.Add(key, value);
            }
        }

        public static string GetOptions(string key) => Storage.GetValueOrDefault(key);

        public abstract void Show();

        public static string ReadData(string toPrint,bool addDelimiter)
        {
            Console.Write(toPrint);
            string data = Console.ReadLine();
            
            if (addDelimiter)
            {
                Console.WriteLine(SectionDelimiter);
            }
            
            return data;
        }

        public static int ReadNumber(string toPrint,bool addDelimiter) {
            Console.Write(toPrint);
            int number;
            bool succes = int.TryParse(Console.ReadLine(), out number);
            number = !succes ? -1 : number;

            if (addDelimiter)
            {
                Console.WriteLine(SectionDelimiter);
            }

            return number;           
        }

        public static void Print(string toPrint) {
            Console.WriteLine(toPrint);
            Console.WriteLine(SectionDelimiter);
        }
    }
}
