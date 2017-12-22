using System;
using System.Collections.Generic;
using System.Web;

public class Game
{
    private int currentCard;
    private Deck playDeck;
    private Player[] players;
    private Cards discardedCards;

    public Game()
    {
       currentCard = 0;
       playDeck = new Deck(true);
       playDeck.LastCardDrawn += Reshuffle;
       playDeck.Shuffle();
       discardedCards = new Cards();
    }

    private void Reshuffle(object source, EventArgs args)
    {
       Console.WriteLine("Discarded cards reshuffled into deck.");
       ((Deck)source).Shuffle();
       discardedCards.Clear();
       currentCard = 0;
    }

    public void SetPlayers(Player[] newPlayers)
    {
       players = newPlayers;
    }

    public void DealHands()
    {
       for (int p = 0; p < players.Length; p++)
       {
          for (int c = 0; c < 7; c++)
          {
             players[p].PlayHand.Add(playDeck.GetCard(currentCard++));
          }
       }
    }
}
