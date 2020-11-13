using System;
namespace PokerEngine
{
    public class Dealer
    {
        private CardDeck Deck;
        private PokerGame Game;
        private HandAdjudicator HandAdjudicator;

        public Dealer()
        {
            Deck = new CardDeck();
            Game = new PokerGame();
            HandAdjudicator = new HandAdjudicator();
        }

        public PokerGame PlayHand()
        {
            Deck.Shuffle();
            Deal();
            Game.PlayerOneBestHand = HandAdjudicator.GetBestHand(Game.PlayerOneCards);
            Game.PlayerTwoBestHand = HandAdjudicator.GetBestHand(Game.PlayerTwoCards);
            Game.Winner = HandAdjudicator.GetWinningHand(Game.PlayerOneCards, Game.PlayerTwoCards) == 1 ? "Player 1" : "Player 2";
            return Game;
        }

        private void Deal()
        {
            for (int i = 0; i < 5; i++)
            {
                Game.PlayerOneCards.Add(Deck.TakeCard());
                Game.PlayerTwoCards.Add(Deck.TakeCard());
            }
        }
    }
}
