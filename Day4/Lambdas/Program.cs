using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncActionAndPredicate
{
    class Program
    {
        public delegate void Del1();

        static void Main1()
        {
            //Del1 o = Display;
            //o();
            //Action o1 = new Action(Display);
            Action o1 = Display;
            o1();

            Action<string> o2 = Display;
            o2("aaa");

            Action<string,int> o3 = Display;
            o3("aaa",10);


            Console.ReadLine();
        }
        static void Main2()
        {
            Func<int, int, int> o = Add;
            Console.WriteLine(o(10, 20));
            Console.ReadLine();
        }
        static void Main3()
        {
            Func<int, bool> o1 = IsEven;
            Console.WriteLine(o1(5));

            Predicate<int> o2 = IsEven;
            Console.WriteLine(o2(6));

            Console.ReadLine();
        }

        static void Display()
        {
            Console.WriteLine("Disp");
        }
        static void Display(string s)
        {
            Console.WriteLine("Disp" + s);
        }
        static void Display(string s, int i)
        {
            Console.WriteLine("Disp" + s);
        }
        static int Add(int a, int b)
        {
            return a + b;
        }
        static bool IsEven(int a)
        {
            return (a % 2==0);
        }

    }
}

namespace Lambdas
{
    class Program
    {
        static void Main1()
        {
            Func<int, int> o1 = DoubleOfNum;
            Console.WriteLine(o1(5));

            //(Parameters) => Statements
            Func<int, int> o2 = i => i * 2;
            Console.WriteLine(o2(2));

            Func<int, int, int> o3 = (x, y) => x + y;
            Console.WriteLine(o3(10,20));

            Predicate<int> o4 = x => x % 2 == 0;
            Console.WriteLine(o4(100));

            Func<int,bool> o5 = x => x % 2 == 0;
            Console.WriteLine(o5(100));

            Predicate<Employee> o6 = x => x.Basic > 10000;
            Console.WriteLine(o6(new Employee { Basic = 12000 }));
            Console.WriteLine(o6(new Employee { Basic = 2000 }));


            Console.ReadLine();
        }
        static void Main()
        {
            Func<int, int, int, int> o = (n1, n2, n3) =>
            {
                if (n1 > n2)
                    if (n1 > n3)
                    { }
                        //.....

                        return n1;
            };
        }
            static int DoubleOfNum(int i)
        {
            return i * 2;
        }
        static bool CheckSalary(Employee obj)
        {
            return obj.Basic > 10000;
        }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
    }
}
