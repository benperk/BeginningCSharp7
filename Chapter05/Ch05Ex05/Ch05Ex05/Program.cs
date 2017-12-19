using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch05Ex05
{
    class Program
    {
        static void Main(string[] args)
        {            
            string[] friendNames = { "Todd Anthony", "Kevin Holton",
                                     "Shane Laigle", null, "" };
            foreach (var friendName in friendNames)
            {
                switch (friendName)
                {
                    case string t when t.StartsWith("T"):
                        WriteLine("This friends name starts with a 'T': " +
                            $"{friendName} and is {t.Length - 1} letters long ");
                        break;
                    case string e when e.Length == 0:
                        WriteLine("There is a string in the array with no value");
                        break;
                    case null:
                        WriteLine("There was a 'null' value in the array");
                        break;
                    case var x:
                        WriteLine("This is the var pattern of type: " +
                            $"{x.GetType().Name}");
                        break;
                    default:
                        break;
                }
            }

            WriteLine();
            WriteLine("=================================================");
            WriteLine();

            int sum = 0, total = 0, counter = 0, intValue = 0;
            int?[] myIntArray = new int?[7] { 5, intValue, 9, 10, null, 2, 99 };
            foreach (var integer in myIntArray)
            {
                switch (integer)
                {
                    case 0:
                        WriteLine($"Integer number '{total}' has a default value of 0");
                        total++;
                        break;
                    case int value:
                        sum += value;
                        WriteLine($"Integer number '{total}' has a value of {value}");
                        total++;
                        counter++;
                        break;
                    case null:
                        WriteLine($"Integer number '{total}' is null");
                        total++;
                        break;
                    default:
                        break;
                }
            }
            WriteLine($"{total} total integers, {counter} integers with a " +
                      $"value other than 0 or null have a sum value of {sum}");
            ReadLine();
        }
    }
}
