using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructExample
{
    class Program
    {
        static void Main1()
        {
            //int i = 0;
            //int i = new int();
            //Console.WriteLine(i);

            //MyPoint p;
            //p.X = 10;
            //p.Y = 20;

            MyPoint p = new MyPoint();
            Console.WriteLine(p.X);
            Console.WriteLine(p.Y);

            Console.ReadLine();
        }
    }

    public struct MyPoint
    {
        public int X, Y;
        //public MyPoint(int X, int Y)
        //{
        //    this.X = X;
        //    this.Y = Y;
        //}
    }

}
namespace EnumExample
{
    class Program
    {
        static void Main()
        {

            //Display(1);
            DisplayWithEnum(TimeOfDay.Morning);
            Console.ReadLine();
        }
        static void Display(int i)
        {
            if (i == 0)
                Console.WriteLine("Good Morning");
            else if (i == 1)
                Console.WriteLine("Good Afternoon");
            else if (i == 2)
                Console.WriteLine("Good Evening");
            else if (i == 3)
                Console.WriteLine("Good Night");
        }
        static void DisplayWithEnum(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning )
                Console.WriteLine("Good Morning");
            else if (t == TimeOfDay.Afternoon)
                Console.WriteLine("Good Afternoon");
            else if (t == TimeOfDay.Evening)
                Console.WriteLine("Good Evening");
            else if (t == TimeOfDay.Night)
                Console.WriteLine("Good Night");
        }
    }
    public enum TimeOfDay : short
    {
        Morning , Afternoon , Evening, Night
        //Morning = 10, Afternoon = 20, Evening, Night
    }

}
