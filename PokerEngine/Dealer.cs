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
            int gameWinnerNumber = HandAdjudicator.GetWinningHand(Game.PlayerOneCards, Game.PlayerTwoCards);
            string gameWinnerName = string.Empty;
            switch(gameWinnerNumber)
            {
                case 0:
                    gameWinnerName = "Push";
                    break;
                case 1:
                    gameWinnerName = "Player 1";
                    break;
                case 2:
                    gameWinnerName = "Player 2";
                    break;
            }
            Game.Winner = gameWinnerName;
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
