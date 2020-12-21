using System;

namespace MarsRoverLib
{
    public class RoverStatus
    {
        public int XPoint { get; internal set; }

        public int YPoint { get; internal set; }

        public Direction CurrentDirection { get; internal set; }
        
        public RoverStatus(int xPoint, int yPoint, Direction direciton)
        {
            XPoint = xPoint;
            YPoint = yPoint;
            CurrentDirection = direciton;
        }

        public override string ToString()
        {
            return $"{this.XPoint} {this.YPoint} { Enum.GetName(typeof(Direction), CurrentDirection) }";
        }
    }
}
