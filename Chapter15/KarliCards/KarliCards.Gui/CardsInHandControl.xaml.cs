using Ch13CardLib;
using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;


namespace KarliCards.Gui
{
    /// <summary>
    /// Interaction logic for CardsInHandControl.xaml
    /// </summary>
    public partial class CardsInHandControl : UserControl
    {
        public CardsInHandControl()
        {
            InitializeComponent();
        }



        public Player Owner
        {
            get { return (Player)GetValue(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Owner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(Player), typeof(CardsInHandControl), new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));



        public GameViewModel Game
        {
            get { return (GameViewModel)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Game.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameProperty =
            DependencyProperty.Register("Game", typeof(GameViewModel), typeof(CardsInHandControl), new PropertyMetadata(null, new PropertyChangedCallback(OnOwnerChanged)));



        public PlayerState PlayerState
        {
            get { return (PlayerState)GetValue(PlayerStateProperty); }
            set { SetValue(PlayerStateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerState.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerStateProperty =
            DependencyProperty.Register("PlayerState", typeof(PlayerState), typeof(CardsInHandControl), new PropertyMetadata(PlayerState.Inactive, new PropertyChangedCallback(OnPlayerStateChanged)));



        public Orientation PlayerOrientation
        {
            get { return (Orientation)GetValue(PlayerOrientationProperty); }
            set { SetValue(PlayerOrientationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerOrientation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerOrientationProperty =
            DependencyProperty.Register("PlayerOrientation", typeof(Orientation), typeof(CardsInHandControl), new PropertyMetadata(Orientation.Horizontal, new PropertyChangedCallback(OnPlayerOrientationChanged)));

        private static void OnOwnerChanged(DependencyObject source,
DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardsInHandControl;
            control.RedrawCards();
        }
        private static void OnPlayerStateChanged(DependencyObject source,
    DependencyPropertyChangedEventArgs e)
        {
            var control = source as CardsInHandControl;
            var computerPlayer = control.Owner as ComputerPlayer;
            if (computerPlayer != null)
            {
                if (computerPlayer.State == PlayerState.MustDiscard)
                {
                    Thread delayedWorker = new Thread(control.DelayDiscard);
                    delayedWorker.Start(new Payload
                    {
                        Deck = control.Game.GameDeck,
                        AvailableCard = control.Game.CurrentAvailableCard,
                        Player = computerPlayer
                    });
                }
                else if (computerPlayer.State == PlayerState.Active)
                {
                    Thread delayedWorker = new Thread(control.DelayDraw);
                    delayedWorker.Start(new Payload
                    {
                        Deck = control.Game.GameDeck,
                        AvailableCard = control.Game.CurrentAvailableCard,
                        Player = computerPlayer
                    });
                }
            }
            control.RedrawCards();
        }
        private static void OnPlayerOrientationChanged(DependencyObject source,
    DependencyPropertyChangedEventArgs args)
        {
            var control = source as CardsInHandControl;
            control.RedrawCards();
        }

        private class Payload
        {
            public Deck Deck { get; set; }
            public Card AvailableCard { get; set; }
            public ComputerPlayer Player { get; set; }
        }
        private void DelayDraw(object payload)
        {
            Thread.Sleep(1250);
            var data = payload as Payload;
            Dispatcher.Invoke(DispatcherPriority.Normal,
      new Action<Deck, Card>(data.Player.PerformDraw), data.Deck, data.AvailableCard);
        }
        private void DelayDiscard(object payload)
        {
            Thread.Sleep(1250);
            var data = payload as Payload;
            Dispatcher.Invoke(DispatcherPriority.Normal,
      new Action<Deck>(data.Player.PerformDiscard), data.Deck);
        }
        private void RedrawCards()
        {
            CardSurface.Children.Clear();
            if (Owner == null)
            {
                PlayerNameLabel.Content = string.Empty;
                return;
            }
            DrawPlayerName();
            DrawCards();
        }

        private void DrawCards()
        {
            bool isFaceup = (Owner.State != PlayerState.Inactive);
            if (Owner is ComputerPlayer)
                isFaceup = (Owner.State == PlayerState.Loser ||
        Owner.State == PlayerState.Winner);
            var cards = Owner.GetCards();
            if (cards == null || cards.Count == 0)
                return;
            for (var i = 0; i < cards.Count; i++)
            {
                var cardControl = new CardControl(cards[i]);
                if (PlayerOrientation == Orientation.Horizontal)
                    cardControl.Margin = new Thickness(i * 35, 35, 0, 0);
                else
                    cardControl.Margin = new Thickness(5, 35 + i * 30, 0, 0);
                cardControl.MouseDoubleClick += cardControl_MouseDoubleClick;
                cardControl.IsFaceUp = isFaceup;
                CardSurface.Children.Add(cardControl);
            }
        }
        private void DrawPlayerName()
        {
            if (Owner.State == PlayerState.Winner || Owner.State == PlayerState.Loser)
                PlayerNameLabel.Content = Owner.PlayerName +
        (Owner.State == PlayerState.Winner ?
        " is the WINNER" : " has LOST");
            else
                PlayerNameLabel.Content = Owner.PlayerName;
            var isActivePlayer = (Owner.State == PlayerState.Active ||
      Owner.State == PlayerState.MustDiscard);
            PlayerNameLabel.FontSize = isActivePlayer ? 18 : 14;
            PlayerNameLabel.Foreground = isActivePlayer ?
      new SolidColorBrush(Colors.Gold) :
      new SolidColorBrush(Colors.White);
        }

        private void cardControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedCard = sender as CardControl;
            if (Owner == null)
                return;
            if (Owner.State == PlayerState.MustDiscard)
                Owner.DiscardCard(selectedCard.Card);
            RedrawCards();
        }

    }
}
