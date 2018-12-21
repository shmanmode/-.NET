using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntegerStack objInt = new IntegerStack(3);
            //objInt.Push(10);
            //objInt.Push(20);
            //objInt.Push(30);

            //Console.WriteLine(objInt.Pop());
            //Console.WriteLine(objInt.Pop());
            //Console.WriteLine(objInt.Pop());

            MyStack<int> obj = new MyStack<int>(3);
            obj.Push(10);
            obj.Push(20);
            obj.Push(30);

            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());
            Console.WriteLine(obj.Pop());

            MyStack<string> obj2 = new MyStack<string>(3);
            obj2.Push("a");
            obj2.Push("b");
            obj2.Push("c");

            Console.WriteLine(obj2.Pop());
            Console.WriteLine(obj2.Pop());
            Console.WriteLine(obj2.Pop());

            Console.ReadLine();
        }
    }
    class MyStack<T> //where T : struct
    {
        T[] arr;
        public MyStack(int Size)
        {
            arr = new T[Size];
        }
        int Pos = -1;
        public void Push(T i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public T Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }


    class IntegerStack
    {
        int[] arr;
        public IntegerStack(int Size)
        {
            arr = new int[Size];
        }
        int Pos = -1;
        public void Push(int i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public int Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
    class StringStack
    {
        string[] arr;
        public StringStack(int Size)
        {
            arr = new string[Size];
        }
        int Pos = -1;
        public void Push(string i)
        {
            if (Pos == (arr.Length - 1))
                throw new Exception("Stack full");
            arr[++Pos] = i;
        }
        public string Pop()
        {
            if (Pos == -1)
                throw new Exception("Stack Empty");
            return arr[Pos--];
        }
    }
}
/*
 CONSTRAINTS
 class MyStack<T> where T : class --> T must be a reference type
 class MyStack<T> where T : struct --> T must be a value type
 class MyStack<T> where T : Employee --> T must be Employee class or a derived class of Employee
 class MyStack<T> where T : IDbFunctions --> T must be a class that implements IDbFunctions
 class MyStack<T> where T : new() --> T must have a no parameter constructor

 class MyStack<T> where T : Employee, IDbFunctions
 class MyStack<T> where T : Employee, IDbFunctions, new()
    
    */
