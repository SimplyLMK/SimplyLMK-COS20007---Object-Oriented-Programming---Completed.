using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Bag : Item, I_Have_Inventory
    {
        private readonly Inventory _inventory = new Inventory();

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {

        }

        public override string Full_Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{Name} ({FirstId})");
                sb.AppendLine(base.Full_Description);
                sb.AppendLine($"In the {Name} you can see:");
                sb.Append(_inventory.ItemList);
                return sb.ToString();
            }
        }

        public Game_Object Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else if (_inventory.Has_Item(id))
            {
                return _inventory.Fetch(id);
            }
            else
            {
                return null;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

    }
}

