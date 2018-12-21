using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefAndValue2
{
    class Program
    {
        static void Main1(string[] args)
        {
            //int i = 100;
            //int j = 200;
            int i, j;
            Initialize(out i, out j);
            Swap(ref i,ref j);
            Console.WriteLine(i);
            Console.WriteLine(j);
            Console.ReadLine();
        }

        static void Swap(ref int i, ref int j)
        {
            int temp = i;
            i = j;
            j = temp;
        }
        static void Initialize(out int i, out int j)
        {
            i = 1000;
            j = 2000;
        }
    }
}

namespace NullableTypes
{
    class P
    {
        static void Main2()
        {
            //nullable types
            int? i = 100;
            i = null;
            int j;
            if (i != null)
                j = (int)i;
            else
                j = 0;
            if (i.HasValue)
                j = i.Value;
            else
                j = 0;
            j = i.GetValueOrDefault();
            j = i.GetValueOrDefault(10);
            j = i ?? 10;
        }
    }
}

namespace PassingRefTypes
{
    class Program2
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.i = 1;
            //DoSomething1(o);
            //DoSomething2(o);
            DoSomething3(ref o);
            Console.WriteLine(o.i);
            Console.ReadLine();
        }
        static void DoSomething1(Class1 o)
        {
            o.i = 100;
        }
        static void DoSomething2(Class1 o)
        {
            o = new Class1();
            o.i = 1000;
        }
        static void DoSomething3(ref Class1 o)
        {
            o = new Class1();
            o.i = 1000;
        }

        static void Main2()
        {
            //byte b1;
            //sbyte b2;
            //char ch;
            //short sh1;
            //ushort sh2;
            //int i1;
            //uint i2;
            //long l1;
            //ulong l2;
            //float f;
            //double d;
            //decimal d2;
            //bool b;

            //string s;
            //object o;

        }


    }
    public class Class1
    {
        public int i;
    }
}
