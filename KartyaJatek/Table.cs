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

        public void PlayRound()
        {
            Console.Clear();
            DealInitialCards();

            while (Játékos.DecideHitOrStand())
            {
                Játékos.Kéz.Add(Pakli.DealCard());
                Játékos.ShowHand();
                if (Játékos.GetHandValue() > 21)
                {
                    DetermineWinner();
                }
            }

            while (Osztó.GetHandValue() < 17)
            {
                Osztó.Kéz.Add(Pakli.DealCard());
                Osztó.ShowHand();
                if (Osztó.GetHandValue() > 21)
                {
                    DetermineWinner();
                }
            }

            DetermineWinner();
            Console.ReadLine();
            Continue();
        }

        public void DetermineWinner()
        {
            Console.Clear();
            Játékos.ShowHand();
            Osztó.ShowHand();
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

        public void Continue()
        {
            Console.Clear();
            Console.WriteLine("Szeretnéd folytatni? (i/n)");
            char choice;
            do
            {
                choice = Console.ReadKey(true).KeyChar;
            } while (choice != 'i' && choice != 'n');
            if (choice == 'i')
            {
                foreach (var jatekos in Játékos.Kéz)
                {
                    Pakli.Kartyak.Add(jatekos);
                }
                foreach (var oszto in Osztó.Kéz)
                {
                    Pakli.Kartyak.Add(oszto);
                }
                Pakli.Shuffle();
                Játékos.Kéz.Clear();
                Osztó.Kéz.Clear();
                PlayRound();
            }
            else
                return;
        }
    }
}
