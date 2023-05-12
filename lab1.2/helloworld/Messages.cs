
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Messages
    {
        private string _text;
        public Messages(string text) 
        {
            {
                _text = text;
            }

        }

        public void Print()
        {
            Console.WriteLine(_text);
        }

    }
}
