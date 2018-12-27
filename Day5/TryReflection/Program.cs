using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryReflection
{
    class Program
    {

        static void Main()
        {
            Assembly asm = Assembly.LoadFrom(@"C:\Users\labadmin\Desktop\Vikram\Day1\BasicClassConcepts\bin\Debug\BasicClassConcepts.exe");

            Console.WriteLine( asm.FullName);

            Type[] arrTypes = asm.GetTypes();
            foreach (Type t in arrTypes)
            {
                Console.WriteLine("    " + t.Name);
                //MethodInfo [] arrMethods = t.GetMethods();
            }

            Console.ReadLine();
        }
    }
}
