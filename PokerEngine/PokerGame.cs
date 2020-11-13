using System;
using System.Collections.Generic;

namespace PokerEngine
{
    public class PokerGame
    {
        public List<Card> PlayerOneCards { get; set; }
        public List<Card> PlayerTwoCards { get; set; }

        public BestHand PlayerOneBestHand { get; set; }
        public BestHand PlayerTwoBestHand { get; set; }

        public string Winner { get; set; }

        public PokerGame()
        {
            PlayerOneCards = new List<Card>();
            PlayerTwoCards = new List<Card>();
        }
    }
}
