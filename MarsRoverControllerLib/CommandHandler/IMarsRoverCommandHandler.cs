using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public interface IMarsRoverCommandHandler 
    {

        void HandleCommand(IMarsRover marsRover, string commandKey);

    }
}
