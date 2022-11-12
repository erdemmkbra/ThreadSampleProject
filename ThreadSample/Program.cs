using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int interval = 100;

            int temp = 0;


            while (true)
            {
                Console.WriteLine("Please enter interval :  ");
                interval = int.Parse(Console.ReadLine());
                if (interval == 999) break;

                MyTimer timer = new MyTimer();
                timer.Interval = interval;
                timer.MyTimerTick += Timer_MyTimerTick;
                timer.MyTimerTick += Timer_MyTimerTick;

                //mytimer2  console progress bar

                timer.Start();

                Console.ReadLine();
                timer.Stop();

                Console.WriteLine("Timer Stopped!");
                Console.ReadLine();
                Console.ReadLine();
            }
        }

        private static int Timer_MyTimerTick(int x, string s)
        {
            Console.WriteLine(x + "-" + s);

            return 0;
        }
    }
}
