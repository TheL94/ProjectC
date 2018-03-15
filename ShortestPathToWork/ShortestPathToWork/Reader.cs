using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ShortestPathToWork
{
    public static class Reader
    {
        static string line;
        static StreamReader fileToRead;
        static char separator;

        public static string[][] Read(string _path, char _separator)
        {
            fileToRead = new StreamReader(_path);
            separator = _separator;
            List<string[]> fileLines = new List<string[]>();
            
            while ((line = fileToRead.ReadLine()) != null)
            {
                string[] separatedLine = line.Split(separator);
                fileLines.Add(separatedLine);
            }

            string[][] textToReturn = new string[fileLines.Count][];

            for (int i = 0; i < fileLines.Count; i++)
            {
                textToReturn[i] = fileLines[i];
            }

            return textToReturn;
        }
    }
}
