using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }
        public bool IsAI { get; set; }

        public Player(string name, bool isAI = false)
        {
            Name = name;
            Hand = new List<Card>();
            IsAI = isAI;
        }

        public int GetHandValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in Hand)
            {
                value += card.Points;
                if (card.Value == "Ace")
                    aceCount++;
            }

            // Adjust for aces (Ace can be 1 or 11)
            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }

        public void ShowHand(bool revealFullHand = true)
        {
            Console.WriteLine($"{Name}'s Hand:");
            foreach (var card in Hand)
            {
                Console.WriteLine($"{card.Value} of {card.Suit}");
            }
            Console.WriteLine($"Total: {GetHandValue()}");
        }

        public bool DecideHitOrStand()
        {
            if (IsAI)
            {
                return GetHandValue() < 17; // AI hits if hand value < 17
            }
            else
            {
                Console.WriteLine("Would you like to 'hit' or 'stand'?");
                string choice = Console.ReadLine().ToLower();
                return choice == "hit";
            }
        }
    }
}
