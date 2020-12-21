using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public class TurnCommandHandler : IMarsRoverCommandHandler
    {
        public IMarsRoverCommandHandler Succesor { get; }

        public TurnCommandHandler(IMarsRoverCommandHandler succesor)
        {
            Succesor = succesor;
        }

        public void HandleCommand(IMarsRover marsRover, string commandKey)
        {

            if (commandKey == Constants.TurnLeftCommand)
            {
                marsRover.Turn(TurnSide.Left);
                return;
            }
            if (commandKey == Constants.TurnRightCommand)
            {
                marsRover.Turn(TurnSide.Right);
                return;
            }
            if (Succesor != null)
            {
                Succesor.HandleCommand(marsRover, commandKey);
            }
            else
            {
                //todo: log the the given command keys handler is not implemented..
            }
            
        }
    }
}
