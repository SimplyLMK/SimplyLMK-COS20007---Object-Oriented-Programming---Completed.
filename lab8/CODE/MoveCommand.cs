using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Move_Command : Command
    {
        public Move_Command() : base(new string[] { "move", "go", "head", "leave" })
        {
        }

        public override string Execute(Player player, string[] order)
        {
            string invalid = "Unable to perform such action.";
            string go_to;

            if (order.Length == 1)
            {
                return "Go to?";
            }
            else if (order.Length == 2)
            {
                go_to = order[1].ToLowerInvariant();
            }
            else if (order.Length == 3)
            {
                go_to = order[2].ToLowerInvariant();
            }
            else
            {
                return invalid;
            }

            Game_Object _path = player.Location.Locate(go_to);

            if (_path == null)
            {
                return invalid;
            }
            else if (_path.GetType() != typeof(Pathing))
            {
                return $"Unable to locate the {_path.Name} ";
            }
            else
            {
                player.Move_Command((Pathing)_path);
                return $"You followed to the {_path.FirstId} going through {_path.Name} and reaching the {player.Location.Name}\n\n{player.Location.Full_Description} " ;
            }

        }
    }

}
