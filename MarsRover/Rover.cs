using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Rover : IRover
    {
        private IInterpreter _i;
        private (int, int) _pos;
        private int _dir = 0;

        public Rover(IInterpreter i, int x, int y, char dir)
        {
            _i = i;
            _pos = (x, y);
            _dir = _i.GetDirection(dir);
        }

        public virtual void Move()
        {
            _pos = _i.ChangePosition(_pos, _dir);
        }

        public virtual void Turn(char code)
        {
            _dir = _i.ChangeDirection(_dir, code);
        }

        public virtual string Report()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"{_pos.Item1} {_pos.Item2} {_i.GetDirection(_dir)}";
        }
    }
}
