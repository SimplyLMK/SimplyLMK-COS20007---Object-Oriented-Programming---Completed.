
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter
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

            if (_count == 60)
            {
                _count = 0;
            }
        }

        public void Reset()
        {
            _count = 0;
        }

        public static void PrintCounters(Counter[] counters)
        {
            foreach (Counter c in counters)
            {
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

    }

 
}
