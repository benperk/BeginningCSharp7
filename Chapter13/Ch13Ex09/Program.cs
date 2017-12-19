using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex09
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Donna", "Mary", "Andrea" };
            WriteLine(people.Aggregate(
               (a, b) => a + " " + b));
            WriteLine(people.Aggregate<string, int>(
               0,
               (a, b) => a + b.Length));
            WriteLine(people.Aggregate<string, string, string>(
               "Some people:",
               (a, b) => a + " " + b,
               a => a));
            WriteLine(people.Aggregate<string, string, int>(
               "Some people:",
               (a, b) => a + " " + b,
               a => a.Length));
            ReadKey();
        }
    }
}
