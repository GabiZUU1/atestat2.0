using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atestat2._0
{
    public partial class FrmLogare : Form
    {
        public FrmLogare()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private Image vizibil = Image.FromFile(@"Resurse\vizibil.png");
        private Image ascuns = Image.FromFile(@"Resurse\ascuns.png");

        private bool parolaVizibila = false;
        private void btnAfisParola_Click(object sender, EventArgs e)
        {
            parolaVizibila = !parolaVizibila;
            if(parolaVizibila)
            {
                txtParola.UseSystemPasswordChar = false;
                btnAfisParola.BackgroundImage = vizibil;
            }
            else
            {
                txtParola.UseSystemPasswordChar = true;
                btnAfisParola.BackgroundImage = ascuns;
            }
        }

        private FrmInregistrare inreg;
        private void lnkCreazaCont_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            inreg = new FrmInregistrare();
            inreg.ShowDialog();
        }

        private bool moving = false;
        private Point offset;
        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            this.Opacity = 0.75;
            offset = e.Location;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if(moving)
            {
                this.Location = new Point(MousePosition.X - offset.X - 2, MousePosition.Y - offset.Y - 2);
            }
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            this.Opacity = 1;
        }
    }
}
