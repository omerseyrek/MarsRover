using System;
using System.Threading.Tasks;
using MarsRoverLib;

namespace MarsRoverControllerLib
{
    public class CommandManager : ICommandManager
    {
        IMarsRoverCommandHandler CommandHandlerChain = null;
        public CommandManager()
        {
            //todo : IMarsRoverCommandHandler interfaces can be listed with reflection and chained by using a loop, so new concreete implementetions not be chained manually here.. 
            IMarsRoverCommandHandler lastCommandHandler = new MoveForwardComandHandler(null);
            CommandHandlerChain = new TurnCommandHandler(lastCommandHandler);
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