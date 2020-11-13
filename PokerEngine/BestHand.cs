using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PokerEngine
{
    public struct BestHand
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public HandType Winner { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public Rank Rank { get; }

        public BestHand(HandType winner, Rank rank)
        {
            Winner = winner;
            Rank = rank;
        }
    }
}
