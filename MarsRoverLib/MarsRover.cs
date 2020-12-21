using System;

namespace MarsRoverLib
{
    public class MarsRover : IMarsRover
    {
        public (int XSize, int YSize) PlatouTupple { get; set; }

        public RoverStatus RoverStatus { get; }

        ILogger Logger = null;

        private const string OutOfPlatouWarning = "the command is going to get the rover out of platou, command did not executed";

        public MarsRover(RoverStatus status, (int,int) platouTupple, ILogger logger )
        {
            if (status == null)
            {
                throw new System.ArgumentException("rover status parameter is null");
            }
           
            if (platouTupple.Item1 < 1 || platouTupple.Item2 < 1)
            {
                throw new System.ArgumentException("platou size parameters should be greater than zero");
            }
          
            if (logger == null)
            {
                throw new System.ArgumentException("logger  parameter is null");
            }

            RoverStatus = status;
            PlatouTupple = platouTupple;
            Logger = logger;
        }

        

        public void Move()
        {
            switch (RoverStatus.CurrentDirection)
            {
                case Direction.North:
                    if (RoverStatus.YPoint + 1 <= PlatouTupple.YSize)
                    {
                        RoverStatus.YPoint = RoverStatus.YPoint + 1;
                    }
                    else
                    {
                        Logger.Log(RoverStatus, OutOfPlatouWarning);     
                    }
                    break;
                case  Direction.East :
                    if (RoverStatus.XPoint + 1 <= PlatouTupple.XSize)
                    {
                        RoverStatus.XPoint = RoverStatus.XPoint + 1;
                    }
                    else
                    {
                        Logger.Log(RoverStatus, OutOfPlatouWarning);     
                    }
                    break;
                case Direction.South:
                    if (RoverStatus.YPoint - 1 >= 0)
                    {
                        RoverStatus.YPoint = RoverStatus.YPoint - 1;
                    }
                    else
                    {
                        Logger.Log(RoverStatus, OutOfPlatouWarning);            
                    }

                    break;
                case  Direction.West :
                    if (RoverStatus.XPoint - 1 >= 0)
                    {
                        RoverStatus.XPoint = RoverStatus.XPoint - 1;
                    }
                    else
                    {
                        Logger.Log(RoverStatus, OutOfPlatouWarning);            
                    }
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
