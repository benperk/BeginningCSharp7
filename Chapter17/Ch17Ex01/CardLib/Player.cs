using System;
using System.Collections.Generic;
using System.Web;

public class Player
{
    public string Name { get; private set; }
    public Cards PlayHand { get; private set; }
    private Player() { }
    public Player(string name) { Name = name; PlayHand = new Cards(); }
}
