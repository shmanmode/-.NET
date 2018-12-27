using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExample1
{
    class Program
    {
        static void Main1(string[] args)
        {

            Thread t1 = new Thread(new ThreadStart(Func1));
            Thread t2 = new Thread(new ThreadStart(Func2));

            //t1.Priority = ThreadPriority.Highest;
            t1.IsBackground = true;
            t2.IsBackground = true;


            t1.Start();
            t2.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            t1.Abort();

            //t1.Join();
            //Console.WriteLine("Thread 1 over");
            Console.ReadLine();

        }

        static void Func1()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine("First Thread " + i.ToString());
            }
        }
        static void Func2()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }
    }
}

//using ParameterizedThreadStart to call a func that has an object as parameter
namespace ThreadingExample2
{
    class Program1
    {
        static void Main1()
        {
            Thread t1 = new Thread(new ParameterizedThreadStart(Func1));
            Thread t2 = new Thread(new ParameterizedThreadStart(Func2));
            t1.Start("obj1");
            t2.Start("o2");
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            Console.ReadLine();
        }
        static void Func1(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First ThreadA " + i.ToString() + o.ToString());
            }
        }
        static void Func2(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString() + o.ToString());
            }
        }
    }
}


//using the ThreadPool
namespace ThreadingExample3
{
    class MainClass
    {
        static void PoolFunc1(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("First Thread " + i.ToString());
            }
        }
        static void PoolFunc2(object o)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Second Thread " + i.ToString());
            }
        }

        static void Main1()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc1), "aaa");
            ThreadPool.QueueUserWorkItem(new WaitCallback(PoolFunc2));


            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("Main Thread " + i.ToString());
            }
            Console.ReadLine();
        }
    }
}

//synchronization using lock(), Monitor and Interlocked
namespace ThreadingExample4
{
    class MainClass
    {
        static object lockObject = new object();
        static int i = 0;
        static void Main()
        {
            Thread t1 = new Thread(new ThreadStart(FuncLock));
            Thread t2 = new Thread(new ThreadStart(FuncMonitor));
            Thread t3 = new Thread(new ThreadStart(FuncInterlocked));
            t1.Start();
            t2.Start();
            //t3.Start();

            //t1.Join();
            //t2.Join();
            //t3.Join();

            Console.WriteLine("Finished Main");
            Console.ReadLine();
        }
        static void FuncLock()
        {
            lock (lockObject)
            {
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
                i++;
                Console.WriteLine("First FuncLock " + i);
            }
        }

        static void FuncMonitor()
        {
            Monitor.Enter(lockObject);

            {
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
                i++;
                Console.WriteLine("Second Monitor " + i.ToString());
            }
            Monitor.Exit(lockObject);

        }

        static void FuncInterlocked()
        {

            Interlocked.Add(ref i, 10);
            Console.WriteLine("Third Interlocked " + i.ToString());
            Interlocked.Increment(ref i);
            Console.WriteLine("Third Interlocked " + i.ToString());
            Interlocked.Decrement(ref i);
            Console.WriteLine("Third Interlocked " + i.ToString());
            Interlocked.Exchange(ref i, 100);
            Console.WriteLine("Third Interlocked " + i.ToString());
        }

    }
}