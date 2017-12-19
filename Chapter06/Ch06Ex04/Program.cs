using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch06Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"{args.Length} command line arguments were specified:");
            foreach (string arg in args)
                WriteLine(arg);
            ReadKey();
        }
    }
}
