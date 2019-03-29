using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NaSim2
{
    public class Vingerhoedskruid : Plant
    {
        //
        //Init
        //
        public Vingerhoedskruid() : base(4, "Digitalis Purpurea",4,Bloeiwijze.tros)
        {
            initClass(new Point(0, 0));
        }
        public Vingerhoedskruid(Point locatie):base(4, "Digitalis Purpurea", 4, Bloeiwijze.tros)
        {
            initClass(locatie);
        }
        private void initClass(Point locatie)
        {
            Locatie = locatie;
            Tekengebied.Afmetingen = new Size(2, 10);
            Kleur = Color.LightGreen;
            Voedingswaarde = 1;
        }
    }
}
