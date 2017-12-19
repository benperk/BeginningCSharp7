using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex04
{
    class Program
    {
        static void Main(string[] args)
        {
            Farm<Animal> farm = new Farm<Animal>
            {
                new Cow { Name="Lea" },
                new Chicken { Name="Noa" },
                new Chicken(),
                new SuperCow { Name="Andrea" }
            };
            farm.MakeNoises();
            ReadKey();
        }
    }
}
