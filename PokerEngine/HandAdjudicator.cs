using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerEngine
{
    public class HandAdjudicator
    {
        public Card GetHighCardFromHand(List<Card> hand)
        {
            return hand.OrderByDescending(c => c.Rank).First();
        }

        public Rank GetRankOfPair(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetHighRankOfTwoPair(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetRankOfThreeOfAKind(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool HandHasStraight(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool HandHasFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool HandHasFullHouse(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetRankOfFourOfAKind(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public bool HandHasStraightFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }
    }
}
