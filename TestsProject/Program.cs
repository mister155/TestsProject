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
        public static RootsResult Roots(double a, double b, double c)
        {
            if (a == 0)
            {
                throw new DivideByZeroException();
            }

            var result = new RootsResult();
            result.Delta = DeltaCompute.Delta(a, b, c);

             if (result.Delta < 0)
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
            Console.WriteLine(AddCompute.Adding(2, 2));
            Console.ReadLine();
        }
    }
}