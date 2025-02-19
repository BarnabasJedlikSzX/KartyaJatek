using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KartyaJatek
{
    public class Asztal
    {
        public Pakli Pakli { get; set; }
        public Jatekos Játékos { get; set; }
        public Jatekos Osztó { get; set; }

        public Asztal(string playerName)
        {
            this.Pakli = new Pakli();
            Pakli.Shuffle();
            this.Játékos = new Jatekos(playerName);
            this.Osztó = new Jatekos("Osztó", true);
        }

        public void DealInitialCards()
        {
            Játékos.Kéz.Add(Pakli.DealCard());
            Osztó.Kéz.Add(Pakli.DealCard());
            Osztó.ShowHand();
            Játékos.Kéz.Add(Pakli.DealCard());
            Osztó.Kéz.Add(Pakli.DealCard());
            Játékos.ShowHand();
        }

        public void Bust()
        {
            while (Játékos.DecideHitOrStand())
            {
                Játékos.Kéz.Add(Pakli.DealCard());
                Játékos.ShowHand();
                if (Játékos.GetHandValue() > 21)
                {
                    Console.WriteLine("BUUUUUUUUUUUUUUUUUST!");
                }
            }

            while (Osztó.GetHandValue() < 17)
            {
                Osztó.Kéz.Add(Pakli.DealCard());
                Osztó.ShowHand();
                if (Osztó.GetHandValue() > 21)
                {
                    Console.WriteLine("Az osztó bustolt! Nyertél!");
                }
            }
        }

        public void PlayRound()
        {
            DealInitialCards();

            Bust();
            
            DetermineWinner();
        }

        public void DetermineWinner()
        {
            int playerValue = Játékos.GetHandValue();
            int dealerValue = Osztó.GetHandValue();

            if (playerValue > 21)
            {
                Console.WriteLine("Bustoltál! Az osztó nyert."); 
            }
            else if (dealerValue > 21)
            {
                Console.WriteLine("Az osztó elbustolt! Nyertél."); 
            }
            else if (playerValue > dealerValue)
            {
                Console.WriteLine("Nyertél!"); 
            }
            else if (playerValue < dealerValue)
            {
                Console.WriteLine("Az osztó nyert!"); 
            }
            else
            {
                Console.WriteLine("Döntetlen!"); 
            }
        }
    }
}
