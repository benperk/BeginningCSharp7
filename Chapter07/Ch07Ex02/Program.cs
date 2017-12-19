using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch07Ex02
{
    class Program
    {
        static string[] eTypes = { "none", "simple", "index",
                                 "nested index", "filter" };

        static void Main(string[] args)
        {
            foreach (string eType in eTypes)
            {
                try
                {
                    WriteLine("Main() try block reached.");        // Line 21
                    WriteLine($"ThrowException(\"{eType}\") called.");
                    ThrowException(eType);
                    WriteLine("Main() try block continues.");      // Line 24
                }
                catch (System.IndexOutOfRangeException e) when (eType == "filter")
                {
                    BackgroundColor = ConsoleColor.Red;
                    WriteLine("Main() FILTERED System.IndexOutOfRangeException" +
                              $"catch block reached. Message:\n\"{e.Message}\"");
                    ResetColor();
                }
                catch (System.IndexOutOfRangeException e)                 // Line 33
                {
                    WriteLine("Main() System.IndexOutOfRangeException catch " +
                              $"block reached. Message:\n\"{e.Message}\"");                
                }
                catch                                                     // Line 38
                {
                    WriteLine("Main() general catch block reached.");
                }
                finally
                {
                    WriteLine("Main() finally block reached.");
                }
                WriteLine();
            }
            ReadKey();
        }
        static void ThrowException(string exceptionType)
        {
            WriteLine($"ThrowException(\"{exceptionType}\") reached.");
            switch (exceptionType)
            {
                case "none":
                    WriteLine("Not throwing an exception.");
                    break;                                               // Line 57
                case "simple":
                    WriteLine("Throwing System.Exception.");
                    throw new System.Exception();                      // Line 60
                case "index":
                    WriteLine("Throwing System.IndexOutOfRangeException.");
                    eTypes[5] = "error";                                 // Line 63
                    break;
                case "nested index":
                    try                                                  // Line 66
                    {
                        WriteLine("ThrowException(\"nested index\") " +
                                          "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 71
                    }
                    catch                                                // Line 73
                    {
                        WriteLine("ThrowException(\"nested index\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    finally
                    {
                        WriteLine("ThrowException(\"nested index\") finally"
                                          + " block reached.");
                    }
                    break;
                case "filter":
                    try                                                  // Line 86
                    {
                        WriteLine("ThrowException(\"filter\") " +
                                          "try block reached.");
                        WriteLine("ThrowException(\"index\") called.");
                        ThrowException("index");                          // Line 91
                    }
                    catch                                                // Line 93
                    {
                        WriteLine("ThrowException(\"filter\") general"
                                          + " catch block reached.");
                        throw;
                    }
                    break;
            }
        }
    }

}
