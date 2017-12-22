using System;
using System.ComponentModel;
using System.Linq;

namespace Ch13CardLib
{
    [Serializable]
    public class Player : INotifyPropertyChanged
    {
        public int Index { get; set; }
        protected Cards Hand { get; set; }
        private string name;
        private PlayerState state;

        public event EventHandler<CardEventArgs> OnCardDiscarded;
        public event EventHandler<PlayerEventArgs> OnPlayerHasWon;

        public PlayerState State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        public virtual string PlayerName
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }

        public void AddCard(Card card)
        {
            Hand.Add(card);
            if (Hand.Count > 7)
                State = PlayerState.MustDiscard;
        }

        public void DrawCard(Deck deck)
        {
            AddCard(deck.Draw());
        }

        public void DiscardCard(Card card)
        {
            Hand.Remove(card);
            if (HasWon)
                OnPlayerHasWon?.Invoke(this, new PlayerEventArgs { Player = this, State = PlayerState.Winner });
            OnCardDiscarded?.Invoke(this, new CardEventArgs { Card = card });
        }

        public void DrawNewHand(Deck deck)
        {
            Hand = new Cards();
            for (int i = 0; i < 7; i++)
                Hand.Add(deck.Draw());
        }

        public bool HasWon => Hand.Count == 7 && Hand.Select(x => x.suit).Distinct().Count() == 1;

        public Cards GetCards() => Hand.Clone() as Cards;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
