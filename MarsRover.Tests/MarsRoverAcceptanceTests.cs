using System;
using Xunit;
using MarsRoverLib;
using Moq;
using MarsRoverControllerLib;

namespace MarsRover.Tests
{

    public class MarsRoverAcceptenceLibTests
    {
        (int, int) platouTupple = (5, 5);
         

        private IMarsRover CreateMarsRover(RoverStatus roverStatus, (int, int) platouTupple)
        {
            Mock<ILogger> testLogger = new Mock<ILogger>();
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus, platouTupple, testLogger.Object);
            return marsRover;
        }

        private ICommandManager createCommandManager()
        {
            Mock<ILogger> testLogger = new Mock<ILogger>();
            ICommandManager commandManager = new MarsRoverControllerLib.CommandManager(testLogger.Object);
            return commandManager;
        }


        [Fact]
        public void first_conditionTest()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 2, Direction.North), platouTupple);
            ICommandManager commandManager = createCommandManager();


            //act 
            commandManager.ExecuteCommand(marsRover, "LMLMLMLMM");

            //assert
            var expected = new RoverStatus(1, 3, Direction.North);
            Assert.Equal(expected, marsRover.RoverStatus);
        }

        [Fact]
        public void second_conditionTest()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(3, 3, Direction.East), platouTupple);
            ICommandManager commandManager = createCommandManager();


            //act 
            commandManager.ExecuteCommand(marsRover, "MMRMMRMRRM");

            //assert
            var expected = new RoverStatus(5, 1, Direction.East);
            Assert.Equal(expected, marsRover.RoverStatus);
        }


    }
}
