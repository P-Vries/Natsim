using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Timers;

namespace NaSim2
{
    public class Konijn : Planteneter
    {
        //
        //Init
        //
        public Konijn():base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(new Point(0, 0), "", Color.Brown);
        }
        public Konijn(Point locatie) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, "", Color.Brown);
        }
        public Konijn(Point locatie, string naam, Color kleur) : base(_verhoudingTicksJaren, _latijnseNaam, _leeftijd, _gewichtMaximaal)
        {
            initClass(locatie, naam, kleur);
        }
        
        //
        //Init Methode
        //
        private void initClass(Point locatie, string naam, Color kleur)
        {
            Locatie = locatie;
            Naam = naam;
            Kleur = kleur;
            Tekengebied.Afmetingen = new Size(10, 10);
            WordtVergiftigdDoor.Add("Vingerhoedskruid");
            WordtVergiftigdDoor.Add("Venijnboom");
            Gewicht = 5;
            Voedingswaarde = 1;
            this.Teken();
        }

        //
        //Constante Vars
        //
        private const string _latijnseNaam = "Oryctolagus cuniculus";
        private const byte _leeftijd = 9;
        private const byte _verhoudingTicksJaren = 1;
        private const double _gewichtMaximaal = 10;

        //
        //Publieke Props
        //
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public DateTime SterfDatum { get; set; }


    }
}
