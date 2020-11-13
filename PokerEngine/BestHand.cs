using System;
namespace PokerEngine
{
    public struct BestHand
    {
        public HandType Winner { get; }
        public Rank Rank { get; }

        public BestHand(HandType winner, Rank rank)
        {
            Winner = winner;
            Rank = rank;
        }
    }
}
