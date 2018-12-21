using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects
{
    class Program
    {
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();
        static void Main1()
        {
            AddRecs();
            //from singleobject in collection select something
            //IEnumerable<Employee> emps = from Emp in lstEmp select Emp;
            //List<Employee> emps = (List<Employee>)from Emp in lstEmp select Emp;
            var emps = from Emp in lstEmp select Emp;

            foreach (var x in emps)
            {
                Console.WriteLine(x.Name);
            }

            Console.WriteLine();

            lstEmp.Add(new Employee { Name = "new emp" });

            foreach (var x in emps)
            {
                Console.WriteLine(x.Name);
            }

            Console.ReadLine();

        }
        static void Main2()
        {
            AddRecs();
            //IEnumerable<string> emps = from Emp in lstEmp select Emp.Name;
            var emps = from Emp in lstEmp select Emp.Name;


            foreach (var x in emps)
            {
                Console.WriteLine(x);
            }
            Console.ReadLine();

        }
        static void Main3()
        {
            AddRecs();
            //IEnumerable<string> emps = from Emp in lstEmp select Emp.Name;
            
            var emps = from Emp in lstEmp select new { Emp.Name, Emp.Basic };
            foreach (var x in emps)
            {
                Console.WriteLine(x.Name);
            }
            Console.ReadLine();

        }

        static void Main4()
        {
            AddRecs();
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000
            //           select emp;
            //var emps = from emp in lstEmp
            //           where emp.Basic > 10000 && emp.Basic < 12000
            //           select emp;

            //var emps = from emp in lstEmp
            //           where emp.Basic == 10000 || emp.Basic == 12000
            //           select emp;
            var emps = from emp in lstEmp
                       where emp.Name.StartsWith("V")
                       select emp;

            foreach (var item in emps)
                Console.WriteLine(item.Name + " : " + item.Basic);

            Console.ReadLine();
        }

        static void Main5()
        {
            AddRecs();
            //var emps = from emp in lstEmp
            //           where (emp.EmpNo < 5 || emp.Basic == 10000)
            //           orderby emp.Name
            //           select emp;
            //var emps = from emp in lstEmp
            //           orderby emp.Name
            //           select emp;
            //var emps = from emp in lstEmp
            //           orderby emp.Name ascending
            //           select emp;

            //var emps = from emp in lstEmp
            //           orderby emp.Name descending
            //           select emp;

            //var emps = from emp in lstEmp
            //           orderby emp.DeptNo ascending, emp.Name descending
            //           select emp;
            //foreach (var item in emps)
            //    Console.WriteLine(item.Name + " : " + item.Basic + ":" + item.DeptNo);

            var emps = from emp in lstEmp
                       join dept in lstDept
                             on emp.DeptNo equals dept.DeptNo
                       select new { dept.DeptName, emp.Name };

            foreach (var item in emps)
                Console.WriteLine(item.DeptName + " : " + item.Name);

            Console.ReadLine();
        }
        static void Main7()
        {
            AddRecs();
            var emps = lstEmp.Select(emp => emp);
            //var emps2 = lstEmp.Select(emp => emp.Basic);
            //var emps3 = lstEmp.Select(emp => new { emp.EmpNo, emp.Name});


            foreach (var item in emps)
                Console.WriteLine(item.EmpNo + " : " + item.Name);

            Console.ReadLine();
        }
        static void Main8()
        {
            AddRecs();
            //var emps = from emp in lstEmp where emp.EmpNo > 5 select emp;

            //var emps = lstEmp.Where(emp => emp.EmpNo > 5).Select(emp => emp);
            //var emps = lstEmp.Where(emp => emp.EmpNo > 5).Select(emp => emp.Name);
            //var emps = lstEmp.Where(emp => emp.EmpNo > 5).Select(emp => emp);
            var emps = lstEmp.Where(emp => emp.EmpNo > 5);

            foreach (var item in emps)
                Console.WriteLine(item.EmpNo + " : " + item.Name);

            Console.ReadLine();
        }

        static void Main10()
        {
            //var emps = from emp in lstEmp orderby emp.Name select emp;

            var x = lstEmp.OrderBy(emp => emp.Name);

            AddRecs();
            var emps = lstEmp.OrderBy(emp => emp.DeptNo).OrderBy(emp => emp.Basic).OrderBy(emp => emp.Name);
            var emps2 = lstEmp.OrderByDescending(emp => emp.Basic);

            foreach (var item in emps)
                Console.WriteLine(item.EmpNo + " : " + item.Name);

            Console.ReadLine();
        }

        static void Main()
        {
            //    var emps = from emp in lstEmp
            //               join dept in lstDept
            //                     on emp.DeptNo equals dept.DeptNo
            //               select new { dept.DeptName, emp.Name };
            AddRecs();
            var emps = lstEmp.Join(lstDept, emp => emp.DeptNo, dep => dep.DeptNo, (emp, dep) => new { emp.Name, dep.DeptName });

            foreach (var item in emps)
                Console.WriteLine(item.Name + " : " + item.DeptName);

            Console.ReadLine();
        }

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });

            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "F" });
            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "M" });
            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "F" });
        }

    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }
    }

}
