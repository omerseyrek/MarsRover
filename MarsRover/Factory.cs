using System;
using MarsRoverControllerLib;
using MarsRoverLib;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover
{
    public static class ApplicationRoverFactory
    {
        private static ServiceProvider serviceProvider;

        public static void SetupDependencyService()
        {
             serviceProvider = new ServiceCollection()
                .AddTransient<ILogger, ConsoleLogger>()
                .AddTransient<ICommandManager, CommandManager>()
                .BuildServiceProvider();
        }

        public static ServiceProvider GetServiceProvider()
        {
            if (serviceProvider == null)
            {
                var lockObject = new object();
                lock (lockObject)
                {
                    if (serviceProvider == null)
                    {
                        SetupDependencyService();
                    }
                }
            }
            return serviceProvider;
        }

        public static ILogger GetServiceLogger(RoverStatus roverStatus, (int, int) platouTupple)
        {
            ILogger logger = GetServiceProvider().GetService<ILogger>();
            return logger;
        }


        public static IMarsRover CreateMarsRover(RoverStatus roverStatus, (int, int) platouTupple)
        {
            ILogger logger = GetServiceProvider().GetService<ILogger>();
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus, platouTupple, logger);
            return marsRover;
        }
    }


    public class ConsoleLogger : ILogger
    {
        public void Log(RoverStatus roverStatus, string Message)
        {
            System.Console.WriteLine($"current position - {roverStatus.ToString()} : {Message}");
        }
    }

}