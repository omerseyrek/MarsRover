using System;

namespace MarsRoverLib
{
    public interface ILogger
    {
        void Log (RoverStatus roverStatus, string Message);    
    }
}
