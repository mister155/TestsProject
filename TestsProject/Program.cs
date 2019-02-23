using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{


    class Program
    {
        private static double Adding(double a, double b)
        {
            return a + b;
        }

        private static double Delta(double a, double b, double c)
        {
            return b * b * (4 * a * c);
        }

        private static double Roots(double a, double b, double c)
        {
            double x1, x2, del;

            del = Delta(a, b, c);
            if (del == 0)
            {
                x1 = -b / (2 * a);
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
