using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex08
{
    delegate int TwoIntegerOperationDelegate(int paramA, int paramB);
    class Program
    {
        static void PerformOperations(TwoIntegerOperationDelegate del)
        {
            for (int paramAVal = 1; paramAVal <= 5; paramAVal++)
            {
                for (int paramBVal = 1; paramBVal <= 5; paramBVal++)
                {
                    int delegateCallResult = del(paramAVal, paramBVal);
                    Write($"f({paramAVal}, " +
                          $"{paramBVal})={delegateCallResult}");
                    if (paramBVal != 5)
                    {
                        Write(", ");
                    }
                }
                WriteLine();
            }
        }
        static void Main(string[] args)
        {
            WriteLine("f(a, b) = a + b:");
            PerformOperations((paramA, paramB) => paramA + paramB);
            WriteLine();
            WriteLine("f(a, b) = a * b:");
            PerformOperations((paramA, paramB) => paramA * paramB);
            WriteLine();
            WriteLine("f(a, b) = (a - b) % b:");
            PerformOperations((paramA, paramB) => (paramA - paramB)
               % paramB);
            ReadKey();
        }
    }
}
