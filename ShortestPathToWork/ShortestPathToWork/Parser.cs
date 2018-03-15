using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathToWork
{
    public static class Parser
    {
        public static InputParsed ParseInputData(string[][] _arrayToParse)
        {
            InputParsed returnData = new InputParsed();

            for (int i = 0; i < _arrayToParse.Length; i++)
            {
                if(i == 0)
                {
                    returnData.startPoint = new Point();

                    returnData.startPoint.X = Int32.Parse(_arrayToParse[i][0]);
                    returnData.startPoint.X = Int32.Parse(_arrayToParse[i][1]);

                    returnData.startPoint.X = Int32.Parse(_arrayToParse[i][2]);
                    returnData.startPoint.X = Int32.Parse(_arrayToParse[i][3]);
                }
                else if(i == 1)
                {
                    int numberOfObstacles = Int32.Parse(_arrayToParse[i][0]);
                    returnData.obstacles = new Polygonal[numberOfObstacles];
                }
                else
                {
                    for (int j = 0; j < _arrayToParse[j].Length; j++)
                    {
                        returnData.obstacles[i - 2] = new Polygonal();
                        returnData.obstacles[i - 2].Vertexes = new Point[3];

                        returnData.obstacles[i - 2].Vertexes[0].X = Int32.Parse(_arrayToParse[i][0]);
                        returnData.obstacles[i - 2].Vertexes[0].Y = Int32.Parse(_arrayToParse[i][1]);

                        returnData.obstacles[i - 2].Vertexes[1].X = Int32.Parse(_arrayToParse[i][2]);
                        returnData.obstacles[i - 2].Vertexes[2].Y = Int32.Parse(_arrayToParse[i][3]);

                        returnData.obstacles[i - 2].Vertexes[3].X = Int32.Parse(_arrayToParse[i][4]);
                        returnData.obstacles[i - 2].Vertexes[3].Y = Int32.Parse(_arrayToParse[i][5]);
                    }
                }
            }

            return returnData;
        }

        public static string[][] ParseOutputData()
        {
            return null;
        }
    }

    public struct InputParsed
    {
        public Point startPoint;
        public Point objectivePoint;
        public Polygonal[] obstacles;
    }
}
