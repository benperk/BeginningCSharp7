using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            var animals = new[]
            {
                new { Name = "Benjamin", Age = 42, Weight = 185 },
                new { Name = "Benjamin", Age = 42, Weight = 185 },
                new { Name = "Andrea", Age = 46, Weight = 109 }
            };
            WriteLine(animals[0].ToString());
            WriteLine(animals[0].GetHashCode());
            WriteLine(animals[1].GetHashCode());
            WriteLine(animals[2].GetHashCode());
            WriteLine(animals[0].Equals(animals[1]));
            WriteLine(animals[0].Equals(animals[2]));
            WriteLine(animals[0] == animals[1]);
            WriteLine(animals[0] == animals[2]);
            ReadKey();
        }
    }
}
