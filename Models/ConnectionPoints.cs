using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Models
{
    public class ConnectionPoints
    {
        public Point Point1 { get; private set; }

        public Point Point2 { get; private set; }


        public ConnectionPoints(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }
    }
}
