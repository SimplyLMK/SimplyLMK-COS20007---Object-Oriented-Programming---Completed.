using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_ADV
{
    public static class UserManual
    {
        public static void Manual()
        {
             using (StreamReader sr = new StreamReader("C:\\C#\\CODE\\lab9\\7.2\\lab3.3\\Commands\\Player_Item_Inventory\\user_manual.txt"))
             {
                  string line;
                  while ((line = sr.ReadLine()) != null)
                  {
                        Console.WriteLine(line);
                  }
             }
         }
           
    }
}
