using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticMembers
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(Class1.si);
            Class1 o1 = new Class1();
            Class1 o2 = new Class1();
            o1.i = 100;
            o2.i = 200;

            Console.WriteLine(o1.i);
            Console.WriteLine(o2.i);

            Class1.si = 1000;


            Console.WriteLine(Class1.si);

            Class1.SDisplay();


            Class1.P1 = 1000;

            Console.ReadLine();
        }
    }

    public class Class1
    {
        public int i;
        public static int si; //single copy for all objects(shared data)

        public void Display()
        {
            Console.WriteLine(i);
            Console.WriteLine(si);
            Console.WriteLine("d");
        }
        public static void SDisplay() //can be called directly by classname.methodname
            //need not create an object to call the method
        {
            //Console.WriteLine(i); error - cannot access non static data directly
            Console.WriteLine(si);
            Console.WriteLine("Static d");
        }

        private static int p1;
        public static int P1
        {
            get { return p1; }
            set { p1 = value; }
        }

        static Class1()
        {
            Console.WriteLine("static cons called");
            si = 12345;
            P1 = 123456;

        }

    }

    //static class -- can only have static members , cannot instantiate, cannnot inherit from a static class
    //to do -> create static class

}


//static variable --> single copy
//property --> validations
//static property -->single copy with validations


//constructor --> initialise class data

//static constructor --> initialise static data 



