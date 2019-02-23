using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public static class DeltaCompute
    {
        public static double Delta(double a, double b, double c)
        {
            return b * b - (4d * a * c);
        }
    }
}