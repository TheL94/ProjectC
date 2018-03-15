using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathToWork
{
    class Program
    {
        static string EnvironmentPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop); } }

        static void Main(string[] args)
        {
            Console.WriteLine("Insert File Name With Format :");

            string fileName = Console.ReadLine();
            string path = EnvironmentPath + "\\" + fileName; ;

            string[][] inputText = FileManager.Read(path, ' ');

            InputParsed dataForPathfinder = Parser.ParseInputData(inputText);

            string[][] outputData = Parser.ParseOutputData();

            FileManager.Write(outputData, EnvironmentPath + "\\" + "output.txt", ' ');

            Console.WriteLine("Press ESC to terminate.");

            ConsoleKeyInfo pressedKey = Console.ReadKey();
            if (pressedKey.Key == ConsoleKey.Escape)
                return;
        }
    }
}
