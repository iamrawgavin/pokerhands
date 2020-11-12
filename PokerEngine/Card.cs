namespace PokerEngine
{
    public struct Card
    {
        public Suit Suit { get; }
        public Rank Rank { get; }

        public Card (Rank rank, Suit suit)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return "string me up!"; 
        }
    }
}
