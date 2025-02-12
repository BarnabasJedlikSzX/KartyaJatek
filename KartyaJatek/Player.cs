using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Jatekos
    {
        public string Név { get; set; }
        public List<Kartya> Kéz { get; set; }
        public bool IsAI { get; set; }

        public Jatekos(string név, bool isAI = false)
        {
            this.Név = név;
            this.Kéz = new List<Kartya>();
            this.IsAI = isAI;
        }

        public int GetHandValue()
        {
            int value = 0;
            int aceCount = 0;

            foreach (var card in Kéz)
            {
                value += card.Pont;
                if (card.Ertek == "Ace")
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
            Console.WriteLine($"{Név}'s Hand:");
            foreach (var card in Kéz)
            {
                Console.WriteLine($"{card.Ertek} of {card.Szin}");
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
                Console.WriteLine("Hit vagy stand?");
                string choice = Console.ReadLine().ToLower();
                return choice == "hit";
            }
        }
    }
}
