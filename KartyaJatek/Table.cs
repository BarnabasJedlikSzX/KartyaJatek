using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Table
    {
        public Deck Deck { get; set; }
        public Player Player { get; set; }
        public Player Dealer { get; set; }

        public Table(string playerName)
        {
            Deck = new Deck();
            Deck.Shuffle();
            Player = new Player(playerName);
            Dealer = new Player("Dealer", true); // Dealer is AI
        }

        public void DealInitialCards()
        {
            Player.Hand.Add(Deck.DealCard());
            Dealer.Hand.Add(Deck.DealCard());
            Player.Hand.Add(Deck.DealCard());
            Dealer.Hand.Add(Deck.DealCard());
        }

        public void PlayRound()
        {
            DealInitialCards();

            // Player's turn
            while (Player.DecideHitOrStand())
            {
                Player.Hand.Add(Deck.DealCard());
                Player.ShowHand();
                if (Player.GetHandValue() > 21)
                {
                    Console.WriteLine("You busted!");
                    return;
                }
            }

            // Dealer's turn
            while (Dealer.GetHandValue() < 17)
            {
                Dealer.Hand.Add(Deck.DealCard());
                Dealer.ShowHand(true);
                if (Dealer.GetHandValue() > 21)
                {
                    Console.WriteLine("Dealer busts! You win!");
                    return;
                }
            }

            // Compare hands
            DetermineWinner();
        }

        public void DetermineWinner()
        {
            int playerValue = Player.GetHandValue();
            int dealerValue = Dealer.GetHandValue();

            if (playerValue > 21)
            {
                Console.WriteLine("You busted! Dealer wins.");
            }
            else if (dealerValue > 21)
            {
                Console.WriteLine("Dealer busts! You win.");
            }
            else if (playerValue > dealerValue)
            {
                Console.WriteLine("You win!");
            }
            else if (playerValue < dealerValue)
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
