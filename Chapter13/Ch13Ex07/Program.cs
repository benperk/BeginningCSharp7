using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch13Ex07
{
    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "his gaze against the sweeping bars has "
               + "grown so weary";
            List<string> words;
            words = WordProcessor.GetWords(sentence);
            WriteLine("Original sentence:");
            foreach (string word in words)
            {
                Write(word);
                Write(' ');
            }
            WriteLine('\n');
            words = WordProcessor.GetWords(
               sentence,
               reverseWords: true,
               capitalizeWords: true);
            WriteLine("Capitalized sentence with reversed words:");
            foreach (string word in words)
            {
                Write(word);
                Write(' ');
            }
            ReadKey();
        }
    }
}
