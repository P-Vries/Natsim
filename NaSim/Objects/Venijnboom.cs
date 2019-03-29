using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace NaSim2
{
    public class Venijnboom : Plant
    {
        //
        //Init
        //
        public Venijnboom():base(1,"Taxus Bacatta", 2000, Bloeiwijze.kegel)
        {
            initClass(new Point(0, 0));
        }
        public Venijnboom(Point locatie):base(1, "Taxus Bacatta", 2000, Bloeiwijze.kegel)
        {
            initClass(locatie);
        }
        private void initClass(Point locatie)
        {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(10, 400);
            Kleur = Color.ForestGreen;
        }

        //
        //Vars
        //
        private List<string> _geneesmiddelVoor = new List<string> { "Longkanker", "Borstkanker" };
        private int _maxGrootte = 20000;

        //
        //Read-Only Props
        //
        public List<string> GeneesmiddelVoor { get { return _geneesmiddelVoor; } }
        public int MaxGrootte { get { return _maxGrootte; } }

        //
        //Props
        //
        public double AantalKubiekeMetersHout { get; set; }

    }
}
