using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public static class Clock
    {
        private static Counter[] _counters;
   

        static Clock()
        {
            _counters = new Counter[3];
            _counters[0] = new Counter("Second counter");
            _counters[1] = new Counter("Minute counter");
            _counters[2] = new Counter("Hour counter");
        }

        public static void Tick()
        {
            _counters[0].Increment(); 

            if (_counters[0].Ticks == 60)
            {
                _counters[0].Reset();
                _counters[1].Increment();
            }

            if (_counters[1].Ticks == 60)
            {
                _counters[1].Reset();
                _counters[2].Increment(); 
            }

            if (_counters[2].Ticks == 24)
            {
                _counters[2].Reset();
            }
        }
        public static Counter GetCounter(int index)
        {
            return _counters[index];
        }



        public static void ResetCounter()
        {
            while(true)
            { 
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.Spacebar|| key.Key == ConsoleKey.Enter)
              {
                _counters[0].Reset();
                _counters[1].Reset();
                _counters[2].Reset();
              }
            }
        }

        //public static string Show()
        //{
        //   return $"{_counters[2].Ticks:D2}:{_counters[1].Ticks:D2}:{_counters[0].Ticks:D2}";
        //}

        public static string Show()
        {
            return $"{_counters[2].Ticks:D2}:{_counters[1].Ticks:D2}:{_counters[0].Ticks:D2}";
        }



    }
}
