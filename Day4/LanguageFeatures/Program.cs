using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitVariables
{
    class Program
    {
        static void Main1()
        {

            int i = 0;
            bool b = true;
            string s = "Hello";

            //implicit variables
            var i2 = 0;
            var b2 = true;
            var s2 = "Hello";
            Console.WriteLine("i2 is a: {0}", i2.GetType().Name);
            Console.WriteLine("b2 is a: {0}", b2.GetType().Name);
            Console.WriteLine("s2 is a: {0}", s2.GetType().Name);

            Console.ReadLine();

        }
    }
}
namespace ObjectInitializers
{
    class Program
    {
        static void Main1()
        {
            //Class1 o = new Class1();
            //o.P1 = 10;
            //o.P2 = "a";

            Class1 o1 = new Class1() { P1 = 10, P2 = "a" };
            Class1 o2 = new Class1 { P1 = 10, P2 = "a" };


            Class1 o3 = new Class1(20,"b") { P1 = 10, P2 = "a" };
            Console.WriteLine(o3.P1);
            Console.WriteLine(o3.P2);
            Console.ReadLine();

        }
    }
    public class Class1
    {
        public Class1()
        {
        }
        public Class1(int P1, string P2)
        {
            this.P1 = P1;
            this.P2 = P2;

        }
        public int P1 { get; set; }
        public string P2 { get; set; }

    }
}

namespace AnonymousMethods
{
    class Program
    {
        public delegate void Del1();
        static void Main1()
        {
            //Del1 o = new Del1(Method1);
            //o();
            Del1 o = delegate () { Console.WriteLine("method called"); };
            o();

            Console.ReadLine();
        }
        static void Main2()
        {
            int i = 100;
            //Del1 o = new Del1(Method1);
            //o();
            Del1 o = delegate () 
            {
                Console.WriteLine("anon method called");
                i++;
            };
            Console.WriteLine(i);
            Console.WriteLine(i);
            Console.ReadLine();
        }
        static void Method1()
        {
            Console.WriteLine("method called");
        }
    }
}

namespace AnonymousTypes
{
    class Program
    {
        static void Main1()
        {

            var myCar = new { Color = "Red", Model = "Ferrari", Version = "V1", CurrentSpeed = 75 };
            var myCar2 = new { Color = "Blue", Model = "Merc", CurrentSpeed = 75 };
            Console.WriteLine(myCar.Color);
            Console.WriteLine(myCar2.Color);

            Console.WriteLine(myCar.GetType().ToString());
            Console.WriteLine(myCar2.GetType().ToString());


            Console.ReadLine();
        }
    }
}

namespace ExtensionMethods
{
    class Program
    {
        static void Main1()
        {
            int i = 100, j = 200;
            j = i.Add(5);
            j.PrintInt();  //=> 
            ExtensionMethodsClass.PrintInt(j);


            string s = "a";
            s.DoSomethingForTheBaseClass();
            i.DoSomethingForTheBaseClass();

            ClsMaths objMath = new ClsMaths();
            Console.WriteLine(objMath.Subtract(20, 10));


            Console.ReadLine();
        }

        static void PrintInt(int a)
        {
            Console.WriteLine(a);
        }
    }
    //- Extension methods must be declared inside a static class
    //- Mark a method as an extension method by using the --this-- keyword as a modifier 
    //           on the first parameter of the method
    //- Every extension method can be called either from the object or statically via the defining static class

    static class ExtensionMethodsClass
    {
        public static void PrintInt(this int x)
        {
            Console.WriteLine(x);
        }
        //Extension method for base class is available for all derived classes
        public static void DoSomethingForTheBaseClass(this object x)
        {
            Console.WriteLine("ext method");
        }
        public static int Add(this int x, int y)
        {
            return x + y;
        }

       
    }

    public interface IMathOperations
    {
        int Add(int a, int b);
        int Multiply(int a, int b);
    }
    public class ClsMaths : IMathOperations
    {

        #region IMathOperations Members

        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        #endregion
    }

    //Extension method for Interface available for all classes that implement that Interface
    public static class ExtensionMethodForInterface
    {
        public static int Subtract(this IMathOperations imop, int a, int b)
        {
            return a - b;
        }
    }

}


namespace PartialMethods
{
    public class MainClass
    {
        public static void Main()
        {
            Class1 o = new Class1();
            Console.WriteLine(o.Check());
            Console.ReadLine();
        }
    }

    //Partial methods can only be defined within a partial class.
    //Partial methods must return void.
    //Partial methods can be static or instance level.
    //Partial methods cannnot have out params
    //Partial methods are always implicitly private.
    public partial class Class1
    {
        private bool isValid = true;
        partial void Validate();
        public bool Check()
        {
            Validate();
            return isValid;
        }
    }
    public partial class Class1
    {
        partial void Validate()
        {
            //perform some validation code here
            isValid = false;
        }
    }

}
