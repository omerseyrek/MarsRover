using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public class MoveForwardComandHandler : IMarsRoverCommandHandler
    {
        public IMarsRoverCommandHandler Succesor { get; }

        public MoveForwardComandHandler(IMarsRoverCommandHandler succesor)
        {
            Succesor = succesor;
        }

        public void HandleCommand(IMarsRover marsRover, string commandKey)
        {

            if (commandKey == Constants.MoveCommand)
            {
                marsRover.Move();
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
