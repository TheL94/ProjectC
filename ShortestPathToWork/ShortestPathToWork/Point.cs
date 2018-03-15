using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathToWork
{
    public class Point
    {
        public Polygonal PolygonalOfAppartenence;
        public int X;
        public int Y;

        public Point() { }

        public Point(Polygonal _polygonalOfAppartenence)
        {
            PolygonalOfAppartenence = _polygonalOfAppartenence;
        }

        public Point(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }

        public Point(int _x, int _y, Polygonal _polygonalOfAppartenence)
        {
            X = _x;
            Y = _y;
            PolygonalOfAppartenence = _polygonalOfAppartenence;
        }
    }
}
