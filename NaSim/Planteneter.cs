using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaSim2
{
    public abstract class Planteneter : Dier
    {
        //
        //Methodes
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
                        leven.Teken();
                    }
                    else
                    {
                        SnelheidObject = SnelheidObject.Keerom();
                    }
                }
                else if (MaagGevuld < 100)
                {
                    MaagGevuld = MaagGevuld + leven.Voedingswaarde;
                    leven.Sterf();
                }
            }
            else { SnelheidObject = SnelheidObject.Keerom(); }
        }

        //
        //Constructor
        //
        public Planteneter(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingTicksJaren, latijnseNaam, levensduur, gewichtMaximaal) { }
    }
}
