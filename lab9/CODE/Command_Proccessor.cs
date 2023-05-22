
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class CommandProcessor
    {
        private readonly List<Command> _commands;

        public CommandProcessor()
        {
            _commands = new List<Command>
            {
                new Look_Command(),
                new Move_Command(),
                new Take_Command(),
                new Use_Command(),
                new Put_Command(),

            };
        }

        public string Execute(string commandText, Player player)
        {
            string[] order = commandText.Split(' ');

            if (order.Length == 0)
            {
                return "Invalid command.";
            }

            string commandId = order[0].ToLowerInvariant();
            Command matchedCommand = null;

            foreach (Command cmd in _commands)
            {
                if (cmd.AreYou(commandId))
                {
                    matchedCommand = cmd;
                    break;
                }
            }

            if (matchedCommand == null)
            {
                return $"Unknown command: {commandId}";
            }

            return matchedCommand.Execute(player, order);
        }
    }

}
