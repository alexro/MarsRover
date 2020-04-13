using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarsRover
{
    /// <summary>
    /// Emulator takes input, parses, creates objects and runs emulation.
    /// 
    /// In production logger will be used instead of Console
    /// and object types will be instantiated via a factory or DI.
    /// 
    /// Input is assumed to be in a correct form. 
    /// Initial position for Rover is assumed to be inside the Area.
    /// 
    /// </summary>
    /// <typeparam name="I"></typeparam>
    /// <typeparam name="A"></typeparam>
    /// <typeparam name="R"></typeparam>
    public sealed class Emulator<I, A, R>
        where I : IInterpreter
        where A : IArea
        where R : IRover
    {
        private Factory _f;
        private IInterpreter _i;
        private IRover _r;

        public Emulator(Factory f)
        {
            _f = f;
        }

        private void SetArea(string input)
        {
            var areaInput = input.Trim().Split(" ");
            SetArea(int.Parse(areaInput[0]), int.Parse(areaInput[1]));
        }

        private void SetArea(int maxX, int maxY)
        {
            _i = typeof(I) == typeof(BasicInterpreter)
                ? _f.CreateBasicInterpeter(_f.CreateArea(maxX, maxY))
                : _f.CreateWrappingInterpeter(_f.CreateArea(maxX, maxY));
        }

        private void SetRover(string input)
        {
            var roverInput = input.Trim().Split(" ");
            SetRover(int.Parse(roverInput[0]), int.Parse(roverInput[1]), roverInput[2]);
        }

        private void SetRover(int x, int y, string dir)
        {
            _r = _f.CreateRover(_i, x, y, dir[0]);
        }

        private void MoveRover(string input)
        {
            foreach (char ch in input)
            {
                switch (ch)
                {
                    case 'M': _r.Move(); break;
                    default: _r.Turn(ch); break;
                }
            }
        }

        public void Execute(string input)
        {
            var lines = new List<string>();
            var reader = new StringReader(input);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    lines.Add(line.Trim());
            }

            SetArea(lines[0]);

            for (var i = 1; i < lines.Count - 1; i += 2)
            {
                SetRover(lines[i]);
                MoveRover(lines[i + 1]);
                Console.WriteLine(_r.Report());
            }
        }
    }
}
