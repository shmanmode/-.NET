using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionExample
{
    class Program
    {
        static void Main1()
        {
            ArrayList o = new ArrayList();
            o.Add(10);
            o.Add("sss");
            o.Add(true);
            //o.AddRange()
            //o.Insert
            //o.InsertRange

            o.Remove(10);
            //o.RemoveAt
            //o.RemoveRange

            foreach (object obj in o)
                Console.WriteLine(obj.ToString());
            Console.ReadLine();
        }

        static void Main2()
        {
            //Hashtable h = new Hashtable();
            SortedList h = new SortedList();

            h.Add("a", "A data");
            h.Add("b", "B data");
            h.Add("c", "C data");
            //h.Add("c", "C data new");
            h.Add("d", "D data");
            h.Add("e", "E data");
            h.Add("f", "F data");

            h["c"] = "New c data";
            h["x"] = "x data";

            foreach (DictionaryEntry de in h)
                Console.WriteLine(de.Key + ":" + de.Value);

            Console.ReadLine();
        }
        static void Main3()
        {
            Queue q = new Queue();
            //q.Peek
            //q.Enqueue()
            q.Dequeue();


            Stack st = new Stack();
            //st.p
            //st.Push();

        }
        static void Main4(string[] args)
        { 
            List<int> o = new List<int>();
            o.Add(10);
            o.Add(20);
            o.Add(30);

            o.RemoveAt(0);
            foreach (int obj in o)
                Console.WriteLine(obj.ToString());

            SortedList<int, string> objSortedList = new SortedList<int, string>();
            objSortedList.Add(1, "aa");
            objSortedList[2] = "bb";
            foreach (KeyValuePair<int, string> objKvp in objSortedList)
            {
                Console.WriteLine(objKvp.Key);
                Console.WriteLine(objKvp.Value);
            }

            Queue<int> q = new Queue<int>();
            //q.Enqueue(10)
            Stack<string> st = new Stack<string>();
            //st.Push("aa")


            Console.ReadLine();
        }

        static void Main5()
        {
            List<Employee> objList = new List<Employee>();
            Employee objEmp = new Employee();
            objEmp.Empno = 1;
            objEmp.Name = "A";
            objList.Add(objEmp);
            objList.Add(new Employee { Empno = 2, Name = "B" }); //object initializer
            objList.Add(new Employee { Empno = 3, Name = "C" });
            foreach (Employee e in objList)
            {
                Console.WriteLine(e.Name);
            }
            Console.ReadLine();
        }
        static void Main()
        {
            SortedList<int, Employee> objList = new SortedList<int, Employee>();

            objList.Add(1, new Employee { Empno = 1, Name = "A" });
            objList.Add(2, new Employee { Empno = 2, Name = "B" });
            objList.Add(3, new Employee { Empno = 3, Name = "C" });
            objList.Add(4, new Employee { Empno = 4, Name = "D" });

            foreach (KeyValuePair<int, Employee> objKvp in objList )
            {
                Console.WriteLine(objKvp.Key);
                Console.WriteLine(objKvp.Value.Name);
            }



            Console.ReadLine();
        }

    }

    public class Employee
    {
        private int empno;

        public int Empno
        {
            get { return empno; }
            set { empno = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
