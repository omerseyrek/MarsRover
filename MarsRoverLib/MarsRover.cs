using System;

namespace MarsRoverLib
{
    public class MarsRover : IMarsRover
    {
        public RoverStatus RoverStatus { get; }

        public MarsRover(RoverStatus status)
        {
            RoverStatus = status;
        }

        public void Move()
        {
            switch (RoverStatus.CurrentDirection)
            {
                case  Direction.North :
                    RoverStatus.YPoint = RoverStatus.YPoint +  1;
                    break;
                case  Direction.East :
                    RoverStatus.XPoint = RoverStatus.XPoint + 1;
                    break;
                case  Direction.South :
                    RoverStatus.YPoint = RoverStatus.YPoint - 1;
                    break;
                case  Direction.West :
                    RoverStatus.XPoint = RoverStatus.XPoint -1 ;
                    break;
                default:
                    break;
            }
        }

        public void Turn(TurnSide side)
        {
            if (side == TurnSide.Left)
            {
                TurnLeft();
                return;
            }
            
            if (side == TurnSide.Right)
            {
                TurnRight();
                return;
            }
        }
    

        private void TurnLeft()
        {
            switch (RoverStatus.CurrentDirection)
            {
                case  Direction.North :
                    RoverStatus.CurrentDirection = Direction.West;
                    break;
                case  Direction.East :
                    RoverStatus.CurrentDirection = Direction.North;
                    break;
                case  Direction.South :
                    RoverStatus.CurrentDirection = Direction.East;
                    break;
                case  Direction.West :
                    RoverStatus.CurrentDirection = Direction.South;
                    break;
                default:
                    break;
            }
        }

        private void TurnRight()
        {
            switch (RoverStatus.CurrentDirection)
            {
                case  Direction.North :
                    RoverStatus.CurrentDirection = Direction.East;
                    break;
                case  Direction.East :
                    RoverStatus.CurrentDirection = Direction.South;
                    break;
                case  Direction.South :
                    RoverStatus.CurrentDirection = Direction.West;
                    break;
                case  Direction.West :
                    RoverStatus.CurrentDirection = Direction.North;
                    break;
                default:
                    break;
            }
        }

    }
}
