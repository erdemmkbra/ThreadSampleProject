using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    public delegate int MyTimerTickHandler(int x, string s);
    public class MyTimer
    {
        public int Interval { get; set; } = 100;

        Thread myThread;
        bool timerStarter = false;

        public event MyTimerTickHandler MyTimerTick = null;

        public MyTimer()
        {

        }

        private void MyWorker()
        {
            while (timerStarter)
            {
                try
                {
                    if(MyTimerTick !=null)
                        MyTimerTick(DateTime.Now.Second,  "M: " + DateTime.Now.Millisecond);

                }
                catch { }

                try
                {
                    Thread.Sleep(Interval);
                }
                catch { }

            }
            

        }

        public void Start()
        {
            timerStarter = true;
            myThread = new Thread(new ThreadStart(MyWorker));
            myThread.Start();

        }

        public void Stop()
        {
            timerStarter= false;
            myThread.Abort();
            myThread = null;


        }

    }
}
