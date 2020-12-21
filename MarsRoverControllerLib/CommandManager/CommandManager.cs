using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public class CommandManager : ICommandManager
    {
        IMarsRoverCommandHandler CommandHandlerChain = null;
        public CommandManager(ILogger logger)
        {
            //todo : IMarsRoverCommandHandler interfaces can be listed with reflection and chained by using a loop, so new concreete implementetions not be chained manually here.. 
            IMarsRoverCommandHandler lastCommandHandler = new MoveForwardComandHandler(null, logger);
            CommandHandlerChain = new TurnCommandHandler(lastCommandHandler, logger);
        }

        public void ExecuteCommand(IMarsRover marsRover, string commandChain)
        {
            foreach (char command in commandChain)
            {
                
                CommandHandlerChain.HandleCommand(marsRover, command.ToString());
            }
        }
    }


}