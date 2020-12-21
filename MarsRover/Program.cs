using System;
using MarsRoverControllerLib;
using MarsRoverLib;
using Microsoft.Extensions.DependencyInjection;


namespace MarsRover
{
    class Program
    {

        static void Main(string[] args)
        {

            (int XSize, int YSize) PlatouTupple = ReadPlateuTupple();
            ICommandManager commandManager = (ICommandManager)ApplicationRoverFactory.GetServiceProvider().GetService<ICommandManager>();

            RoverStatus firstRoverStatus = ReadRoverStatus(PlatouTupple);
            IMarsRover firstMarsRover = ApplicationRoverFactory.CreateMarsRover(firstRoverStatus, PlatouTupple);
            string command = Console.ReadLine();
            commandManager.ExecuteCommand(firstMarsRover, command);
            

            RoverStatus secondRoverStatus = ReadRoverStatus(PlatouTupple);
            command = Console.ReadLine();
            IMarsRover secondMarsRover = ApplicationRoverFactory.CreateMarsRover(secondRoverStatus, PlatouTupple);
            commandManager.ExecuteCommand(secondMarsRover, command);

            System.Console.WriteLine(firstMarsRover.RoverStatus.ToString());
            System.Console.WriteLine(secondMarsRover.RoverStatus.ToString());
            Console.ReadLine();

        }

        private static RoverStatus ReadRoverStatus((int XSize, int YSize) PlatouTupple)
        {
            string[] roverStatusValues = Console.ReadLine().Split(' ');

            if (roverStatusValues.Length != 3)
            {
                System.Console.WriteLine("please enter integer integer text values with the given order");
                 return ReadRoverStatus(PlatouTupple);
            }

            int XPosition = 0;
            int YPosition = 0;
            string direction = roverStatusValues[2];

            try
            {
                XPosition = Int32.Parse(roverStatusValues[0]);
                YPosition = Int32.Parse(roverStatusValues[1]);
            }
            catch
            {
                System.Console.WriteLine("please enter valid positive integer values for the first two parameter");
                return ReadRoverStatus(PlatouTupple);
            }

            if (XPosition < 1 || YPosition < 1)
            {
                System.Console.WriteLine("please enter valid positive integer values for the first two parameter");
                return ReadRoverStatus(PlatouTupple);
            }

            if (XPosition > PlatouTupple.XSize || YPosition > PlatouTupple.YSize)
            {
                System.Console.WriteLine("position values should not exceed platou sizes");
                return ReadRoverStatus(PlatouTupple);
            }

            

            Direction directionEnum = Direction.None;

            //todo : en enum extensiton amthod could be written in order to parse enum values due to descriptiona attributes
            switch (direction)
            {
                case "N":
                    directionEnum = Direction.North;
                    break;

                case "E":
                    directionEnum = Direction.East;
                    break;

                case "S":
                    directionEnum = Direction.South;
                    break;

                case "W":
                    directionEnum = Direction.West;
                    break;
                default:
                        System.Console.WriteLine("the third aprameter should be one of N E S W letter");
                        return ReadRoverStatus(PlatouTupple);

            }

            return new RoverStatus(XPosition, YPosition, directionEnum);
        }

        private static (int, int) ReadPlateuTupple()
        {
            string[] plateuParamters = Console.ReadLine().Split(' ');
            
            if (plateuParamters.Length != 2)
            {
                System.Console.WriteLine("please enter integer integer  values for the plateu description");
                 return ReadPlateuTupple();
            }
            int XSize = 0;
            int YSize = 0;

            Int32.TryParse(plateuParamters[0], out XSize);
            Int32.TryParse(plateuParamters[1], out YSize);

            try
            {
                XSize = Int32.Parse(plateuParamters[0]);
                YSize = Int32.Parse(plateuParamters[1]);
            }
            catch
            {
                System.Console.WriteLine("please enter valid integer values for the first two parameter");
                return ReadPlateuTupple();
            }

            if (XSize < 1 || YSize < 1)
            {
                System.Console.WriteLine("please enter valid positive integer values for the first two parameter");
                return ReadPlateuTupple();
            }

            return (XSize, YSize);
        }
    }
}
