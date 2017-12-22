using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace StreamWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileStream aFile = new FileStream("Log.txt", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);

                bool truth = true;
                // Write data to file.
                sw.WriteLine("Hello to you.");
                sw.WriteLine($"It is now {DateTime.Now.ToLongDateString()} and things are looking good.");
                sw.Write("More than that,");
                sw.Write($" it's {truth} that C# is fun.");
                sw.Close();
            }
            catch (IOException e)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(e.ToString());
                ReadLine();
                return;
            }
        }
    }
}