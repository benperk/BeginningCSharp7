using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ch17Ex01.Controllers
{
    public class HandOfCardsController : ApiController
    {
        [Route("api/HandOfCards/{playerName}")]
        public IEnumerable<Card> GetHandOfCards(string playerName)
        {
            Player[] players = new Player[1];
            players[0] = new Player(playerName);
            Game newGame = new Game();
            newGame.SetPlayers(players);
            newGame.DealHands();
            var handOfCards = players[0].PlayHand;
            return handOfCards;
        }
    }
}
