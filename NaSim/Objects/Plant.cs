using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaSim2
{
    public abstract class Plant : Leven
    {
        //
        //Init
        //
        public Plant() { }
        public Plant(int verhoudingTicksJaren, string latijnseNaam, int levensduur, Bloeiwijze bloeiwijze) : base(verhoudingTicksJaren, latijnseNaam, levensduur)
        { BloeiwijzePlant = bloeiwijze; }

        //
        //Props
        //
        public Bloeiwijze BloeiwijzePlant { get; set; }

        public Bloeiwijze Bloeiwijze
        {
            get => default(Bloeiwijze);
            set
            {
            }
        }

        //
        //Override Methodes
        //
        public override string ToString()
        {
            return "Latijnse naam: " + LatijnseNaam + Environment.NewLine + Environment.NewLine + "Nederlandse naam: " + NederlandseNaam + Environment.NewLine + Environment.NewLine + "Levensduur: " + Levensduur + Environment.NewLine + Environment.NewLine + "Bloeiwijze:" + Bloeiwijze + Environment.NewLine + Environment.NewLine + "Locatie: " + Locatie.ToString();
        }
    }
}
