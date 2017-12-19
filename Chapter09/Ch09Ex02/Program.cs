using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Ch09ClassLib;

namespace Ch09Ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            MyExternalClass myObj = new MyExternalClass();
            //MyInternalClass myObj = new MyInternalClass();
            WriteLine(myObj.ToString());
            ReadKey();
        }
    }
}