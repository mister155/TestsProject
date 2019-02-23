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

        public static RootsResult Roots(double a, double b, double c)
        {
            var result = new RootsResult();

            result.Delta = Delta(a, b, c);
            if (result.Delta == 0)
            {
                result.X1 = -b / (2d * a);
            }
            else if (result.Delta < 0)
            {
                result.X1 = null;
                result.X2 = null;
            }
            else
            {
                result.X1 = (-b - (Math.Sqrt(result.Delta))) / (2d * a);
                result.X2 = (-b + (Math.Sqrt(result.Delta))) / (2d * a);

            }

            return result;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(Adding(2, 2));
            Console.ReadLine();
        }
    }
}
