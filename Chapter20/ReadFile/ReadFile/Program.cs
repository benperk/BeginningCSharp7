using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace ReadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] byteData = new byte[200];
            char[] charData = new char[200];

            try
            {
                FileStream aFile = new FileStream("../../Program.cs", FileMode.Open);
                aFile.Seek(174, SeekOrigin.Begin);
                aFile.Read(byteData, 0, 200);
            }
            catch (IOException e)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(e.ToString());
                ReadKey();
                return;
            }

            Decoder d = Encoding.UTF8.GetDecoder();
            d.GetChars(byteData, 0, byteData.Length, charData, 0);

            WriteLine(charData);
            ReadKey();
        }
    }
}
