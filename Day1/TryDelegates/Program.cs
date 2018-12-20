using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryDelegates
{
    //step 1: create a delegate class having the same sign as the method to call
    public delegate void Del1();

    public delegate int Del2(int a, int b);

    class Program
    {
        static void Main1()
        {
            //step 2: create obj of del class passing fn name as a param
            Del1 objDel = new Del1(Display);

            //step 3: call fn with del obj
            objDel();
            Console.ReadLine();
        }
        static void Main2()
        {
            //Del1 objDel = new Del1(Display);
            Del1 objDel;
            objDel = new Del1(Display);
            objDel();
            objDel = new Del1(Show);
            objDel();
            Console.ReadLine();
        }
        static void Main3()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel += new Del1(Show);
            objDel();

            Console.ReadLine();
        }
        static void Main4()
        {
            Del1 objDel;
            objDel = new Del1(Display);
            objDel += new Del1(Show);
            objDel += new Del1(Display);
            objDel += new Del1(Show);
            objDel();

            objDel -= new Del1(Display);
            Console.WriteLine();
            objDel();

            Console.ReadLine();
        }
        static void Main5()
        {
            Del2 objDel2 = new Del2(Add);

            int ans;
            ans = objDel2(10, 20);
            Console.WriteLine(ans);

            Console.ReadLine();

        }
        static void Main6()
        {
            Del1 o = new Del1(Class2.Display);


            Class2 objCls2 = new Class2();
            o = new Del1(objCls2.Show);
            o = new Del1(n2.Class2.Display);


            Console.ReadLine();

        }
        static void Main8()
        {
            Del1 o = new Del1(Display);
            o = Display;
            o += Show;
            o += Display;
            o += Show;

            o();

            Console.WriteLine();

            //Object Delegate MultiCastDelegate YourDel


            Del1 o1 = Display;
            Del1 o2 = Show;

            o = (Del1)Delegate.Combine(o1, o2);
            o();
            o= (Del1)Delegate.Combine(o, o1,o2);
            Console.WriteLine();
            o();
            Console.WriteLine();
            o = (Del1)Delegate.RemoveAll(o, o1);
            o();

            Console.ReadLine();

        }
        static void Main7()
        {
            Del1 o = new Del1(Display);
            o = Display;
            o += Show;
            o -= Display;

            Console.ReadLine();

        }
        static void Display()
        {
            Console.WriteLine("disp called");
        }
        static void Show()
        {
            Console.WriteLine("show called");
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int CallMathOperation(Del2 objMathOperation, int a, int b)
        {
            //return Add(a, b);
            //return Subtract(a, b);
            return objMathOperation(a, b);
        }

        static void Main()
        {
            Console.WriteLine(CallMathOperation( new Del2(Add) , 10, 20));
            Console.WriteLine(CallMathOperation(Add, 10, 20));
            Console.WriteLine(CallMathOperation(Subtract, 10, 20));
            Console.WriteLine(CallMathOperation(Multiply, 10, 20));
            Console.ReadLine();
        }



    }

    class Class2
    {
        public static void Display()
        {
            Console.WriteLine("disp called");
        }
        public void Show()
        {
            Console.WriteLine("disp called");
        }

    }
}

namespace n2
{
    class Class2
    {
        public static void Display()
        {
            Console.WriteLine("disp called");
        }
        public void Show()
        {
            Console.WriteLine("disp called");
        }

    }


}

//andrew troelsen - Pro CSharp 2017