using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex04
{
    public class SuperCow : Cow
    {
        public void Fly()
        {
            WriteLine($"{name} is flying!");
        }

        public override void MakeANoise()
        {
            WriteLine(
               $"{name} says 'here I come to save the day!'");
        }
    }
}
