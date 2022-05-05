using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z25_studenti
{//8, pre toga Design[], menustrip kontrola se ubaci 
    public partial class StudentiGlavna : Form
    {
        public StudentiGlavna()
        {
            InitializeComponent();
        }

        private void studentiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prikazati formu Studenti
            //9 napravljene FormaSmerovi i FormaStudenti
            //10
            FormaStudenti formaStudenti = new FormaStudenti();
            formaStudenti.MdiParent = this; //kad se zatvori glavna forma, zatvaraju se i forme dece da znas...
            formaStudenti.Show();
        }

        private void smeroviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //prikazati formu smerovi
            //11
            FormaSmerovi formaSmerovi = new FormaSmerovi();
            formaSmerovi.MdiParent = this;
            formaSmerovi.Show();
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rezultat = MessageBox.Show("Da li zelite da izadjete iz programa?", "Izlaz", MessageBoxButtons.YesNo);  //5of21 overrload
            if (rezultat ==DialogResult.Yes)
            {
                //Application.Exit;   ili
                System.Environment.Exit(0);
                //ako je cancel, nece se nista desiti, korisnik ostaje u programu...
            }
        }
    }
}
