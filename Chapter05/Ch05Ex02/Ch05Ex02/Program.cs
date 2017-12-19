using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Convert;

namespace Ch05Ex02
{
    enum orientation : byte
    {
        north = 1,
        south = 2,
        east = 3,
        west = 4
    }
    class Program
    {
        static void Main(string[] args)
        {
            //orientation myDirection = orientation.north;
            //WriteLine($"myDirection = {myDirection}");
            //ReadKey();

            byte directionByte;
            string directionString;
            orientation myDirection = orientation.north;
            WriteLine($"myDirection = {myDirection}");
            directionByte = (byte)myDirection;
            directionString = Convert.ToString(myDirection);
            WriteLine($"byte equivalent = {directionByte}");
            WriteLine($"string equivalent = {directionString}");
            ReadKey();
        }
    }
}
