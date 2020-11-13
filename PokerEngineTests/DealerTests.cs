using System;
using Xunit;
using System.Collections.Generic;
using PokerEngine;

namespace PokerEngineTests
{
    public class DealerTests
    {
        public DealerTests()
        {
        }

        [Fact]
        public void PlayedGameHasAWinner()
        {
            Dealer dealer = new Dealer();
            PokerGame game = dealer.PlayHand();

            Assert.StartsWith("Player", game.Winner);
        }

        [Fact]
        public void PlayedGameHasTwoListsOfFiveCards()
        {
            Dealer dealer = new Dealer();
            PokerGame game = dealer.PlayHand();

            Assert.Equal(5, game.PlayerOneCards.Count);
            Assert.Equal(5, game.PlayerTwoCards.Count);
        }
    }
}
