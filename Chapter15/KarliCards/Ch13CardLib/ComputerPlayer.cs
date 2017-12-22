using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ch13CardLib
{
    [Serializable]
    public class ComputerPlayer : Player
    {
        private Random random = new Random();
        public ComputerSkillLevel Skill { get; set; }
        public override string PlayerName => $"Computer {Index}";

        public void PerformDraw(Deck deck, Card availableCard)
        {
            if (Skill == ComputerSkillLevel.Dumb)
                DrawCard(deck);
            else
                DrawBestCard(deck, availableCard, (Skill == ComputerSkillLevel.Cheats));
        }

        public void PerformDiscard(Deck deck)
        {
            if (Skill == ComputerSkillLevel.Dumb)
                DiscardCard(Hand[random.Next(Hand.Count)]);
            else
                DiscardWorstCard();
        }

        private void DrawBestCard(Deck deck, Card availableCard, bool cheat = false)
        {
            var bestSuit = CalculateBestSuit();
            if (availableCard.suit == bestSuit)
                AddCard(availableCard);
            else if (cheat == false)
                DrawCard(deck);
            else
                AddCard(deck.SelectCardOfSpecificSuit(bestSuit));
        }

        private void DiscardWorstCard()
        {
            DiscardCard(Hand.First(x => x.suit == CalculateWorstSuit()));
        }

        private Suit CalculateBestSuit() => OrderSuitsInHand().Last();

        private Suit CalculateWorstSuit() => OrderSuitsInHand().First();

        private List<Suit> OrderSuitsInHand()
        {
            var cardSuits = new Dictionary<Suit, int>();
            foreach (var card in Hand)
            {
                if (!cardSuits.ContainsKey(card.suit))
                    cardSuits.Add(card.suit, 0);
                cardSuits[card.suit]++;
            }
            return cardSuits.OrderBy(x => x.Value).Select(y => y.Key).ToList();
        }
    }
}
