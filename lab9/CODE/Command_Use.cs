using Swin_ADV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Use_Command : Command
    {
        public Use_Command() : base(new string[] { "use" })
        {
        }

        public override string Execute(Player player, string[] order)
        {
            if (order.Length != 3)
            {
                return "Invalid command.Example: use {force_multiplier} {upstair}";
            }

            string itemName = order[1];
            string direction = order[2];

            Item item = player.Inventory.Fetch(itemName);
            if (item == null)
            {
                return $"You don't have a {itemName} in your inventory.";
            }

            Pathing path = player.Location.GetPath(direction);
            if (path == null)
            {
                return $"There is no path to the {direction}.";
            }

            if (!path.Blocked)
            {
                return $"The {direction} door is not blocked. No need to use {itemName}.";
            }

            if (itemName == "force_multiplier" && path.Unlocked)
            {
                path.Blocked = false;
                return $"You have successfully used {itemName} to unblock the {direction} door.";
            }
            else
            {
                return $"Using {itemName} on the {direction} door has no effect.";
            }
            
            
        }
    }
}
