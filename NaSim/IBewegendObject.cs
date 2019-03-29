using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace NaSim2
{
     public interface IBewegendObject
    {
        //
        //Properties
        //
        Snelheid SnelheidObject { get; set; }
        Timer klok { get; set; }

        //
        //Methode
        //
        Point Stap();
        Point Stap(Snelheid snelheidObject);
    }
}
