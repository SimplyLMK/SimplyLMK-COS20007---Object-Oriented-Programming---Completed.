using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Player : Game_Object, I_Have_Inventory
    {
        private Inventory _inventory;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
            set
            {
                _inventory = value;
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

        public override string Full_Description
        {
            get
            {
                StringBuilder sb = new StringBuilder(base.Full_Description);
                sb.Append("\nYou are carrying:\n");
                sb.Append(_inventory.ItemList);
                return sb.ToString();
            }
        }

    }

}
