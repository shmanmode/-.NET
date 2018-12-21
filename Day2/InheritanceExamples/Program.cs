using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExamples1
{
    class Program
    {
        static void Main1()
        {
            BaseClass o = new BaseClass();
            //o.
            TestAccessSpecifiers.BaseClass o2 = new TestAccessSpecifiers.BaseClass();
            //o2.

        }
    }

    public class BaseClass
    {
        public int PUBLIC;
        private int PRIVATE;
        protected int PROTECTED;
        internal int INTERNAL;
        protected internal int PROTECTED_INTERNAL;
    }
    public class DerivedClass : TestAccessSpecifiers.BaseClass  //BaseClass 
    {
        void DoNothing()
        {
            //this.
        }
    }


}
namespace BaseClassConstructor
{
    class Program
    {
        static void Main2()
        {
            DerivedClass o = new DerivedClass(10,20);
            Console.ReadLine();
        }
    }

    class BaseClass
    {
        public int i;
        public BaseClass()
        {
            this.i = 10;
            Console.WriteLine("BC V");
        }
        public BaseClass(int i)
        {
            this.i = i;
            Console.WriteLine("BC I");
        }

    }
    class DerivedClass : BaseClass
    {
        public int j;
        public DerivedClass()
        {
            this.j = 20;
            Console.WriteLine("DC V");
        }
        public DerivedClass(int i, int j) : base(i)
        {
  
            this.j = j;
            Console.WriteLine("DC I");
        }

    }
}

namespace SameNameFuncs
{
    class Program
    {
        static void Main1()
        {
            DerivedClass o = new DerivedClass();
            o.Display1();
            o.Display1("aa");

            o.Display2();
            o.Display3();

            Console.ReadLine();
        }
        static void Main2()
        {
            BaseClass o;
            o = new BaseClass();
            o.Display2();  //early bound(compile time binding)...depends on how it has been declared
            o.Display3(); //late bound(run time binding)... depends on what it is pointing to

            Console.WriteLine();

            o = new DerivedClass();
            o.Display2();  //early bound(compile time binding)...depends on how it has been declared
            o.Display3(); //late bound(run time binding)... depends on what it is pointing to

            Console.WriteLine();
            o = new SubDerivedClass();
            o.Display2();  //early bound(compile time binding)...depends on how it has been declared
            o.Display3(); //late bound(run time binding)... depends on what it is pointing to

            Console.WriteLine();
            o = new SubSubDerivedClass();
            o.Display2();  //early bound(compile time binding)...depends on how it has been declared
            o.Display3(); //late bound(run time binding)... depends on what it is pointing to


            Console.ReadLine();
        }
    }
    class BaseClass
    {
        public void Display1()
        {
            Console.WriteLine("Base Display1");
        }
        public void Display2()
        {
            Console.WriteLine("Base Display2");
        }
        public virtual void Display3()
        {
            Console.WriteLine("Base Display3");
        }
    }
    class DerivedClass : BaseClass
    {
        public void Display1(string s) //overloading the method in the Derived Class
        {
            Console.WriteLine("Derived Display1" + s);
        }
        public new void Display2() //Hiding the base class method
        {
            Console.WriteLine("Derived Display2");
        }

        public override void Display3() //overriding the base class method
        {
            Console.WriteLine("Derived Display3");
        }
    }

    class SubDerivedClass : DerivedClass
    {
        public sealed override void Display3()
        {
            Console.WriteLine("SubDerived Display3");

        }
    }
    class SubSubDerivedClass : SubDerivedClass
    {
        public new void Display3()
        {
            Console.WriteLine("SubDerived Display3");

        }
    }

}
namespace AbstractClassEg
{
    class Program
    {

        static void Main()
        {
            //BaseClass o = new BaseClass();
            DerivedClass o = new DerivedClass();
            o.DoSomething();
            o.Show();
            Console.ReadLine();
        }
    }

    public abstract class BaseClass
    {
        public abstract void Display(); //pure virtual function
        public abstract void Show();

        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    }

    public class DerivedClass : BaseClass
    {
        public override void Display()
        {
            Console.WriteLine("displ");
        }

        public override void Show()
        {
            Console.WriteLine("show");
        }
    }
}


//TO DO : Create a sealed class


