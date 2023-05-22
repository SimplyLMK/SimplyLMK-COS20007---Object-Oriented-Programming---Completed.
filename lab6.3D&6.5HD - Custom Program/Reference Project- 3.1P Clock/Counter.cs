using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clocks
{
    public class Counter
    {
        private int _count = 0;
        private string _name; 

        public Counter(string name)
        {
            _name = name;
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Ticks
        {
            get
            {
                return _count;
            }

        }

        public void Increment()
        {
            _count++;
 
        }

        public void Decrement()
        {
            _count -= 1;
        }

        public void Reset()
        {
            _count = 0;
        }

        public void Set(int ticks)
        {
            _count = ticks;
        }


    }
}

