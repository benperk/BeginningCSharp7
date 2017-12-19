using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ch12Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Vectors route = new Vectors();
            route.Add(new Vector(2.0, 90.0));
            route.Add(new Vector(1.0, 180.0));
            route.Add(new Vector(0.5, 45.0));
            route.Add(new Vector(2.5, 315.0));
            WriteLine(route.Sum());
            Comparison<Vector> sorter = new Comparison<Vector>(
               VectorDelegates.Compare);
            route.Sort(sorter);
            WriteLine(route.Sum());
            Predicate<Vector> searcher =
               new Predicate<Vector>(VectorDelegates.TopRightQuadrant);
            Vectors topRightQuadrantRoute = new Vectors(route.FindAll(searcher));
            WriteLine(topRightQuadrantRoute.Sum());
            ReadKey();            
        }
    }
}
