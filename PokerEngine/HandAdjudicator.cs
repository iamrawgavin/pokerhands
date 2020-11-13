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
            var groupedHand = hand.GroupBy(c => c.Rank)
                      .Select(c => new { Rank = c.Key, Count = c.Count() })
                      .Where(c => c.Count > 1);

            var sortedHand = hand.OrderByDescending(c => c.Rank);
            int spread = sortedHand.First().Rank - sortedHand.Last().Rank;

            if (spread == 4 && groupedHand.Count() == 0) return sortedHand.First().Rank;
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

        public BestHand GetBestHand(List<Card> hand)
        {
            Rank rankOfWinner;
            if ((rankOfWinner = GetRankOfStraightFlush(hand)) != Rank.Null)
            {
                return new BestHand(HandType.StraightFlush, rankOfWinner);
            }
            else if ((rankOfWinner = GetRankOfFourOfAKind(hand)) != Rank.Null)
            {
                return new BestHand(HandType.FourOfAKind, rankOfWinner);
            }
            else if ((rankOfWinner = GetRankOfFullHouseHighCard(hand)) != Rank.Null)
            {
                return new BestHand(HandType.FullHouse, rankOfWinner);
            }
            else if ((rankOfWinner = GetRankOfFlush(hand)) != Rank.Null)
            {
                return new BestHand(HandType.Flush, rankOfWinner);
            }
            else if ((rankOfWinner = GetRankOfStraight(hand)) != Rank.Null)
            {
                return new BestHand(HandType.Straight, rankOfWinner);
            }
            else if ((rankOfWinner = GetRankOfThreeOfAKind(hand)) != Rank.Null)
            {
                return new BestHand(HandType.ThreeOfAKind, rankOfWinner);
            }
            else if ((rankOfWinner = GetHighRankOfTwoPair(hand)) != Rank.Null)
            {
                return new BestHand(HandType.TwoPair, rankOfWinner);
            }
            else if ((rankOfWinner = GetRankOfPair(hand)) != Rank.Null)
            {
                return new BestHand(HandType.Pair, rankOfWinner);
            }
            else
            {
                rankOfWinner = GetHighCardFromHand(hand);
                return new BestHand(HandType.HighCard, rankOfWinner);
            }
        }

        public int GetWinningHand(List<Card> hand1, List<Card> hand2)
        {
            BestHand bestHand1 = GetBestHand(hand1);
            BestHand bestHand2 = GetBestHand(hand2);

            if (bestHand1.Winner > bestHand2.Winner)
            {
                return 1;
            }
            else if (bestHand1.Winner < bestHand2.Winner)
            {
                return 2;
            }
            else
            {
                return 0; //push
            }
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
