using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.Insert();

            IDbFunctions oIDb;
            oIDb = o;
            oIDb.Insert();

            ((IDbFunctions)o).Insert();


            Console.ReadLine();
        }
        static void Main2()
        {
            Class1 o = new Class1();
            ((IDbFunctions)o).Delete();

            IFileFunctions oIFile;
            oIFile = o;
            oIFile.Delete();

            ((IFileFunctions)o).Delete();

            //IDbFunctions oIDb;
            //oIDb = o;
            //oIDb.Insert();

            //((IDbFunctions)o).Insert();


            Console.ReadLine();
        }
    }
    public class Class1 : IDbFunctions, IFileFunctions
    {
        void IDbFunctions.Delete()
        {
            Console.WriteLine(  "Idb.Delete from Class1");
        }

        public void Insert()
        {
            Console.WriteLine("Idb.Insert from Class1");
        }

        public void Update()
        {
            Console.WriteLine("Idb.Update from Class1");
        }
        public void Display()
        {
            Console.WriteLine("Display from Class1");
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        void IFileFunctions.Delete()
        {
            Console.WriteLine("IFile.Delete from Class1");
        }
    }

    public interface IDbFunctions
    {
        void Insert();
        void Delete();
        void Update();

    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
}
namespace Interfaces2
{
    class Program
    {
        static void Main()
        {
            Class1 o1 = new Class1();
            Class2 o2 = new Class2();
            //Class3 o3 = new Class3();

            InsertIntoDb(o1);
            InsertIntoDb(o2);

            Console.ReadLine();
        }
        static void InsertIntoDb(IDbFunctions oIDb)
        {
            oIDb.Insert();
        }
    }
    public class Class1 : IDbFunctions, IFileFunctions
    {
        void IDbFunctions.Delete()
        {
            Console.WriteLine("Idb.Delete from Class1");
        }

        public void Insert()
        {
            Console.WriteLine("Idb.Insert from Class1");
        }

        public void Update()
        {
            Console.WriteLine("Idb.Update from Class1");
        }
        public void Display()
        {
            Console.WriteLine("Display from Class1");
        }

        public void Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        void IFileFunctions.Delete()
        {
            Console.WriteLine("IFile.Delete from Class1");
        }
    }
    public class Class2 : IDbFunctions
    {
        void IDbFunctions.Delete()
        {
            Console.WriteLine("Idb.Delete from Class2");
        }

        public void Insert()
        {
            Console.WriteLine("Idb.Insert from Class2");
        }

        public void Update()
        {
            Console.WriteLine("Idb.Update from Class2");
        }
        public void Display()
        {
            Console.WriteLine("Display from Class1");
        }

    }

    public interface IDbFunctions
    {
        void Insert();
        void Delete();
        void Update();

    }
    public interface IFileFunctions
    {
        void Open();
        void Close();
        void Delete();
    }
}
