using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerEngine
{
    public class CardDeck
    {
        public List<Card> Cards { get; set; }

        public CardDeck()
        {
            MakeDeck();
        }

        public void MakeDeck()
        {
            Cards = Enumerable.Range(0, 4)
                              .SelectMany(s => Enumerable.Range(2, 13)
                                                         .Select(r => new Card((Rank)r, (Suit)s))).ToList();                                                       
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList();
        }

        public Card TakeCard()
        {
            Card card = Cards.First();
            Cards.Remove(card);
            return card;
        }
    }
}
