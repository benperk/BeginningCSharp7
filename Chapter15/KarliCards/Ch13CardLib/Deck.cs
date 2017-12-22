using System;
using System.Collections.Generic;
using System.Linq;
namespace Ch13CardLib
{
    public delegate void LastCardDrawnHandler(Deck currentDeck);
    public class Deck : ICloneable
    {
        public event LastCardDrawnHandler LastCardDrawn;
        private Cards cards = new Cards();
        public Deck()
        {
            InsertAllCards();
        }
        protected Deck(Cards newCards)
        {
            cards = newCards;
        }
        public int CardsInDeck
        {
            get { return cards.Count; }
        }
        public Card GetCard(int cardNum)
        {
            if (cardNum >= 0 && cardNum <= 51)
            {
                if ((cardNum == 51) && (LastCardDrawn != null)) LastCardDrawn(this);
                return cards[cardNum];
            }
            else
                throw new CardOutOfRangeException(cards.Clone() as Cards);
        }
        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[cards.Count];
            Random sourceGen = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(cards.Count);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }
        public void ReshuffleDiscarded(List<Card> cardsInPlay)
        {
            InsertAllCards(cardsInPlay);
            Shuffle();
        }
        public Card Draw()
        {
            if (cards.Count == 0) return null;
            var card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
        public Card SelectCardOfSpecificSuit(Suit suit)
        {
            Card selectedCard = cards.FirstOrDefault(card => card?.suit == suit);
            if (selectedCard == null) return Draw();
            cards.Remove(selectedCard);
            return selectedCard;
        }
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
        private void InsertAllCards()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit)suitVal, (Rank)rankVal));
                }
            }
        }
        private void InsertAllCards(List<Card> except)
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    var card = new Card((Suit)suitVal, (Rank)rankVal);
                    if (except?.Contains(card) ?? false) continue;
                    cards.Add(card);
                }
            }
        }
    }
}
