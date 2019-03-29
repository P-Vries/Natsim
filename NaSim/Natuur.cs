using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NaSim2
{
    class Natuur : List<Leven>
    {       
        //
        //Constructors
        //
        public Natuur() : base()
        {
            _levensKlok.Interval = 1;
            _levensKlok.Start();
            _levensKlok.Tick += _levensKlok_Tick;
        }

        //
        //Privé Vars
        //
        Timer _levensKlok = new Timer();

        //
        //Publieke Methodes
        //
        public event EventHandler<NieuwLevenEventArgs> NieuwLeven;  //Nieuw Leven Event Handler
        public event EventHandler<GetroffenEventArgs> Getroffen;    //Nieuw Leven Event Handler
        public void LevenGeraakt(Point locatie)
        {
            foreach (Leven leven in this)
            {
                leven.IsOpObject(locatie);
            }
        }
        public new void Add(Leven leven)
        {
            leven.Einde += leven_Einde;
            leven.OpObject += leven_OpObject;
            if (leven.IsDier)
            {
                Random random = new Random();
                Snelheid snelheid = new Snelheid(random.Next(-4, 4), random.Next(-4, 4));
                ((Dier)leven).SnelheidObject = snelheid;
            }
            base.Add(leven);

            if (NieuwLeven != null)
            {
                NieuwLeven(this, new NieuwLevenEventArgs(leven));
            }
        }
        public void CollisionDetection(Dier dier)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if(dier.ID != this[i].ID)
                {
                    dier.IsBotsing(this[i]);
                }
            }
        }

        //
        //Privé Methodes
        //
        private void leven_Einde(object sender,EventArgs e)
        {
            this.Remove((Leven)sender);
        }
        private void leven_OpObject(object sender, EventArgs e)
        {
            if (Getroffen != null)
            {
                Getroffen(this, new GetroffenEventArgs((Leven)sender));
            }
        }
        private void _levensKlok_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Count; i++)
            {
                Dier dier = this[i].ToDier();
                if (dier != null)
                {
                    dier.Beweeg();
                    CollisionDetection(dier);
                }
            }
        }
    }

    //
    //Event Classes
    //
    public class NieuwLevenEventArgs : EventArgs
    {
        //
        //Constructor
        //
        public NieuwLevenEventArgs(Leven leven)
        {
            NieuwLeven = leven;
        }
        public Leven NieuwLeven { get; set; }
    }

    public class GetroffenEventArgs : EventArgs
    {
        //Constructor
        public GetroffenEventArgs(Leven leven)
        {
            Getroffen = leven;
            GeraaktOp = DateTime.Now;
        }
        //Props
        public Leven Getroffen { get; set; }
        public DateTime GeraaktOp { get; set; }
    }
}
