using System;
using Xunit;
using MarsRoverLib;

namespace MarsRover.Tests
{

    public class MarsRoverLibTests
    {
    
        [Fact]
        public void MoveNorth_shoult_increment_ypoint()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.North);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.North);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.South);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.South);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            IMarsRover marsRover = new MarsRoverLib.MarsRover(new RoverStatus(1, 1, Direction.East));

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.East);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.West);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.West);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

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
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.North);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
             marsRover.Turn(TurnSide.Right);


            //assert
            var expected = Direction.East;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnRight_shoult_faceto_south_when_current_is_east()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.East);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
            marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.South;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

         [Fact]
        public void TurnRight_shoult_faceto_west_when_current_is_south()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.South);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
             marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.West;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnRight_shoult_faceto_north_when_current_is_west()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.West);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
             marsRover.Turn(TurnSide.Right);

            //assert
            var expected = Direction.North;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

        
        [Fact]
        public void TurnLeft_should_faceto_west_when_current_is_north()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.North);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
            marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.West;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnLeft_should_faceto_north_when_current_is_east()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.East);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
           marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.North;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

         [Fact]
        public void TurnLeft_should_faceto_east_when_current_is_south()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.South);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
            marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.East;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }

        [Fact]
        public void TurnLeft_should_faceto_south_when_current_is_west()
        {
            //arrange
            RoverStatus roverStatus = new RoverStatus(1, 1, Direction.West);
            IMarsRover marsRover = new MarsRoverLib.MarsRover(roverStatus);

            //act 
            marsRover.Turn(TurnSide.Left);

            //assert
            var expected = Direction.South;
            Assert.Equal(expected, roverStatus.CurrentDirection);
        }
    }
}
