using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch05Ex06
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "This is a test.";
            char[] separator = { ' ' };
            string[] myWords;
            myWords = myString.Split(separator);
            foreach (string word in myWords)
            {
                WriteLine($"{word}");
            }
            ReadKey();
        }
    }
}
