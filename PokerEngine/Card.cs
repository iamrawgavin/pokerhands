using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PokerEngine
{
    public struct Card
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Suit Suit { get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Rank Rank { get; }

        public Card (Rank rank, Suit suit)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
