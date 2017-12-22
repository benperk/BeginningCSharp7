namespace Ch18CardLibStandard
{
    /// <summary>
    /// Create a player for the Card Game
    /// </summary>
    public class Player
    {
        public string Name { get; private set; }
        public Cards PlayHand { get; private set; }
        private Player() { }
        public Player(string name)
        {
            Name = name;
            PlayHand = new Cards();
        }
        public bool HasWon()
        {
            bool won = true;
            Suit match = PlayHand[0].suit;
            for (int i = 1; i < PlayHand.Count; i++)
            {
                won &= PlayHand[i].suit == match;
            }
            return won;
        }
    }
}