using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Factory
    {
        public virtual IArea CreateArea(int maxX, int maxY, int minX = 0, int minY = 0)
        {
            return new Area(maxX, maxY, minX, minY);
        }

        public virtual IInterpreter CreateBasicInterpeter(IArea area)
        {
            return new BasicInterpreter(area);
        }

        public virtual IInterpreter CreateWrappingInterpeter(IArea area)
        {
            return new WrappingInterpreter(area);
        }

        public virtual IRover CreateRover(IInterpreter i, int x, int y, char dir)
        {
            return new Rover(i, x, y, dir);
        }
    }
}
