using System;
using MarsRoverControllerLib;
using MarsRoverLib;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            IMarsRover marsRover = new MarsRoverLib.MarsRover(new RoverStatus(1, 2, Direction.North));

            ICommandManager commandManager = new MarsRoverControllerLib.CommandManager();

            commandManager.ExecuteCommand(marsRover, "LMLMLMLMM");

            Console.WriteLine($"X : {marsRover.RoverStatus.XPoint}  Y : {marsRover.RoverStatus.YPoint} direction :{marsRover.RoverStatus.CurrentDirection.ToString("G")}");


            IMarsRover marsRover2 = new MarsRoverLib.MarsRover(new RoverStatus(3, 3, Direction.East));

            commandManager.ExecuteCommand(marsRover, "MMRMMRMRRM");

            Console.WriteLine($"X : {marsRover2.RoverStatus.XPoint}  Y : {marsRover2.RoverStatus.YPoint} direction :{marsRover2.RoverStatus.CurrentDirection.ToString("G")}");




            

        }   
    }
}
