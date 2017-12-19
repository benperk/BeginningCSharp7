using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace VarianceDemo
{
   class Program
   {
      static void Main(string[] args)
      {
         Cow myCow = new Cow("Ben");

         IMethaneProducer<Cow> cowMethaneProducer = myCow;
         IMethaneProducer<Animal> animalMethaneProducer = cowMethaneProducer;

         IGrassMuncher<Cow> cowGrassMuncher = myCow;
         IGrassMuncher<SuperCow> superCowGrassMuncher = cowGrassMuncher;

         List<Cow> cows = new List<Cow>();
         cows.Add(myCow);
         cows.Add(new SuperCow("Rual"));
         cows.Add(new Cow("Donna"));
         cows.Add(new Cow("Mary"));

         cows.Sort(new AnimalNameLengthComparer());

         ListAnimals(cows);

         ReadKey();
      }

      static void ListAnimals(IEnumerable<Animal> animals)
      {
         foreach (Animal animal in animals)
         {
            WriteLine(animal.Name);
         }
      }
   }
}
