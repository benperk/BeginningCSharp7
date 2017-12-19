using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace SimpleIterators
{
   class Program
   {
      public static IEnumerable SimpleList()
      {
         yield return "string 1";
         yield return "string 2";
         yield return "string 3";
      }

      static void Main(string[] args)
      {
         foreach (string item in SimpleList())
            WriteLine(item);

         ReadKey();
      }
   }
}
