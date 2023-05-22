using Swin_ADV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Put_Command : Command
    {
        public Put_Command() : base(new string[] { "put" })
        {
        }

        public override string Execute(Player player, string[] order)
        {
            if (order.Length != 4 || order[2].ToLowerInvariant() != "in")
            {
                return "Invalid command. Use 'put {item_name} in {bag}'";
            }

            string itemName = order[1].ToLowerInvariant();
            string cont = order[3].ToLowerInvariant();

            Item item = player.Inventory.Fetch(itemName) as Item;

            if (item == null)
            {
                return $"There is no {itemName} in your inventory.";
            }

            Bag bag = player.Inventory.Fetch(cont) as Bag;

            if (bag == null)
            {
                return $"There is no {cont} in your inventory.";
            }
            bag.Inventory.Put(item);


            player.Inventory.Take(item.FirstId);


            return $"You have put the {item.Name} into the {bag.Name}.";
        }
    }
}

