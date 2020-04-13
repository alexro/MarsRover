using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover
{
    /// <summary>
    /// Rover position Interpreter that stops Rover from moving 
    /// when it reaches the end of Area
    /// </summary>
    public class BasicInterpreter : IInterpreter
    {
        private HashSet<(int, char)> DegreeDirection = new HashSet<(int, char)>
        {
            (0, 'N'),
            (90, 'E'),
            (180, 'S'),
            (270, 'W')
        };

        protected IArea _area;

        public BasicInterpreter(IArea area)
        {
            _area = area;
        }

        public virtual int CorrectX(int x)
        {
            return x < _area.MinX ? _area.MinX : (x > _area.MaxX ? _area.MaxX : x);
        }

        public virtual int CorrectY(int y)
        {
            return y < _area.MinY ? _area.MinY : (y > _area.MaxY ? _area.MaxY : y);
        }

        public virtual int ChangeDirection(int dir, char turn)
        {
            if (!"LR".Contains(turn))
                throw new ArgumentOutOfRangeException("Can't interpret direction");

            var turnBy = turn == 'R' ? 90 : -90;
            var newDir = (dir + turnBy);
            newDir = newDir < 0 ? newDir + 360 : newDir;
            return newDir % 360;
        }

        public virtual (int, int) ChangePosition((int, int) pos, int dir)
        {
            switch (dir)
            {
                case 0: return (pos.Item1, CorrectY(pos.Item2 + 1));
                case 90: return (CorrectX(pos.Item1 + 1), pos.Item2);
                case 180: return (pos.Item1, CorrectY(pos.Item2 - 1));
                case 270: return (CorrectX(pos.Item1 - 1), pos.Item2);
                default: throw new ArgumentOutOfRangeException("Can't interpret position");
            }
        }

        public virtual int GetDirection(char dir)
        {
            var item = DegreeDirection.Where(t => t.Item2 == dir).FirstOrDefault();
            return item.Item1;
        }

        public virtual char GetDirection(int deg)
        {
            var item = DegreeDirection.Where(t => t.Item1 == deg).First();
            return item.Item2;
        }
    }
}
