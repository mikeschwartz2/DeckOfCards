using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeckOfCards.Models
{
    public class Deck
    {
        private string deck_id;
        private int remaining;

        public string Deck_Id { get => deck_id; set => deck_id = value; }
        public int Remaining { get => remaining; set => remaining = value; }
    }
}
