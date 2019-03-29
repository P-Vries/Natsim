using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaSim2
{
    public abstract class VleesEter : Dier
    {
        //
        //Methodes
        //
        public override void Eet(Leven leven)
        {
            if (leven.IsDier)
            {

                Dier temp = (Dier)leven;
                if (leven.NederlandseNaam == this.NederlandseNaam)
                {
                    if (this.Gewicht > temp.Gewicht)
                    {
                        if (MaagGevuld < 100)
                        {
                            MaagGevuld = MaagGevuld + leven.Voedingswaarde;
                            leven.Sterf();
                        }
                    }
                }
                else
                {
                    SnelheidObject = SnelheidObject.Keerom();
                }
            }
        }
        //
        //Constructor
        //
        public VleesEter(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) { }
    }
}
