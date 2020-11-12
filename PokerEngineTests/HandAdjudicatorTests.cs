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
    }
}
