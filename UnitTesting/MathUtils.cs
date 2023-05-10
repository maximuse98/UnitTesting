using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    public static class MathUtils
    {
        public static int Degree(int n, int degree)
        {
            if (degree < 0)
            {
                throw new ArgumentException("Less than 0 not supported", nameof(degree));
            }
            return degree == 0 ? 1 : n * Degree(n, degree - 1);
        }
    }
}
