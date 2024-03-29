﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Csharp.ConsoleApp
{
    class Program
    {
        [DllImport("Project.dll")]
        private static extern int Sum(int y, int b);

        [DllImport("Project.dll")]
        private static extern int SumArr([In] int[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void ToUpper([In, Out]char[] arr, int sz);

        [DllImport("Project.dll")]
        private static extern void GrayScale([In, Out]int[] arrR, [In]int[] arrG, [In]int[] arrB, int sz);

        static void Main(string[] args)
        {
            int[] x = { 1, 2, 3 };
            char[] c = "How are u?".ToCharArray();

            //test SumArr procedure
            Console.Write(SumArr(x, x.Length));
            Console.WriteLine();

            //test ToUpper procedure
            Console.Write(c, 0, c.Length);
            Console.WriteLine();

            ToUpper(c, c.Length);
            Console.Write(c, 0, c.Length);
            Console.WriteLine();

            int[] r = new int[4];
            r[0] = 125;
            r[1] = 125;
            r[2] = 125;
            r[3] = 125;
            GrayScale(r, r, r, 4);
            Console.Write(r[0]);
            Console.WriteLine();
        }
    }
}
