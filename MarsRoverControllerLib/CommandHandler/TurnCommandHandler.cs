using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public class TurnCommandHandler : IMarsRoverCommandHandler
    {
        public IMarsRoverCommandHandler Succesor { get; }
        public ILogger Logger { get; }

        public TurnCommandHandler(IMarsRoverCommandHandler succesor, ILogger logger)
        {
            if (logger == null)
            {
                throw new System.ArgumentException("TurnCommandHandler constructors logger parameter should not be null");
            }

            Succesor = succesor;
            Logger = logger;
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
                 Logger.Log(marsRover.RoverStatus, $" the command key {commandKey} does not implemented by any command handler");
            }
            
        }
    }
}
