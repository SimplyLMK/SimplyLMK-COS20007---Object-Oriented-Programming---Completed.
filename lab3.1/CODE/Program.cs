using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;

            Thread inputThread = new Thread(Clock.ResetCounter);
            inputThread.Start();

            do
            {
                Console.WriteLine(Clock.Show());
                Clock.Tick();          
                Thread.Sleep(1000);
                i++;

            } while (i< 86400);
            
          


        }
    }
}
