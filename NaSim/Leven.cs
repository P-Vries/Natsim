using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaSim2
{
    public abstract class Leven : GrafischObject
    {
        //
        //Constructors
        //
        public Leven() { initClass(1, "", int.MaxValue); } //Init Class leeg
        public Leven(int verhoudingTicksJaren, string latijnseNaam, int levensduur)
        {
            initClass(verhoudingTicksJaren, latijnseNaam, levensduur);
        } //Init class details

        //
        //Methodes
        //
        private void initClass(int verhoudingTicksJaren, string latijnseNaam, int levensduur)
        {
            VerhoudingTicksJaren = verhoudingTicksJaren;
            _levensduur = levensduur;
            _latijnseNaam = latijnseNaam;
            _verouder = new Timer();
            _verouder.Interval = _aantalTicksPerSeconde * VerhoudingTicksJaren;
            _verouder.Start();
            _verouder.Tick += _verouder_Tick;
        }
        private void _verouder_Tick(object sender, EventArgs e)
        {
            if(Leeftijd < Levensduur)
            {
                Leeftijd++;
            }
            else
            {
                _verouder.Stop();
                Sterf();
            }
        }
        public bool IsPlant
        {
            get { return this.GetType().IsSubclassOf(typeof(Plant)); }
        }
        public bool IsDier
        {
            get { return this.GetType().IsSubclassOf(typeof(Dier)); }
        }
        public void Sterf()
        {
            //MessageBox.Show(this.NederlandseNaam + " wordt verwijdert");
            Verwijder();
            OnEinde();
        }
        public Dier ToDier()
        {
            if (IsDier) return (Dier)this;
            else return null;
        }
        public Plant ToPlant()
        {
            if (IsPlant) return (Plant)this;
            else return null;

        }
        public SoortLeven ToSoort()
        {
            switch (NederlandseNaam.ToLower())
            {
                case "beer": return SoortLeven.Beer;
                case "gras": return SoortLeven.Gras;
                case "koe": return SoortLeven.Koe;
                case "konijn": return SoortLeven.Konijn;
                case "lynx": return SoortLeven.Lynx;
                case "venijnboom": return SoortLeven.Venijnboom;
                case "vingerhoedskruid": return SoortLeven.Vingerhoedskruid;
                case "jaguar": return SoortLeven.Jaguar;
                default: return SoortLeven.Gras;
            }
        }
        public Gras ToGras()
        {
            if (this.GetType() == typeof(Gras))
            {
                return (Gras)this;//this cast als Gras
            }
            else { return null; }//null
        }

        //
        // Interne Vars
        //
        private const int _aantalTicksPerSeconde = 1000;
        private string _latijnseNaam;
        private double _levensduur;
        private Timer _verouder;

        //
        //Public Props
        //
        public int Leeftijd { get; set; }
        public int VerhoudingTicksJaren { get; set; }
        public int Voedingswaarde { get; set; }

        //
        //Read-Only Props
        //
        public string LatijnseNaam { get { return _latijnseNaam; } }
        public double Levensduur { get { return _levensduur; } }
        public string NederlandseNaam { get { return base.ToString().Split('.').Last(); } }
        public Timer Verouder { get { return _verouder; } }

        //
        //Events
        //
        public event EventHandler<EventArgs> Einde;
        protected virtual void OnEinde()
        {
            if (Einde != null)
            {
                Einde(this, EventArgs.Empty);
            }
        }
    }
}
