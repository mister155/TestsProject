using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            return b * b - (4d * a * c);
        }

        public static double Roots(double a, double b, double c)
        {
            double x1, x2, del;

            del = Delta(a, b, c);
            if (del == 0)
            {
                return  -b / (2d * a);
            }
            else if (del < 0)
            {
                Console.WriteLine("No root");
                return 0;
            }
            else
            {
                x1 = (-b - (Math.Sqrt(del))) / (2d * a);
                x2 = (-b + (Math.Sqrt(del))) / (2d * a);

                return x1;
            }
        }

        public static double RootsResult()
        {

        }



        static void Main(string[] args)
        {
            Console.WriteLine(Adding(2, 2));
            Console.ReadLine();
        }
    }
}
