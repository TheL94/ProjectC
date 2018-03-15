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
                    returnData.StartPoint = new Point();
                    returnData.StartPoint.X = Int32.Parse(_arrayToParse[i][0]);
                    returnData.StartPoint.Y = Int32.Parse(_arrayToParse[i][1]);

                    returnData.ObjectivePoint = new Point();
                    returnData.ObjectivePoint.X = Int32.Parse(_arrayToParse[i][2]);
                    returnData.ObjectivePoint.Y = Int32.Parse(_arrayToParse[i][3]);
                }
                else if(i == 1)
                {
                    int numberOfObstacles = Int32.Parse(_arrayToParse[i][0]);
                    returnData.Obstacles = new Polygonal[numberOfObstacles];
                }
                else
                {
                    for (int j = 0; j < _arrayToParse[i].Length; j++)
                    {
                        returnData.Obstacles[i - 2] = new Polygonal();
                        returnData.Obstacles[i - 2].Vertexes = new Point[3];

                        returnData.Obstacles[i - 2].Vertexes[0] = new Point(returnData.Obstacles[i - 2]);
                        returnData.Obstacles[i - 2].Vertexes[0].X = Int32.Parse(_arrayToParse[i][0]);
                        returnData.Obstacles[i - 2].Vertexes[0].Y = Int32.Parse(_arrayToParse[i][1]);

                        returnData.Obstacles[i - 2].Vertexes[1] = new Point(returnData.Obstacles[i - 2]);
                        returnData.Obstacles[i - 2].Vertexes[1].X = Int32.Parse(_arrayToParse[i][2]);
                        returnData.Obstacles[i - 2].Vertexes[1].Y = Int32.Parse(_arrayToParse[i][3]);

                        returnData.Obstacles[i - 2].Vertexes[2] = new Point(returnData.Obstacles[i - 2]);
                        returnData.Obstacles[i - 2].Vertexes[2].X = Int32.Parse(_arrayToParse[i][4]);
                        returnData.Obstacles[i - 2].Vertexes[2].Y = Int32.Parse(_arrayToParse[i][5]);
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
        public Point StartPoint;
        public Point ObjectivePoint;
        public Polygonal[] Obstacles;
    }
}
