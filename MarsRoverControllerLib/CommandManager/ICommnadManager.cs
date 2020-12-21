using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public interface ICommandManager
    {
        void ExecuteCommand(IMarsRover marsRover, string commandArrayText);
    }
}