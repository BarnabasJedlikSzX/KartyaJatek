using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Deck
    {
        Random random = new Random();
        public List<Card> Cards { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    int points = GetCardPoints(value);
                    Cards.Add(new Card(suit, value, points));
                }
            }
        }

        private int GetCardPoints(string value)
        {
            switch (value)
            {
                case "Jack":
                case "Queen":
                case "King":
                    return 10;
                case "Ace":
                    return 11;
                default:
                    return int.Parse(value);
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < Cards.Count; i++)
            {
                int j = random.Next(i, Cards.Count);
                var temp = Cards[i];
                Cards[i] = Cards[j];
                Cards[j] = temp;
            }
        }

        public Card DealCard()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }
    }
}
