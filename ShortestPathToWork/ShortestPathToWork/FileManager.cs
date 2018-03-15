using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestPathToWork
{
    public static class FileManager
    {
        public static string[][] Read(string _path, char _separator)
        {
            StreamReader fileToRead = new StreamReader(_path);
            char separator = _separator;
            List<string[]> fileLines = new List<string[]>();
            string line;

            while ((line = fileToRead.ReadLine()) != null)
            {
                string[] separatedLine = line.Split(separator);
                fileLines.Add(separatedLine);
            }
            fileToRead.Close();

            string[][] textToReturn = new string[fileLines.Count][];

            for (int i = 0; i < fileLines.Count; i++)
            {
                textToReturn[i] = fileLines[i];
            }

            return textToReturn;
        }

        public static void Write(string[][] _output, string _path, char _separator)
        {
            char separator = _separator;
            StreamWriter writer;

            if (!File.Exists(_path))
                writer = File.CreateText(_path);
            else
                writer = new StreamWriter(_path);

            for (int i = 0; i < _output.Length; i++)
            {
                for (int j = 0; j < _output[i].Length; j++)
                {
                    writer.Write(_output[i][j]);
                    if (j < _output[i].Length - 1)
                        writer.Write(_separator);
                }
                writer.Write(writer.NewLine);            
            }
            writer.Close();
        }
    }
}
