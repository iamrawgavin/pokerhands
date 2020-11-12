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
            Card highCard = HA.GetHighCardFromHand(FlopHand);

            Assert.Equal(new Card(Rank.Ten, Suit.Club), highCard);
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
    }
}
