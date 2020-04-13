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
            Console.WriteLine(@"
Please enter Are, Rover position and Moves using this format. 

5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

Then enter 'run' on another line to execute. 
Enter 'end' to exit.
");

            var isActive = true;
            var input = string.Empty;
            do
            {

                var line = Console.ReadLine().Trim();
                if (line == "end")
                {
                    isActive = false;
                }
                else if (line == "run")
                {
                    try
                    {
                        e.Execute(input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Please try again with correct input");
                    }
                    input = string.Empty;
                }
                else
                {
                    input += line + Environment.NewLine;
                }
            } while (isActive);
        }
    }
}
