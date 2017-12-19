using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch12Ex02
{
   public class Cow : Animal
   {
      public void Milk() => WriteLine($"{name} has been milked.");

      public Cow(string newName) : base(newName) {}
   }
}
