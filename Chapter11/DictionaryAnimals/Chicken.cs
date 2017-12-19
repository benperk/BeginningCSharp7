using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DictionaryAnimals
{
   public class Chicken : Animal
   {
      public void LayEgg() => WriteLine($"{name} has laid an egg.");

      public Chicken(string newName) : base(newName) {}
   }
}
