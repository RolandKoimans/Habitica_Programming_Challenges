using System;
using System.Collections.Generic;

namespace PolygonArea
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());

            List<int> xs = new List<int>();
            List<int> ys = new List<int>();

            //Read input
            for(int i = 0; i < n; i++)
            {
                string[] inp = Console.ReadLine().Split(" ");

                xs.Add(Int32.Parse(inp[0]));
                ys.Add(Int32.Parse(inp[1]));
            }

            //Fill in shoelace formula
            int area = 0;
            for(int i = 0; i < n-1; i++)
            {
                area += xs[i] * ys[i + 1] - ys[i] * xs[i + 1];
            }

            //Last one wraps around so has to be outside the loop
            area += xs[n-1] * ys[0] - ys[n-1] * xs[0];

            Console.WriteLine(Math.Abs(area));

        }
    }
}
