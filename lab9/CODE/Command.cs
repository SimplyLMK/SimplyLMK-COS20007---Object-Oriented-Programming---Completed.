using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
     public abstract class Command : Identifiable
     {
        public Command(string[] ids) : base(ids)
        {

        }

        public abstract string Execute(Player player, string[] order);
     }
}
