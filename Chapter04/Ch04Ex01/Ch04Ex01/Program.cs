using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Ch04Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter an integer:");
            int myInt = ToInt32(ReadLine());
            bool isLessThan10 = myInt < 10;
            bool isBetween0And5 = (0 <= myInt) && (myInt <= 5);
            WriteLine($"Integer less than 10? {isLessThan10}");
            WriteLine($"Integer between 0 and 5? {isBetween0And5}");
            WriteLine($"Exactly one of the above is true? " +
                      $"{isLessThan10 ^ isBetween0And5}");
            ReadKey();
        }
    }
}
