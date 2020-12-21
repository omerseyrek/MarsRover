using System;
using Xunit;
using MarsRoverLib;
using Moq;

namespace MarsRover.Tests
{

    public class MarsRoverLibTests
    {
        (int, int) platouTupple = (5, 5);
         

        private IMarsRover CreateMarsRover(RoverStatus roverStatus, (int, int) platouTupple)
        {
            Mock<ILogger> testLogger = new Mock<ILogger>();
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus, platouTupple, testLogger.Object);
            return marsRover;
        }


        [Fact]
        public void MoveNorth_shoult_increment_ypoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.North), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 2;
            Assert.Equal(expected, marsRover.RoverStatus.YPoint);
        }

        [Fact]
        public void MoveNorth_shoult_not_change_xpoint()
        {
            //arrange
           IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.North),  platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 1;
            Assert.Equal(expected, marsRover.RoverStatus.XPoint);
        }


        [Fact]
        public void MoveSouth_shoult_decrement_ypoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover( new RoverStatus(1, 1, Direction.South), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 0;
            Assert.Equal(expected, marsRover.RoverStatus.YPoint);
        }

         [Fact]
        public void MoveSouth_shoult_not_change_xpoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.South), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 1;
            Assert.Equal(expected, marsRover.RoverStatus.XPoint);
        }


        [Fact]
        public void MoveEast_shoult_increment_xpoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.East), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 2;
            Assert.Equal(expected, marsRover.RoverStatus.XPoint);
        }

        [Fact]
        public void MoveEast_shoult_not_change_ypoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.East), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 1;
            Assert.Equal(expected, marsRover.RoverStatus.YPoint);
        }

        [Fact]
        public void MoveWest_shoult_decrement_xpoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.West), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 0;
            Assert.Equal(expected, marsRover.RoverStatus.XPoint);
        }

        [Fact]
        public void MoveWest_shoult_not_change_ypoint()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.West), platouTupple);

            //act 
            marsRover.Move();

            //assert
            var expected = 1;
            Assert.Equal(expected, marsRover.RoverStatus.YPoint);
        }



        [Fact]
        public void TurnRight_shoult_faceto_east_when_current_is_north()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.North), platouTupple);

            //act 
             marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.East;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnRight_shoult_faceto_south_when_current_is_east()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.East), platouTupple);

            //act 
            marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.South;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

         [Fact]
        public void TurnRight_shoult_faceto_west_when_current_is_south()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.South), platouTupple);

            //act 
             marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.West;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnRight_shoult_faceto_north_when_current_is_west()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.West), platouTupple);

            //act 
             marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.North;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

        
        [Fact]
        public void TurnLeft_should_faceto_west_when_current_is_north()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.North), platouTupple);
            //act 
            marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.West;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnLeft_should_faceto_north_when_current_is_east()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.East), platouTupple);

            //act 
           marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.North;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

         [Fact]
        public void TurnLeft_should_faceto_east_when_current_is_south()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.South), platouTupple);

            //act 
            marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.East;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnLeft_should_faceto_south_when_current_is_west()
        {
            //arrange
            IMarsRover marsRover = CreateMarsRover(new RoverStatus(1, 1, Direction.West), platouTupple);

            //act 
            marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.South;
            Assert.Equal(expected,  marsRover.RoverStatus.CurrentDirection);
        }
    }
}
