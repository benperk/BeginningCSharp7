using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch12CardLib;
using static System.Console;

namespace Ch12CardClient
{
   class Program
   {
      static void Main(string[] args)
      {
         Deck myDeck = new Deck();
         myDeck.Shuffle();
         for (int i = 0; i < 52; i++)
         {
            Card tempCard = myDeck.GetCard(i);
            Write(tempCard.ToString());
            if (i != 51)
               Write(", ");
            else
               WriteLine();
         }
         ReadKey();
      }
   }
}
