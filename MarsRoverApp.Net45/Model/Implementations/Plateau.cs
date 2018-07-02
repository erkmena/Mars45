using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverApp.Model
{
    public class Plateau
    {
        public int XAxisLength { get; set; }

        public int YAxisLength { get; set; }

        public int XAxis { get; set; }

        public int YAxis { get; set; }

        public Plateau(int xLength, int yLength)
        {
            XAxisLength = xLength;
            YAxisLength = yLength;
        }
    }
}
