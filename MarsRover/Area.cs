using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Area : IArea
    {
        public Area(int maxX, int maxY, int minX = 0, int minY = 0)
        {
            MinX = minX;
            MinY = minY;
            MaxX = maxX;
            MaxY = maxY;
        }

        public int MinX { get; } = 0;
        public int MinY { get; } = 0;
        public int MaxX { get; }
        public int MaxY { get; }
    }
}
