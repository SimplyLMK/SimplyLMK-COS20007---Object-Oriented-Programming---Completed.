using System;

namespace Counter
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            Counter[] counter = new Counter[3];

            counter[0] = new Counter("Counter 1");

            counter[1] = new Counter("Counter 2");

            counter[2] = counter[0];

            for (int i = 0; i < 10; i++)
            {
                counter[0].Increment();
            }

            for (int i = 0; i < 14; i++)
            {
                counter[1].Increment();
            }

            Counter.PrintCounters(counter);

            counter[2].Reset();

            Counter.PrintCounters(counter);
        }

   
    }
}