using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Swin_ADV
{
    
    public class Location : Game_Object, I_Have_Inventory
    {
        private Inventory _inventory;
        List<Pathing> _paths;

        public Location(string name, string desc) : base(new string[] { "location" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Pathing>();
        }

        public Location(string name, string desc, List<Pathing> paths) : this(name, desc)
        {
            _paths = paths;
        }

        public Game_Object Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }

            foreach (Pathing p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }

            return _inventory.Fetch(id);
        }


        public string PathList
        {
            get
            {
                if (_paths.Count == 0)
                {
                    return "";
                }
                if (_paths.Count == 1)
                {
                    return $"You can see the exit at {_paths[0].FirstId}.";
                }

                StringBuilder sb = new StringBuilder("You can see exits ");

                for (int i = 0; i < _paths.Count; i++)
                {
                    if (i == _paths.Count - 1)
                    {
                        sb.Append($"and {_paths[i].FirstId}.");
                    }
                    else
                    {
                        sb.Append($"{_paths[i].FirstId}, ");
                    }
                }

                return sb.ToString();
            }
        }

        //public string ItemList
        //{
        //    get
        //    {
        //        string itemList = "In the room you see:\n";
        //        itemList += _inventory.ItemList;

        //        return _inventory.Count == 0 ? string.Empty : itemList;
        //    }
        //}



        public override string Short_Description
        {
            get
            {
                return $"You found yourself at: {Name} ";
            }
        }

       
        public override string Full_Description
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"You are in {Name}");
                sb.AppendLine($"In the current location, you see: {base.Full_Description}");
                sb.AppendLine("\nWithin closer inspection, you see:");
                sb.Append(Inventory.ItemList);
                sb.Append(PathList);
                return sb.ToString();
            }
        }

        public Inventory Inventory
        {
            get => _inventory;
        }

        public void AddPath(Pathing path)
        {
            _paths.Add(path);
        }

    }



}
