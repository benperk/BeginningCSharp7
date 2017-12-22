using System;
using System.Collections.Generic;
using System.Web;

public class Card : ICloneable
{
    public readonly Rank rank;
    public readonly Suit suit;
    public readonly string imageLink;    
    public static bool isAceHigh = true;

    public Card() { }
    public Card(Suit newSuit, Rank newRank, string link) { suit = newSuit; rank = newRank; imageLink = link; }
    public object Clone() { return MemberwiseClone(); }
    
}
