using System;
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

        public string PlayRound()
        {
            DealInitialCards();

            while (Játékos.DecideHitOrStand())
            {
                Játékos.Kéz.Add(Pakli.DealCard());
                Játékos.ShowHand();
                if (Játékos.GetHandValue() > 21)
                {
                    return "BUUUUUUUUUUUUUUUUUST!";
                }
            }

            while (Osztó.GetHandValue() < 17)
            {
                Osztó.Kéz.Add(Pakli.DealCard());
                Osztó.ShowHand();
                if (Osztó.GetHandValue() > 21)
                {
                    return "Az osztó bustolt! Nyertél!";
                }
            }

            DetermineWinner();
        }

        public string DetermineWinner()
        {
            int playerValue = Játékos.GetHandValue();
            int dealerValue = Osztó.GetHandValue();

            if (playerValue > 21)
            {
                return "Bustoltál! Az osztó nyert.";
            }
            else if (dealerValue > 21)
            {
                return "Az osztó elbustolt! Nyertél.";
            }
            else if (playerValue > dealerValue)
            {
                return "Nyertél!";
            }
            else if (playerValue < dealerValue)
            {
                return "Az osztó nyert!";
            }
            else
            {
                return "Döntetlen!";
            }
        }
    }
}
