using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public class Inventory
    {
        private List<Item>_item;
        public Inventory()
        {
            _item = new List<Item>();
            
        }

        public bool Has_Item(string id)
        {
            foreach (Item item in _item)
            {
                if (item.AreYou(id))
                {
                    return true;
                }
            }

            return false;
        }

        public void Put(Item item)
        {
            _item.Add(item);
        }

        public Item Take(string id)
        {
            Item pickup = this.Fetch(id);
            _item.Remove(pickup);
            return pickup;
        }

        public Item Fetch(string id)
        {
            foreach (Item item in _item)
            {
                if (item.AreYou(id))
                {
                    return item;
                }
            }

            return null;
        }

        public string ItemList
        {
            get
            {
                StringBuilder result = new StringBuilder();

                foreach (Item item in _item)
                {
                    result.Append("\t");
                    result.Append(item.Short_Description);
                    result.Append("\r\n");
                }

                return result.ToString();
            }
            

        }
        public int Count
        {
            get { return _item.Count; }
        }

    }
}
