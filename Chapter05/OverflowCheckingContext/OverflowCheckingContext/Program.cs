using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace OverflowCheckingContext
{
    class Program
    {
        static void Main(string[] args)
        {
            //double number = ToDouble("Number");

            byte destinationVar;
            short sourceVar = 281;
            destinationVar = checked((byte)sourceVar);
            //destinationVar = unchecked((byte)sourceVar);
            WriteLine($"sourceVar val: {sourceVar}");
            WriteLine($"destinationVar val: {destinationVar}");
            ReadLine();
        }
    }
}
