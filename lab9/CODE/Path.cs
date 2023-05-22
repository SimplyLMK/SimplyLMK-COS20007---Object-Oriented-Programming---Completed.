using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Swin_ADV
{
    public class Pathing : Game_Object
    {
        bool _deadEnd, _blocked;
        Location _initial, _destination;

        public Pathing(string[] idents, string name, string desc, Location initial, Location destination, bool blocked = false) : base(idents, name, desc)
        {
            _initial = initial;
            _destination = destination;
            _deadEnd = false;
            _blocked = blocked;
            AddIdentifier("path");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == ' ')
                {
                    AddIdentifier(sb.ToString());
                    sb.Clear();
                }
                else
                {
                    sb.Append(name[i]);
                }
            }
            AddIdentifier(sb.ToString());
        }

        public Location Destination
        {
            get { return _destination; }
        }

        public override string Short_Description
        {
            get { return Name; }
        }

        public bool DeadEnd
        {
            get { return _deadEnd; }
            set { _deadEnd = value; }
        }

        public bool Blocked
        {
            get { return _blocked; }
            set { _blocked = value; }
        }

        public bool Unlocked{ get; set; }

    }

}
