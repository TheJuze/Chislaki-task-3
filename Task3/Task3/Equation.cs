using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Equation
    {
        public static double getFunctionValue(double x)
        {
            return Math.Log(x * x) + x * x*x;
        }
    }
}
