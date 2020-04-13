using System;
using MarsRover;

namespace MarsRoverConsole
{
    public class Program
    {
        static void Main()
        {
            var e = new Emulator<BasicInterpreter, Area, Rover>(new Factory());
            e.Execute(@"
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
"
                );
            Console.ReadLine();
        }
    }
}
