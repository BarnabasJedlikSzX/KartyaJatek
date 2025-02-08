using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KartyaJatek
{
    public class Kartya
    {
        public string Szin { get; set; }
        public string Ertek { get; set; }
        public int Pont { get; set; }

        public Kartya(string szin, string ertek, int pont)
        {
            this.Szin = szin;
            this.Ertek = ertek;
            this.Pont = pont;
        }

    }
}
