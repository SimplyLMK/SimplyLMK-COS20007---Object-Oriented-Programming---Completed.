using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Take_Command : Command
    {
        public Take_Command() : base(new string[] { "take", "obtain", "get", "pick_up" })
        {
        }
        public override string Execute(Player player, string[] order)
        {
            if (order.Length != 2)
            {
                return "Invalid Command. Usage: take <item_name>";
            }

            string itemId = order[1];
            I_Have_Inventory container = player.Location;

            if (container.Locate(itemId) is Item item)
            {
                (container as Location).Inventory.Take(itemId);

                player.Inventory.Put(item);

                return $"You have taken {item.Name}.";
            }
            else
            {
                return $"There is no {itemId} in this location.";
            }
        }
    }

}
