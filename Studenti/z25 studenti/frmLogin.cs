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
{//5 a pre toga ide frmLogin.cs[Design] //6 je program.cs izmene
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            btnOK.Enabled = false;  //dodatno
        }

        private void tbSifra_Validating(object sender, CancelEventArgs e)
        {
            if (tbSifra.Text!="Bata")
            {
                errorProvider1.SetError(tbSifra, "Neispravna sifra, probajte ponovo");
                tbSifra.Text = String.Empty; //pazi na String.Empty da upamtis, moze i tbLozinka.Clear umesto toga
                tbSifra.Focus();
                errorProvider1.Clear();

            }
           
        }

        private void tbLozinka_Validating(object sender, CancelEventArgs e)
        {
            if (tbLozinka.Text != "bata")
            {
                errorProvider2.SetError(tbLozinka, "Neispravna lozinka, probajte ponovo");
                tbLozinka.Text = String.Empty; 
                tbLozinka.Focus();
                errorProvider2.Clear();

            }
        }

        private void tbLozinka_Validated(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
            btnOK.Focus();  
            //dozvoljava se da se klikne na Ok
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //treba prvo hajdovati formu
            frmLogin.ActiveForm.Hide();     //pazi da smo preimenovali text u Login ali ostaje frmLogin
            //ovde stajemo dok ne napravimo roditeljsku tj. kontejnersku formu...
            //promeni u program.cs umesto Form1 u frmLogin i obrisati Form1


            //7

            StudentiGlavna studentiGlavna = new StudentiGlavna();  //instancira se forma da bi se koristila ovde u drugoj...
            studentiGlavna.Show(); //mora da bi se pojavila forma ili Show ili ShowDialog, ne znam sta je ShowDialog
            //isMdiContainer properti se stavlja true za StudentiGlavna, znaci da je roditelj
        }
    }
}
