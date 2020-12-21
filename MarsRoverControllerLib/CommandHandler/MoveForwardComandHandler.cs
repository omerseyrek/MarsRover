using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public class MoveForwardComandHandler : IMarsRoverCommandHandler
    {
        public IMarsRoverCommandHandler Succesor { get; }
        public ILogger Logger { get; }

        public MoveForwardComandHandler(IMarsRoverCommandHandler succesor, ILogger logger)
        {
            if (logger == null)
            {
                throw new System.ArgumentException("MoveForwardComandHandler constructors logger parameter should not be null");
            }
            Succesor = succesor;
            Logger = logger;
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
                Logger.Log(marsRover.RoverStatus, $" the command key {commandKey} does not implemented by any command handler");
            }
            
        }
    }
}
