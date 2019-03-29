using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NaSim2
{
	public class Beer:AllesEter
    {
        //
        //Init Class
        //
        public Beer() : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(new Point(0, 0), "", Color.White);
        }
        public Beer(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Color.White);
        }
        public Beer(Point locatie, string naam, Color kleur) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, naam, kleur);
        }
        //
        //Init Class Methode
        //
        private void initClass(Point locatie, string naam, Color kleur)
        {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur;
            Tekengebied.Afmetingen = new Size(20,20);
            WordtVergiftigdDoor.Add("Vingerhoedskruid");
            WordtVergiftigdDoor.Add("Venijnboom");
            Gewicht = 200;
            Voedingswaarde = 20;
        }

        //
        //Constante Vars
        //
        private const string _latijnseNaam = "Ursidae";
        private const byte _leeftijd = 20;
        private const int _verhoudingTicksJaren = 1;
        private const double _gewichtMaximaal = 200;

        //
        //Publieke Props
        //
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime SterfDatum { get; set; }
    }
}
