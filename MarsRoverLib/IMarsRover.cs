using System;

namespace MarsRoverLib
{
    public interface IMarsRover
    {
        RoverStatus RoverStatus { get; }
        
        void Turn(TurnSide direction);

        void Move();
    }
}
