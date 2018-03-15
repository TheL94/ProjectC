using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathToWork
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = InitApplication(Environment.SpecialFolder.Desktop);

            // passare il parh alla classe di lettura
            string[][] inputText = Reader.Read(path, ' ');

            for (int i = 0; i < inputText.Length; i++)
            {
                Console.WriteLine(inputText[i].ToString());
            }
            // prendere il ritorno del reader e passarlo al pathfinder

            // scrivere su nuovo file il ritorno del pathfinder formattato

            ExitApplication();
        }

        static string InitApplication(Environment.SpecialFolder _folderToLook)
        {
            Console.WriteLine("Insert File Name With Format :");
            string fileName = Console.ReadLine();

            string path = Environment.GetFolderPath(_folderToLook);
            path += "\\" + fileName;

            return path;
        }

        static void ExitApplication()
        {
            Console.WriteLine("Press ESC to terminate.");
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Escape)
                return;
        }
    }
}
