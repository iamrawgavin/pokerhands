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

        public Rank GetRankOfStraight(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetRankOfFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetRankOfFullHouseHighCard(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetRankOfFourOfAKind(List<Card> hand)
        {
            throw new NotImplementedException();
        }

        public Rank GetRankOfStraightFlush(List<Card> hand)
        {
            throw new NotImplementedException();
        }
    }
}
