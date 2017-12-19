using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace VarianceDemo
{
   public class Cow : Animal, IMethaneProducer<Cow>, IGrassMuncher<Cow>
   {
      public void Milk() => WriteLine($"{name} has been milked.");

      public Cow(string newName) : base(newName) {}
      
      public override void MakeANoise() => WriteLine($"{name} says 'moo!'");
   }
}
