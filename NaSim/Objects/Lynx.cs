using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NaSim2
{
	public class Lynx: VleesEter
    {
        //
        //Init Class
        //
        public Lynx() : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(new Point(0, 0), "", Color.Gray);
        }
        public Lynx(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Color.Gray);
        }
        public Lynx(Point locatie, string naam, Color kleur) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
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
            Tekengebied.Afmetingen = new Size(7,4);
            Gewicht = 100;
            Voedingswaarde = 8;
        }

        //
        //Constante Vars
        //
        private const string _latijnseNaam = "Lynx";
        private const byte _leeftijd = 24;
        private const int _verhoudingTicksJaren = 1;
        private const double _gewichtMaximaal = 38;

        //
        //Publieke Props
        //
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime SterfDatum { get; set; }
    }
}
