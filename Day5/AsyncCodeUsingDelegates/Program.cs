using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCodeUsingDelegates
{
    class Program
    {
        static void Main1()
        {
            Action objDel = Display;
            Console.WriteLine("before");
            //starts Display on a separate Thread
            objDel.BeginInvoke(null, null);
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static void Display()
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display");
        }
    }
}


//using parameters in the func
namespace AsyncCodeUsingDelegates2
{
    class Program
    {
        static void Main1()
        {
            Action<string> objDel = Display;
            Console.WriteLine("before");
            //starts Display on a separate Thread
            objDel.BeginInvoke("aaa", null, null);
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static void Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display"  + s);
        }
    }
}


//using a callback function
namespace AsyncCodeUsingDelegates3
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("before");
            objDel.BeginInvoke("aaa", new AsyncCallback( CallBackFunc), null);
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display" + s);
            return s.ToUpper();
        }
        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("Callback func called");
        }
    }
}


//using a callback function and getting the return value from Display using global variable
namespace AsyncCodeUsingDelegates4
{
    class Program
    {
        static Func<string, string> objDel = Display;
        static void Main1()
        {
            Console.WriteLine("before");
            objDel.BeginInvoke("aaa", new AsyncCallback(CallBackFunc), null);

            Console.WriteLine("after");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display" + s);
            return s.ToUpper();
        }
        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("Callback func called");
            string retval = objDel.EndInvoke(ar);
            Console.WriteLine("retval is " + retval);
        }
    }
}


//using a callback function and getting the return value from Display using Anonymous method
namespace AsyncCodeUsingDelegates5
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("before");
            objDel.BeginInvoke("aaa", 
                delegate(IAsyncResult ar)
                {
                    Console.WriteLine("Callback func called");
                    string retval = objDel.EndInvoke(ar);
                    Console.WriteLine("retval is " + retval);
                } 
                , null);

            Console.WriteLine("after");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display" + s);
            return s.ToUpper();
        }
    }
}

//using a callback function to get return value using AsyncResult
namespace AsyncCodeUsingDelegates6
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("before");
            objDel.BeginInvoke("aaa", new AsyncCallback(CallBackFunc), null);
            //while (!ar.IsCompleted) ;
            //if (ar.IsCompleted)
            //{
            //    string retval;
            //    retval = objDel.EndInvoke(ar);
            //}
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display" + s);
            return s.ToUpper();
        }
        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("Callback func called");
            AsyncResult objAr = (AsyncResult)ar;

            Func<string, string> objDel = (Func<string, string>)objAr.AsyncDelegate;

            string retval = objDel.EndInvoke(ar);
            Console.WriteLine(retval);

        }
    }
}


//using a callback function using last parameter (object)
namespace AsyncCodeUsingDelegates7
{
    class Program
    {
        static void Main1()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("before");
            objDel.BeginInvoke("aaa", new AsyncCallback(CallBackFunc), "passed from calling func");
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display" + s);
            return s.ToUpper();
        }
        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("Callback func called");
            string state = ar.AsyncState.ToString();
            Console.WriteLine("passed value was " + state );
        }
    }
}


//using a callback function using last parameter (object)
namespace AsyncCodeUsingDelegates8
{
    class Program
    {
        static void Main()
        {
            Func<string, string> objDel = Display;
            Console.WriteLine("before");
            objDel.BeginInvoke("aaa", new AsyncCallback(CallBackFunc), objDel);
            Console.WriteLine("after");
            Console.ReadLine();
        }
        static string Display(string s)
        {
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("display" + s);
            return s.ToUpper();
        }
        static void CallBackFunc(IAsyncResult ar)
        {
            Console.WriteLine("Callback func called");
            Func<string, string> objDel =(Func<string, string>)ar.AsyncState;
            string retval = objDel.EndInvoke(ar);
            Console.WriteLine(retval);
        }
    }
}

