using System;
using System.Linq;
using System.Collections.Generic;

namespace PokerEngine
{
    public class HandAdjudicator
    {
        public Rank GetHighCardFromHand(List<Card> hand)
        {
            return hand.OrderByDescending(c => c.Rank).First().Rank;
        }

        public Rank GetRankOfPair(List<Card> hand)
        {
            return FindMatches(hand, 2, 1);
        }

        public Rank GetHighRankOfTwoPair(List<Card> hand)
        {
            return FindMatches(hand, 2, 2);
        }

        public Rank GetRankOfThreeOfAKind(List<Card> hand)
        {
            return FindMatches(hand, 3, 1);
        }

        public Rank GetRankOfStraight(List<Card> hand)
        {
            var sortedHand = hand.OrderByDescending(c => c.Rank);
            int spread = sortedHand.First().Rank - sortedHand.Last().Rank;

            if (spread == 4) return sortedHand.First().Rank;
            else return Rank.Null;
        }

        public Rank GetRankOfFlush(List<Card> hand)
        {
            var groupedHand = hand.GroupBy(c => c.Suit)
                                  .Select(c => new { Suit = c.Key, Count = c.Count() })
                                  .Where(c => c.Count == 5);

            if (groupedHand.Count() == 1) return GetHighCardFromHand(hand);
            else return Rank.Null;
        }

        public Rank GetRankOfFullHouseHighCard(List<Card> hand)
        {
            Rank pairRank = FindMatches(hand, 2, 1);
            Rank threeOfAKindRank = FindMatches(hand, 3, 1);

            if (pairRank == Rank.Null || threeOfAKindRank == Rank.Null) return Rank.Null;
            else return threeOfAKindRank;
        }

        public Rank GetRankOfFourOfAKind(List<Card> hand)
        {
            return FindMatches(hand, 4, 1);
        }

        public Rank GetRankOfStraightFlush(List<Card> hand)
        {
            Rank straightRank = GetRankOfStraight(hand);
            if (straightRank == Rank.Null) return Rank.Null;

            Rank flushRank = GetRankOfFlush(hand);
            return flushRank; //it will be either the high card or null
        }

        private Rank FindMatches(List<Card> hand, int countToMatch, int setsOfMatches)
        {
            var matches = hand.GroupBy(c => c.Rank)
                .Select(c => new { Rank = c.Key, Count = c.Count() })
                .Where(c => c.Count == countToMatch)
                .OrderByDescending(c => c.Rank);

            if (matches.Count() == setsOfMatches) return matches.First().Rank;
            else return Rank.Null;
        }
    }
}
