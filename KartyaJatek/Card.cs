using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Card
    {
        public string Suit { get; set; }
        public string Value { get; set; }
        public int Points { get; set; }

        public Card(string suit, string value, int points)
        {
            Suit = suit;
            Value = value;
            Points = points;
        }

    }
}
