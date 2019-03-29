using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaSim2
{
    public abstract class AllesEter : Dier
    {
        //
        //Methode
        //
        public override void Eet(Leven leven)
        {
            if (leven.IsPlant)
            {
                if (WordtVergiftigdDoor.Contains(leven.NederlandseNaam))
                {
                    if (Hunger())
                    {
                        this.Sterf();
                    }
                    else
                    {
                        SnelheidObject = SnelheidObject.Keerom();
                    }
                }
                else if (MaagGevuld < 100)
                {
                    this.MaagGevuld = leven.Voedingswaarde;
                    leven.Sterf();
                }
            }
            else if (leven.IsDier)
            {
                Dier temp = (Dier)leven;
                if (this.Gewicht > temp.Gewicht)
                {
                    if (this.MaagGevuld < 100)
                    {
                        this.MaagGevuld = this.MaagGevuld + leven.Voedingswaarde;
                        leven.Sterf();
                    }
                }
            }
        } // Eet Methode

        //
        //Constructors
        //
        public AllesEter(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) { }
    }
}
