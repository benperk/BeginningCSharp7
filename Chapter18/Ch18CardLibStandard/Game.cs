using System;

namespace Ch18CardLibStandard
{
    /// <summary>
    /// Class for playing the Card Game
    /// </summary>
    public class Game
    {
        private int currentCard;
        private Deck playDeck;
        private Player[] players;
        private Cards discardedCards;
        /// <summary>
        /// Class constructor for initializing and beginning a Card Game
        /// </summary>
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
            ((Deck)source).Shuffle();
            discardedCards.Clear();
            currentCard = 0;
        }
        /// <summary>
        /// A method for setting the players of the card game, minimum of 2 maximum of 7
        /// </summary>
        /// <param name="newPlayers"></param>
        public void SetPlayers(Player[] newPlayers)
        {
            if (newPlayers.Length > 7)
                throw new ArgumentException(
                   "A maximum of 7 players may play this game.");
            if (newPlayers.Length < 2)
                throw new ArgumentException(
                   "A minimum of 2 players may play this game.");
            players = newPlayers;
        }
        /// <summary>
        /// Deals a hand of cards to each of the players
        /// </summary>
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
}
