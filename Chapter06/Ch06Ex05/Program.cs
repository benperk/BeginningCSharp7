using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Ch06Ex05
{
    class Program
    {
        delegate double ProcessDelegate(double param1, double param2);
        static double Multiply(double param1, double param2) => param1 * param2;
        static double Divide(double param1, double param2) => param1 / param2;

        static void Main(string[] args)
        {
            ProcessDelegate process;
            WriteLine("Enter 2 numbers separated with a comma:");
            string input = ReadLine();
            int commaPos = input.IndexOf(',');
            double param1 = ToDouble(input.Substring(0, commaPos));
            double param2 = ToDouble(input.Substring(commaPos + 1,
                                             input.Length - commaPos - 1));
            WriteLine("Enter M to multiply or D to divide:");
            input = ReadLine();
            if (input == "M")
                process = new ProcessDelegate(Multiply);
            else
                process = new ProcessDelegate(Divide);
            WriteLine($"Result: {process(param1, param2)}");
            ReadKey();
        }

    }
}
