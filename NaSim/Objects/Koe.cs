using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NaSim2
{
	public class Koe : Planteneter
	{
        //
        //InitClass
        //
        public Koe() : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(new Point(0, 0), "", Color.Brown);
        }
        public Koe(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Color.Brown);
        }
        public Koe(Point locatie, string naam, Color kleur) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, naam, kleur);
        }
        //
        //InitClass Methode
        //
        private void initClass(Point locatie,string naam,Color kleur)
        {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur;
            Tekengebied.Afmetingen = new Size(80, 40);
            WordtVergiftigdDoor.Add("Vingerhoedskruid");
            WordtVergiftigdDoor.Add("Venijnboom");
            Gewicht = 400;
            Voedingswaarde = 5;
        }

        //
        //Constante Vars
        //
        private const string _latijnseNaam = "Bos taurus";
        private const byte _leeftijd = 25;
        private const byte _verhoudingTicksJaren = 1;
        private const double _gewichtMaximaal = 800;

        //
        //Publieke Props
        //
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime SterfDatum { get; set; }
    }
}
