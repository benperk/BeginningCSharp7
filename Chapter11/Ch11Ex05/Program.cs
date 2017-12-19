using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch11Ex05
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(new Person("Rual", 30));
            list.Add(new Person("Donna", 25));
            list.Add(new Person("Mary", 27));
            list.Add(new Person("Ben", 44));
            WriteLine("Unsorted people:");
            for (int i = 0; i < list.Count; i++)
            {
                WriteLine($"{(list[i] as Person).Name } ({(list[i] as Person).Age })");
            }
            WriteLine();
            WriteLine(
               "People sorted with default comparer (by age):");
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                WriteLine($"{(list[i] as Person).Name } ({(list[i] as Person).Age })");
            }
            WriteLine();
            WriteLine(
               "People sorted with nondefault comparer (by name):");
            list.Sort(PersonComparerName.Default);
            for (int i = 0; i < list.Count; i++)
            {
                WriteLine($"{(list[i] as Person).Name } ({(list[i] as Person).Age })");
            }
            ReadKey();
        }
    }
}
