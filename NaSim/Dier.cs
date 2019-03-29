using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NaSim2
{
    public abstract class Dier : Leven, IBewegendObject
    {
        //
        //Constructor
        //
        public Dier(int verhoudingTicksJaren, string latijnseNaam, int levensduur, double gewichtMaximaal) : base(verhoudingTicksJaren, latijnseNaam, levensduur)
        {
            initDier(gewichtMaximaal);
        }
        private void initDier(double gewichtMaximaal)
        {
            _gewichtMaximaal = gewichtMaximaal;
            WordtVergiftigdDoor = new List<string>();
        }

        //
        //Private Vars
        //
        private double _gewichtMaximaal = 0;//kg

        //
        //Public Props
        //
        public int MaagGevuld { get; set; }
        public int SpijsverteringsDuur { get; set; }
        public double GewichtMaximaal { get { return (_gewichtMaximaal); } }  //Read-Only//
        public List<string> WordtVergiftigdDoor { get; set; }
        public Snelheid SnelheidObject { get; set; }
        public int Gewicht { get; set; }

        //
        //Methoden
        //
        public abstract void Eet(Leven leven);
        public bool Hunger()
        {
            return (MaagGevuld < 25);
        }
        public void Beweeg()
        {
            Verwijder();
            Locatie = Stap();
            Teken();
        }
        public bool IsBotsing(Leven leven)
        {
            if (this.Tekengebied.Overlap(leven.Tekengebied))
            {
                Dier dier = leven.ToDier();
                if (dier != null)
                {
                    this.SnelheidObject = this.SnelheidObject.Keerom();
                    dier.SnelheidObject = dier.SnelheidObject.Keerom();
                }
                Eet(leven);
                return true;
            }
            else return false;
        }

        //
        //Mehoden IBewegendObject Interface
        //
        public Point Stap()
        {
            return Stap(this.SnelheidObject);
        }
        public Point Stap(Snelheid snelheidObject)
        {
            this.SnelheidObject = snelheidObject;

            int berekenX = Locatie.X + (SnelheidObject.X);
            int berekenY = Locatie.Y + (SnelheidObject.Y);

            Rechthoek nieuwTekenGebied = new Rechthoek(new Point(berekenX, berekenY), Tekengebied.Afmetingen);
            Vlak vlak = Rechthoek.Grensberijkt(nieuwTekenGebied, GraphicsVenster);
            SnelheidObject = SnelheidObject.Stuiter(vlak);

            berekenX = Locatie.X + (SnelheidObject.X);
            berekenY = Locatie.Y + (SnelheidObject.Y);
            return new Point(berekenX, berekenY);
        }
        public Timer klok { get; set; }

        //
        //Override Methodes
        //
        public override string ToString()
        {
            return "Latijnse naam: " + LatijnseNaam + Environment.NewLine + Environment.NewLine + "Nederlandse naam: " + NederlandseNaam + Environment.NewLine + Environment.NewLine + "Levensduur: " + Levensduur + Environment.NewLine + Environment.NewLine + "Locatie: " + Locatie.ToString();
        }
    }
}
