using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace WriteFile
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] byteData;
            char[] charData;

            try
            {
                FileStream aFile = new FileStream("Temp.txt", FileMode.Create);
                charData = "My pink half of the drainpipe.".ToCharArray();
                byteData = new byte[charData.Length];
                Encoder e = Encoding.UTF8.GetEncoder();
                e.GetBytes(charData, 0, charData.Length, byteData, 0, true);

                // Move file pointer to beginning of file.
                aFile.Seek(0, SeekOrigin.Begin);
                aFile.Write(byteData, 0, byteData.Length);
                ReadKey();
            }
            catch (IOException ex)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(ex.ToString());
                ReadKey();
                return;
            }
        }
    }
}