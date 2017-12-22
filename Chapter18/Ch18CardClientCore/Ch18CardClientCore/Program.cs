using System;
using static System.Console;
using Ch18CardLibStandard;

namespace Ch18CardClientCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Player[] players = new Player[2];
            Write("Enter the name of player #1: ");
            players[0] = new Player(ReadLine());
            Write("Enter the name of player #2: ");
            players[1] = new Player(ReadLine());

            Game newGame = new Game();
            newGame.SetPlayers(players);
            newGame.DealHands();

            WriteLine("");
            WriteLine("*************************");
            WriteLine($"{players[0].Name} received this hand: ");
            WriteLine("*************************");
            foreach (var card in players[0].PlayHand)
            {
                WriteLine($"{card.rank} of {card.suit}s");
            }
            WriteLine("*************************");
            WriteLine("");
            WriteLine("*************************");
            WriteLine($"{players[1].Name} received this hand: ");
            WriteLine("*************************");
            foreach (var card in players[1].PlayHand)
            {
                WriteLine($"{card.rank} of {card.suit}s");
            }
            WriteLine("*************************");
            WriteLine("");
            WriteLine("Press enter to exit.");
            ReadLine();
        }
    }
}
