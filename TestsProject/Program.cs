using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public class Program
    {
        public static double Adding(double a, double b)
        {
            return a + b;
        }

        public static double Delta(double a, double b, double c)
        {
            return b * b - (4 * a * c);
        }

        public static double Roots(double a, double b, double c)
        {
            double x1, x2, del;

            del = Delta(a, b, c);
            if (del == 0)
            {
                return  -b / (2 * a);
            }
            else if (del < 0)
            {
                Console.WriteLine("No root");
            }
            else
            {
                x1 = -b - (Math.Sqrt(del)) / 2 * a;
                x2 = -b + (Math.Sqrt(del)) / 2 * a;
            }

            return 0;

        }



        static void Main(string[] args)
        {
            Console.WriteLine(Adding(2, 2));
            Console.ReadLine();
        }
    }
}
