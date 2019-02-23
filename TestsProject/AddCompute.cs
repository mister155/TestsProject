using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsProject
{
    public static class AddCompute
    {
        public static double? Adding(double? a, double? b)
        {
            if (a + b == Double.PositiveInfinity || a + b == Double.NegativeInfinity)
            {
                throw new ArgumentOutOfRangeException();
            }
            return a + b;
        }
    }
}