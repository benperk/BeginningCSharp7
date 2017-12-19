using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch11Ex04
{
    class Checker
    {
        public void Check(object param1)
        {
            if (param1 is ClassA)
                WriteLine("Variable can be converted to ClassA.");
            else
                WriteLine("Variable can't be converted to ClassA.");
            if (param1 is IMyInterface)
                WriteLine("Variable can be converted to IMyInterface.");
            else
                WriteLine("Variable can't be converted to IMyInterface.");
            if (param1 is MyStruct)
                WriteLine("Variable can be converted to MyStruct.");
            else
                WriteLine("Variable can't be converted to MyStruct.");
        }
    }
    interface IMyInterface { }
    class ClassA : IMyInterface { }
    class ClassB : IMyInterface { }
    class ClassC { }
    class ClassD : ClassA { }
    struct MyStruct : IMyInterface { }

    class Program
    {
        static void Main(string[] args)
        {
            Checker check = new Checker();
            ClassA try1 = new ClassA();
            ClassB try2 = new ClassB();
            ClassC try3 = new ClassC();
            ClassD try4 = new ClassD();
            MyStruct try5 = new MyStruct();
            object try6 = try5;
            WriteLine("Analyzing ClassA type variable:");
            check.Check(try1);
            WriteLine("\nAnalyzing ClassB type variable:");
            check.Check(try2);
            WriteLine("\nAnalyzing ClassC type variable:");
            check.Check(try3);
            WriteLine("\nAnalyzing ClassD type variable:");
            check.Check(try4);
            WriteLine("\nAnalyzing MyStruct type variable:");
            check.Check(try5);
            WriteLine("\nAnalyzing boxed MyStruct type variable:");
            check.Check(try6);
            ReadKey();
        }
    }

}
