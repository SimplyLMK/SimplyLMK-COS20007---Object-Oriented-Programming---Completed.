using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
  
        public interface I_Have_Inventory
        {
            Game_Object Locate(string id);
            string Name
            {
                get;
            }

            Inventory Inventory { get; }
    }
    

}

