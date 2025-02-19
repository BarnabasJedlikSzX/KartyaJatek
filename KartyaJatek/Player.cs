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
                if (card.Ertek == "Ász")
                    aceCount++;
            }

            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }

            return value;
        }

        public void ShowHand(bool revealFullHand = true)
        {
            Console.WriteLine($"{Név} keze:");
            foreach (var card in Kéz)
            {
                Console.WriteLine($"{card.Szin} {card.Ertek}");
            }
            Console.WriteLine($"Összesen: {GetHandValue()}");
        }

        public bool DecideHitOrStand()
        {
            if (IsAI)
            {
                if (GetHandValue() < 17)
                    return true;
                else
                    return false;
            }
            else
            {

                Console.WriteLine("Hit vagy stand?");
                string choice;
                do
                {
                    choice = Console.ReadLine()!.ToLower();
                } while (choice.ToLower() != "hit" && choice.ToLower() != "stand");
                if (choice.ToLower() == "hit")
                    return true;
                else
                    return false;

            }
        }
    }
}
