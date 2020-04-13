As even google and git projects started with sloppy code - it would be a mistake to judge this code by completeness and perfection. 
What makes the product great - is a continuous team effort. 
With this in mind please have a look at the simple Mars Rover emulator.  

dotnet core 3.1

On Linux:  
dotnet test  
dotnet run --project MarsRoverConsole

Two Interpreters provided for managing Rover position:  
  
BasicInterpreter - doesn't allow to move if Rover reaches the end of Area  
  
WrappingInterpreter - makes Rover to appear from the other side

Emulator class is the place to wire the thing together and run emulation

A lot of fun and useful stuff could've been added to the real project!
