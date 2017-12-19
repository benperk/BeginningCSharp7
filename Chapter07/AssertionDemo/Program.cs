using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace AssertionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int myVar = 15;
            Trace.Assert(myVar < 10, "Variable out of bounds.",
                "Please contact vendor with the error code KCW001.");
        }
    }
}
