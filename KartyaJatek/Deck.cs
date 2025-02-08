using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Pakli
    {
        Random random = new Random();
        public List<Kartya> Kartyak { get; set; }

        public Pakli()
        {
            Kartyak = new List<Kartya>();
            InitializeDeck();
        }

        private void InitializeDeck()
        {
            string[] suits = { "Kőr", "Káró", "Treff", "Pikk" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Bubi", "Dáma", "Király", "Ász" };
            foreach (var suit in suits)
            {
                foreach (var value in values)
                {
                    int points = GetCardPoints(value);
                    Kartyak.Add(new Kartya(suit, value, points));
                }
            }
        }

        private int GetCardPoints(string value)
        {
            switch (value)
            {
                case "Bubi":
                case "Dáma":
                case "Király":
                    return 10;
                case "Ász":    
                    return 11;
                default:
                    return int.Parse(value);
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < Kartyak.Count; i++)
            {
                int j = random.Next(i, Kartyak.Count);
                var temp = Kartyak[i];
                Kartyak[i] = Kartyak[j];
                Kartyak[j] = temp;
            }
        }

        public Kartya DealCard()
        {
            Kartya card = Kartyak[0];
            Kartyak.RemoveAt(0);
            return card;
        }
    }
}
