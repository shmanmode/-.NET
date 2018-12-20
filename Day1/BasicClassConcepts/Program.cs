using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BasicClassConcepts
{
    class Program
    {
        static void Main1()
        {
            //System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
            //SqlConnection cn = new SqlConnection();
            //System.Console.WriteLine("Hello World");
            //Console.WriteLine("Hello World");

            Class1 obj;
            obj = new Class1();
            obj.Display();
            obj.Display("a");
            obj.Display2();
            obj.Display2("a");
            System.Console.ReadLine();
        }
        static void Main2()
        {

            Class1 obj;
            obj = new Class1();
            //obj.i = 100;
            //Console.WriteLine(obj.i);
            //obj.seti(10);
            //Console.WriteLine(obj.geti());

            obj.P1 = 1234;
            Console.WriteLine(obj.P1);
            //obj.P1 = ++obj.P1 + obj.P1++ - obj.P1-- - --obj.P1;


            obj.P3 = 1000;
            Console.WriteLine(obj.P3);

            System.Console.ReadLine();
        }

        static void Main()
        {
            Class1 o;
            //o = new Class1();
            o = new Class1(100, 200, 300);
            Console.WriteLine(o.P3);
            o = null;
            //System.GC.Collect();

            Console.ReadLine();
        }
    }

    public class Class1
    {
        #region Functions
        public void Display()
        {
            Console.WriteLine("Disp called");
        }
        public void Display(string s)
        {
            Console.WriteLine("Disp called" + s);
        }
        public void Display2(string s = "")
        {
            Console.WriteLine("Disp called" + s);
        }

        public int Add(int a=0, int b=0, int c=0)
        {
            return a + b + c;
        }

        #endregion
        #region Properties
        private int i;
        public void seti(int VALUE)
        {
            //if(VALUE <100)
            i = VALUE;
        }
        public int geti()
        {
            return i;
        }

        private int p1;
        public int P1
        {
            set
            {
                if(value <1000)
                    p1 = value;
                else
                    Console.WriteLine("invalid value");
            }
            get
            {
                return p1;
            }
        }
        //TO DO - Create a ReadOnly and a WriteOnly Property


        private int p2;
        public int P2
        {
            set
            {
                    p2 = value;
            }
            get
            {
                return p2;
            }
        }
        //automatic property
        //compiler generates the code for the property and also generates a private variable
        public int P3 { get; set; }
        #endregion

        #region Constructors
        public Class1()
        {
            Console.WriteLine("no param cons called");
        }
        public Class1(int P1, int P2, int P3)
        {
            Console.WriteLine("int cons called");
            this.P1 = P1;
            this.P2 = P2;
            this.P3= P3;
        }
        ~Class1()
        {
            Console.WriteLine("Des called");
        }
        #endregion
    }

}
