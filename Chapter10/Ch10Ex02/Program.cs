using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch10Ex02
{
    public class ClassA
    {
        private int state = -1;
        public int State => state;
        public class ClassB
        {
            public void SetPrivateState(ClassA target, int newState)
            {
                target.state = newState;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ClassA myObject = new ClassA();
            WriteLine($"myObject.State = {myObject.State}");
            ClassA.ClassB myOtherObject = new ClassA.ClassB();
            myOtherObject.SetPrivateState(myObject, 999);
            WriteLine($"myObject.State = {myObject.State}");
            ReadKey();
        }
    }
}
