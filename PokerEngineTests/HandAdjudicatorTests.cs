using System;
using Xunit;
using System.Collections.Generic;
using PokerEngine;

namespace PokerEngineTests
{
    public class HandAdjudicatorTests
    {
        private HandAdjudicator HA;
        private List<Card> FlopHand;

        public HandAdjudicatorTests()
        {
            HA = new HandAdjudicator();
            FlopHand = new List<Card>();
            FlopHand.Add(new Card(Rank.Eight, Suit.Club));
            FlopHand.Add(new Card(Rank.Six, Suit.Diamond));
            FlopHand.Add(new Card(Rank.Four, Suit.Heart));
            FlopHand.Add(new Card(Rank.Ten, Suit.Club));
            FlopHand.Add(new Card(Rank.Two, Suit.Spade));
        }

        [Fact]
        public void TenIsHighCardInFlopHand()
        {
            Rank highCard = HA.GetHighCardFromHand(FlopHand);

            Assert.Equal(Rank.Ten, highCard);
        }

        [Fact]
        public void HandHasPairOfTens()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.King, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Diamond));
            goodHand.Add(new Card(Rank.Ace, Suit.Spade));
            goodHand.Add(new Card(Rank.Eight, Suit.Heart));

            Assert.Equal(Rank.Ten, HA.GetRankOfPair(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHavePair()
        {
            Rank RankOfPair = HA.GetRankOfPair(FlopHand);

            Assert.Equal(Rank.Null, RankOfPair);
        }

        [Fact]
        public void HandHasTwoPairAceHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.King, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Diamond));
            goodHand.Add(new Card(Rank.Ace, Suit.Spade));
            goodHand.Add(new Card(Rank.Ace, Suit.Heart));

            Assert.Equal(Rank.Ace, HA.GetHighRankOfTwoPair(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveTwoPair()
        {
            Rank RankOfHighPair = HA.GetHighRankOfTwoPair(FlopHand);

            Assert.Equal(Rank.Null, RankOfHighPair);
        }

        [Fact]
        public void HandHasThreeTens()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.King, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Diamond));
            goodHand.Add(new Card(Rank.Ten, Suit.Spade));
            goodHand.Add(new Card(Rank.Ace, Suit.Heart));

            Assert.Equal(Rank.Ten, HA.GetRankOfThreeOfAKind(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveThreeOfAKind()
        {
            Rank RankOfThreeOfAKind = HA.GetRankOfThreeOfAKind(FlopHand);

            Assert.Equal(Rank.Null, RankOfThreeOfAKind);
        }

        [Fact]
        public void HandHasStraightSixHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Three, Suit.Club));
            goodHand.Add(new Card(Rank.Four, Suit.Diamond));
            goodHand.Add(new Card(Rank.Five, Suit.Spade));
            goodHand.Add(new Card(Rank.Six, Suit.Heart));

            Assert.Equal(Rank.Six, HA.GetRankOfStraight(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveStraight()
        {
            Assert.Equal(Rank.Null, HA.GetRankOfStraight(FlopHand));
        }

        [Fact]
        public void HandHasFlushQueenHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Eight, Suit.Club));
            goodHand.Add(new Card(Rank.Four, Suit.Club));
            goodHand.Add(new Card(Rank.Five, Suit.Club));
            goodHand.Add(new Card(Rank.Queen, Suit.Club));

            Assert.Equal(Rank.Queen, HA.GetRankOfFlush(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveFlush()
        {
            Assert.Equal(Rank.Null, HA.GetRankOfFlush(FlopHand));
        }

        [Fact]
        public void HandHasFullHouseThreeHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Three, Suit.Club));
            goodHand.Add(new Card(Rank.Two, Suit.Diamond));
            goodHand.Add(new Card(Rank.Three, Suit.Spade));
            goodHand.Add(new Card(Rank.Three, Suit.Heart));

            Assert.Equal(Rank.Three, HA.GetRankOfFullHouseHighCard(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveFullHouse()
        {
            Assert.Equal(Rank.Null, HA.GetRankOfFullHouseHighCard(FlopHand));
        }

        [Fact]
        public void HandHasFourTens()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.King, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Diamond));
            goodHand.Add(new Card(Rank.Ten, Suit.Spade));
            goodHand.Add(new Card(Rank.Ten, Suit.Heart));

            Assert.Equal(Rank.Ten, HA.GetRankOfFourOfAKind(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveFourOfAKind()
        {
            Rank RankOfThreeOfAKind = HA.GetRankOfFourOfAKind(FlopHand);

            Assert.Equal(Rank.Null, RankOfThreeOfAKind);
        }

        [Fact]
        public void HandHasStraightFlushSixHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Three, Suit.Club));
            goodHand.Add(new Card(Rank.Four, Suit.Club));
            goodHand.Add(new Card(Rank.Five, Suit.Club));
            goodHand.Add(new Card(Rank.Six, Suit.Club));

            Assert.Equal(Rank.Six, HA.GetRankOfStraightFlush(goodHand));
        }

        [Fact]
        public void FlopHandDoesNotHaveStraightFlush()
        {
            Assert.Equal(Rank.Null, HA.GetRankOfStraightFlush(FlopHand));
        }

        [Fact]
        public void BestHandIsStraightFlushSixHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Three, Suit.Club));
            goodHand.Add(new Card(Rank.Four, Suit.Club));
            goodHand.Add(new Card(Rank.Five, Suit.Club));
            goodHand.Add(new Card(Rank.Six, Suit.Club));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.StraightFlush, bestHand.Winner);
            Assert.Equal(Rank.Six, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsFourAces()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Ace, Suit.Club));
            goodHand.Add(new Card(Rank.Ace, Suit.Diamond));
            goodHand.Add(new Card(Rank.Ace, Suit.Spade));
            goodHand.Add(new Card(Rank.Ace, Suit.Heart));
            goodHand.Add(new Card(Rank.Six, Suit.Club));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.FourOfAKind, bestHand.Winner);
            Assert.Equal(Rank.Ace, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsFullHouseSixHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Two, Suit.Diamond));
            goodHand.Add(new Card(Rank.Six, Suit.Spade));
            goodHand.Add(new Card(Rank.Six, Suit.Club));
            goodHand.Add(new Card(Rank.Six, Suit.Heart));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.FullHouse, bestHand.Winner);
            Assert.Equal(Rank.Six, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsFlushSevenHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Three, Suit.Club));
            goodHand.Add(new Card(Rank.Four, Suit.Club));
            goodHand.Add(new Card(Rank.Five, Suit.Club));
            goodHand.Add(new Card(Rank.Seven, Suit.Club));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.Flush, bestHand.Winner);
            Assert.Equal(Rank.Seven, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsStraightQueenHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Jack, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Heart));
            goodHand.Add(new Card(Rank.Eight, Suit.Club));
            goodHand.Add(new Card(Rank.Nine, Suit.Diamond));
            goodHand.Add(new Card(Rank.Queen, Suit.Club));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.Straight, bestHand.Winner);
            Assert.Equal(Rank.Queen, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsThreeSixes()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Diamond));
            goodHand.Add(new Card(Rank.Three, Suit.Club));
            goodHand.Add(new Card(Rank.Six, Suit.Heart));
            goodHand.Add(new Card(Rank.Six, Suit.Spade));
            goodHand.Add(new Card(Rank.Six, Suit.Club));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.ThreeOfAKind, bestHand.Winner);
            Assert.Equal(Rank.Six, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsTwoPairKingHigh()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Diamond));
            goodHand.Add(new Card(Rank.King, Suit.Club));
            goodHand.Add(new Card(Rank.King, Suit.Spade));
            goodHand.Add(new Card(Rank.Six, Suit.Club));
            goodHand.Add(new Card(Rank.Six, Suit.Heart));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.TwoPair, bestHand.Winner);
            Assert.Equal(Rank.King, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsPairOfTens()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Ten, Suit.Diamond));
            goodHand.Add(new Card(Rank.Ten, Suit.Spade));
            goodHand.Add(new Card(Rank.Five, Suit.Heart));
            goodHand.Add(new Card(Rank.Six, Suit.Club));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.Pair, bestHand.Winner);
            Assert.Equal(Rank.Ten, bestHand.Rank);
        }

        [Fact]
        public void BestHandIsHighCardSeven()
        {
            List<Card> goodHand = new List<Card>();
            goodHand.Add(new Card(Rank.Two, Suit.Club));
            goodHand.Add(new Card(Rank.Three, Suit.Diamond));
            goodHand.Add(new Card(Rank.Four, Suit.Club));
            goodHand.Add(new Card(Rank.Five, Suit.Spade));
            goodHand.Add(new Card(Rank.Seven, Suit.Heart));

            BestHand bestHand = HA.GetBestHand(goodHand);

            Assert.Equal(HandType.HighCard, bestHand.Winner);
            Assert.Equal(Rank.Seven, bestHand.Rank);
        }

        [Fact]
        public void FlopHandBestHandIsHighCardTen()
        {
            BestHand bestHand = HA.GetBestHand(FlopHand);

            Assert.Equal(HandType.HighCard, bestHand.Winner);
            Assert.Equal(Rank.Ten, bestHand.Rank);
        }

        [Fact]
        public void PairBeatsTenHigh()
        {
            List<Card> hand = new List<Card>();
            hand.Add(new Card(Rank.Two, Suit.Club));
            hand.Add(new Card(Rank.Ten, Suit.Diamond));
            hand.Add(new Card(Rank.Ten, Suit.Spade));
            hand.Add(new Card(Rank.Five, Suit.Heart));
            hand.Add(new Card(Rank.Six, Suit.Club));

            int indexOfWinningHand = HA.GetWinningHand(hand, FlopHand);

            Assert.Equal(1, indexOfWinningHand);
        }

        [Fact]
        public void StraightBeatsPair()
        {
            List<Card> straightHand = new List<Card>();
            straightHand.Add(new Card(Rank.Two, Suit.Club));
            straightHand.Add(new Card(Rank.Three, Suit.Diamond));
            straightHand.Add(new Card(Rank.Four, Suit.Spade));
            straightHand.Add(new Card(Rank.Five, Suit.Heart));
            straightHand.Add(new Card(Rank.Six, Suit.Club));

            List<Card> pairHand = new List<Card>();
            pairHand.Add(new Card(Rank.Two, Suit.Club));
            pairHand.Add(new Card(Rank.Three, Suit.Diamond));
            pairHand.Add(new Card(Rank.Four, Suit.Spade));
            pairHand.Add(new Card(Rank.Two, Suit.Heart));
            pairHand.Add(new Card(Rank.Six, Suit.Club));

            int indexOfWinningHand = HA.GetWinningHand(pairHand, straightHand);

            Assert.Equal(2, indexOfWinningHand);
        }

        [Fact]
        public void PairOfTensPushPairOfTens()
        {
            List<Card> hand1 = new List<Card>();
            hand1.Add(new Card(Rank.Two, Suit.Club));
            hand1.Add(new Card(Rank.Ten, Suit.Diamond));
            hand1.Add(new Card(Rank.Ten, Suit.Spade));
            hand1.Add(new Card(Rank.Five, Suit.Heart));
            hand1.Add(new Card(Rank.Six, Suit.Club));

            List<Card> hand2 = new List<Card>();
            hand2.Add(new Card(Rank.Two, Suit.Spade));
            hand2.Add(new Card(Rank.Ten, Suit.Club));
            hand2.Add(new Card(Rank.Ten, Suit.Heart));
            hand2.Add(new Card(Rank.Five, Suit.Diamond));
            hand2.Add(new Card(Rank.Six, Suit.Spade));

            int indexOfWinningHand = HA.GetWinningHand(hand1, hand2);

            Assert.Equal(0, indexOfWinningHand);
        }

        [Fact]
        public void TieHandShouldGoToWinningRank()
        {
            List<Card> hand1 = new List<Card>();
            hand1.Add(new Card(Rank.Two, Suit.Club));
            hand1.Add(new Card(Rank.Ten, Suit.Diamond));
            hand1.Add(new Card(Rank.Jack, Suit.Spade));
            hand1.Add(new Card(Rank.Five, Suit.Heart));
            hand1.Add(new Card(Rank.Six, Suit.Club));

            List<Card> hand2 = new List<Card>();
            hand2.Add(new Card(Rank.Two, Suit.Spade));
            hand2.Add(new Card(Rank.Ten, Suit.Club));
            hand2.Add(new Card(Rank.Queen, Suit.Heart));
            hand2.Add(new Card(Rank.Five, Suit.Diamond));
            hand2.Add(new Card(Rank.Six, Suit.Spade));

            int indexOfWinningHand = HA.GetWinningHand(hand1, hand2);

            Assert.Equal(2, indexOfWinningHand);
        }
    }
}
