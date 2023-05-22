using System;

namespace Clocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            Clock white_clock = new Clock(600);
            Clock black_clock = new Clock(600);

            

            do
            {
                Console.WriteLine(white_clock.Show());
                white_clock.Tick();
                Thread.Sleep(1000);
                i++;

            } while (i < 86400);




        }
    }
}
