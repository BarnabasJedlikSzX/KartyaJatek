﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Osztó = new Jatekos("Osztó", true); // Dealer is AI
        }

        public void DealInitialCards()
        {
            Játékos.Kéz.Add(Pakli.DealCard());
            Osztó.Kéz.Add(Pakli.DealCard());
            Játékos.Kéz.Add(Pakli.DealCard());
            Osztó.Kéz.Add(Pakli.DealCard());
        }

        public void PlayRound()
        {
            DealInitialCards();

            // Player's turn
            while (Játékos.DecideHitOrStand())
            {
                Játékos.Kéz.Add(Pakli.DealCard());
                Játékos.ShowHand();
                if (Játékos.GetHandValue() > 21)
                {
                    Console.WriteLine("BUUUUUUUUUUUUUUUUUST!");
                    return;
                }
            }

            // Dealer's turn
            while (Osztó.GetHandValue() < 17)
            {
                Osztó.Kéz.Add(Pakli.DealCard());
                Osztó.ShowHand(true);
                if (Osztó.GetHandValue() > 21)
                {
                    Console.WriteLine("Az osztó bustolt! Nyertél!");
                    return;
                }
            }

            // Compare hands
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
