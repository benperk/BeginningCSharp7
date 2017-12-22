using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using static System.Console;

namespace Compressor
{
    class Program
    {
        static void SaveCompressedFile(string filename, string data)
        {
            FileStream fileStream =
               new FileStream(filename, FileMode.Create, FileAccess.Write);
            GZipStream compressionStream =
               new GZipStream(fileStream, CompressionMode.Compress);
            StreamWriter writer = new StreamWriter(compressionStream);
            writer.Write(data);
            writer.Close();
        }

        static string LoadCompressedFile(string filename)
        {
            FileStream fileStream =
               new FileStream(filename, FileMode.Open, FileAccess.Read);
            GZipStream compressionStream =
               new GZipStream(fileStream, CompressionMode.Decompress);
            StreamReader reader = new StreamReader(compressionStream);
            string data = reader.ReadToEnd();
            reader.Close();
            return data;
        }

        static void Main(string[] args)
        {
            try
            {
                string filename = "compressedFile.txt";

                WriteLine(
                   "Enter a string to compress (will be repeated 100 times):");
                string sourceString = ReadLine();
                StringBuilder sourceStringMultiplier =
                   new StringBuilder(sourceString.Length * 100);
                for (int i = 0; i < 100; i++)
                {
                    sourceStringMultiplier.Append(sourceString);
                }
                sourceString = sourceStringMultiplier.ToString();
                WriteLine($"Source data is {sourceString.Length} bytes long.");

                SaveCompressedFile(filename, sourceString);
                WriteLine($"\nData saved to {filename}.");

                FileInfo compressedFileData = new FileInfo(filename);
                WriteLine($"Compressed file is {compressedFileData.Length} bytes long.");

                string recoveredString = LoadCompressedFile(filename);
                recoveredString = recoveredString.Substring(
                   0, recoveredString.Length / 100);
                WriteLine($"\nRecovered data: {recoveredString}");

                ReadKey();
            }
            catch (IOException ex)
            {
                WriteLine("An IO exception has been thrown!");
                WriteLine(ex.ToString());
                ReadKey();
            }
        }
    }
}
