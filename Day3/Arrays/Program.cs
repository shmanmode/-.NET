using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main1()
        {
            int[] arr = new int[5];
            Console.WriteLine(arr.Rank);
            Console.WriteLine(arr.GetUpperBound(0));

            //Array.Clear()
            //Array.Copy
            //Array.ConstrainedCopy
            int pos = Array.IndexOf(arr, 10);
            pos = Array.LastIndexOf(arr, 10);
            pos = Array.BinarySearch(arr, 10);
            //if(pos == -1)

            //Array.Sort
            //Array.Reverse


            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32( Console.ReadLine()); 
            }

            foreach (int x in arr)
            {
                Console.WriteLine(x);
            }

            Console.ReadLine();

        }
        static void Main2()
        {
            int[,] arr = new int[5, 3];
            Console.WriteLine(arr.Rank);
            Console.WriteLine(arr.Length);
            Console.WriteLine(arr.GetLength(0));
            Console.WriteLine(arr.GetLength(1));
            Console.WriteLine(arr.GetUpperBound(1));

            arr[0, 0] = 100;
            arr[4, 2] = 200;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    //arr[i,j]
                }
            }


            Console.ReadLine();
        }
        static void Main()
        {

            int[][] arr = new int[5][];

            arr[0] = new int[3];
            arr[1] = new int[5];
            arr[2] = new int[2];
            arr[3] = new int[8];
            arr[4] = new int[10];

            arr[0] = new int[] { 3, 5, 7, };
            arr[1] = new int[] { 1, 0, 2, 4, 6 };
            arr[2] = new int[] { 1, 6 };
            arr[3] = new int[] { 1, 0, 2, 4, 6, 45, 67, 78 };
            arr[4] = new int[] { 1, 0, 2, 4, 6, 34, 54, 67, 87, 78 };

            int[][] arr2 = new int[][]
            {
                new int[] { 3, 5, 7, },
                new int[] { 1, 0, 2, 4, 6 },
                new int[] { 1, 6 },
                new int[] { 1, 0, 2, 4, 6, 45, 67, 78 }
            };

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write("enter value for subscript {0},{1} : ", i, j);
                    arr2[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.WriteLine("value for subscript {0},{1} is {2}  ", i, j, arr2[i][j]);
                }
            }
            Console.ReadLine();
        }

    }
}
