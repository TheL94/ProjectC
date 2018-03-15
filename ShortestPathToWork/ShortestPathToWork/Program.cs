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

            string[][] inputText = Reader.Read(path, ' ');

            // passare il parh alla classe di lettura
            InputParsed dataForPathfinder = Parser.ParseInputData(inputText);

            // prendere il ritorno del reader e passarlo al parser
            // passare il ritorno del parser al pathfidner
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
