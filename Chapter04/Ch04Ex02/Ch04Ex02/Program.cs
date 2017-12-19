using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Ch04Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            string comparison;
            WriteLine("Enter a number:");
            double var1 = ToDouble(ReadLine());
            WriteLine("Enter another number:");
            double var2 = ToDouble(ReadLine());
            if (var1 < var2)
                comparison = "less than";
            else
            {
                if (var1 == var2)
                    comparison = "equal to";
                else
                    comparison = "greater than";
            }
            WriteLine($"The first number is {comparison} " +
                      $"the second number.");
            ReadKey();
        }
    }
}
