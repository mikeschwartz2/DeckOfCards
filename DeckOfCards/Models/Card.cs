using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{
    public class card
    {
        public Hand Cards { get; set; }
    }
    public class Hand
    {
            public string Image { get; set; }
            public string Value { get; set; }
            public string Suit { get; set; }
    }

    public class CardList
    {
        public Hand[] Cards { get; set; } 
    }
}
