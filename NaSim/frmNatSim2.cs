using NaSim2.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaSim2
{
	public partial class frmNatSim2 : Form
	{
        //
        //Form Init.
        //
		Graphics papier;

        SoortLeven soortDier = SoortLeven.Konijn;
        SoortLeven soortPlant = SoortLeven.Gras;
        Natuur natuur = new Natuur();

		public frmNatSim2()
		{
			InitializeComponent();
			papier = pbWereld.CreateGraphics();
            natuur.NieuwLeven += Natuur_NieuwLeven;
            natuur.Getroffen += natuur_Getroffen;
		}

        private void natuur_Getroffen(object sender, GetroffenEventArgs e)
        {
            lblInfo.Text = e.GeraaktOp.ToString("hh:mm:ss tt") + Environment.NewLine + Environment.NewLine + e.Getroffen.ToString();
        }

        private void Natuur_NieuwLeven(object sender, NieuwLevenEventArgs e)
        {
            e.NieuwLeven.Teken(papier);
        }

        //
        //Methodes
        //
        private void ResizePB()
		{
			int margeBreedte = 40;
			int margeHoogte = 64;
			pbWereld.Width = this.Width - grbDieren.Width - grbPlanten.Width - margeBreedte;
			pbWereld.Height = this.Height - margeHoogte;
			papier = pbWereld.CreateGraphics();
		}
		private void ResizeLBL()
		{
			int margeHoogte = 88;
			lblInfo.Height = this.Height - margeHoogte - pnlKnoppen.Height;
		}
		private void btnEinde_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void frmNatSim_Resize(object sender, EventArgs e)
		{
			ResizePB();
			ResizeLBL();
		}

        private void pbWereld_MouseClick(object sender, MouseEventArgs e)
        {
            SoortLeven soortLeven = SoortLeven.Gras;
            if (e.Button == MouseButtons.Left)
            {
                soortLeven = soortDier;
            }
            if (e.Button == MouseButtons.Right)
            {
                soortLeven = soortPlant;
            }
            switch (soortLeven)
            {
                case SoortLeven.Gras:
                    natuur.Add(new Gras(e.Location));
                    break;
                case SoortLeven.Vingerhoedskruid:
                    natuur.Add(new Vingerhoedskruid(e.Location));
                    break;
                case SoortLeven.Venijnboom:
                    natuur.Add(new Venijnboom(e.Location));
                    break;
                case SoortLeven.Koe:
                    natuur.Add(new Koe(e.Location));
                    break;
                case SoortLeven.Konijn:
                    natuur.Add(new Konijn(e.Location));
                    break;
                case SoortLeven.Beer:
                    natuur.Add(new Beer(e.Location));
                    break;
                case SoortLeven.Lynx:
                    natuur.Add(new Lynx(e.Location));
                    break;
                case SoortLeven.Jaguar:
                    natuur.Add(new Jaguar(e.Location));
                    break;
                default:
                    break;
            }
            
        }
        private void TekenDier(Point pos)
        {
         //   if (rdbKonijn.Checked == true)
            {
                Konijn konijn01 = new Konijn(pos, "Flappie", Color.Brown);
                konijn01.Teken(pbWereld.CreateGraphics());
            }
           // else if (rdbKoe.Checked == true)
            {
                Koe koe01 = new Koe(pos);
                koe01.Teken(pbWereld.CreateGraphics());
            }
           // else if (rdbBeer.Checked) { Beer beer1 = new Beer(pos); beer1.Teken(pbWereld.CreateGraphics()); }
       //     else if (rdbGras.Checked) { Gras gras1 = new Gras(pos); gras1.Teken(pbWereld.CreateGraphics()); }
        //  else if (rdbJaguar.Checked) { Jaguar jaguar1 = new Jaguar(pos); jaguar1.Teken(pbWereld.CreateGraphics()); }
        //   else if (rdbLynx.Checked) { Lynx lynx1 = new Lynx(pos); lynx1.Teken(pbWereld.CreateGraphics()); }
          //  else if (rdbVenijnboom.Checked) { Venijnboom venijnboom1 = new Venijnboom(pos); venijnboom1.Teken(pbWereld.CreateGraphics()); }
           // else if (rdbVingerhoedskruid.Checked) { Vingerhoedskruid vingerhoedskruid1 = new Vingerhoedskruid(pos); vingerhoedskruid1.Teken(pbWereld.CreateGraphics()); }
        }
        private void TekenVegitatie(Point pos)
        {
            if (rdbGras.Checked == true)
            {
                Gras gras01 = new Gras(pos);
                gras01.Teken(pbWereld.CreateGraphics());
            }
            if (rdbVenijnboom.Checked == true)
            {
                Venijnboom venijnboom01 = new Venijnboom(pos);
                venijnboom01.Teken(pbWereld.CreateGraphics());
            }
        }

        private void rdbKonijn_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKonijn.Checked) soortDier = SoortLeven.Konijn;
        }

        private void rdbGras_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGras.Checked) soortPlant = SoortLeven.Gras;
        }

        private void rdbKoe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKoe.Checked) soortDier = SoortLeven.Koe;
        }

        private void rdbLynx_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLynx.Checked) soortDier = SoortLeven.Lynx;
        }

        private void rdbBeer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBeer.Checked) soortDier = SoortLeven.Beer;
        }

        private void rdbVenijnboom_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVenijnboom.Checked) soortPlant = SoortLeven.Venijnboom;
        }

        private void rdbVingerhoedskruid_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbVingerhoedskruid.Checked) soortPlant = SoortLeven.Vingerhoedskruid;
        }

        private void rdbJaguar_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbJaguar.Checked) soortDier = SoortLeven.Jaguar;
        }

        private void pbWereld_MouseMove(object sender, MouseEventArgs e)
        {

            lblInfo.Text = "";
            natuur.LevenGeraakt(e.Location);

        }


    }

    
}

