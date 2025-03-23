using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace z25_studenti
{
    public partial class FormaStudenti : Form
    {
        string pathSlikeStudenta = String.Empty; //globalna za sliku
        public FormaStudenti()
        {
            InitializeComponent();
            foreach (KlasaSmer smerovi in KlasaSmerovi.SmeroviList)
            {

                cbSmer.Items.Add(smerovi.Naziv);
            }
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            KlasaStudent noviStudent = new KlasaStudent();
            NapuniStudenta(noviStudent);
            KlasaStudenti.StudentiList.Add(noviStudent);
            listBox1.Items.Add(noviStudent.ToString());  //ToString moze sto smo stavili override sto smo imali override kod KlasaStudent

        }
        private void NapuniStudenta(KlasaStudent noviStudent)
        {
            noviStudent.BrojIndeksa = tbBrojIndeksa.Text;
            noviStudent.JMBG = tbJMBG.Text;
            noviStudent.Ime = tbIme.Text;
            noviStudent.Prezime = tbPrezime.Text;
            noviStudent.Smer = cbSmer.SelectedItem.ToString();
            noviStudent.GodinaStudija = int.Parse(cbGodina.SelectedItem.ToString());
            if (rbBudzet.Checked)
                noviStudent.StatusStudija = VrstaStudija.budzet.ToString();
            if (rbSamofinansiranje.Checked)
                noviStudent.StatusStudija = VrstaStudija.samofinansiranje.ToString();
            if (chkPraksa.Checked)
            {
                noviStudent.Praksa = true;

            }
            else
            {
                noviStudent.Praksa = false;

            }
            if (chkDnevnik.Checked)
            {
                noviStudent.DnevnikPrakse = true;

            }
            else
            {
                noviStudent.DnevnikPrakse = false;

            }
            //fali slika
            noviStudent.SlikaPath = pathSlikeStudenta;



        }

        private void picSlikaStudenta_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Izaberite sliku studenta";
            openfile.Filter = "jpg|*.jpg|png|*.png";
            if (openfile.ShowDialog()==DialogResult.OK)
            {
                Image slika = Image.FromFile(openfile.FileName);
                picSlikaStudenta.Image = slika;
                pathSlikeStudenta = openfile.FileName;  //pathSlikeStudenta je globalna promenljiva


            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                //delete
                int selected = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(selected);
                KlasaStudenti.StudentiList.RemoveAt(selected);
            }
            if (e.KeyCode == Keys.H)
            {
                //edit
                int selected = listBox1.SelectedIndex;
                
                KlasaStudent studentZaEditovanje = KlasaStudenti.StudentiList.ElementAt(selected);
                NapuniPolja(studentZaEditovanje);

            }
            

        }
        private void NapuniPolja(KlasaStudent studentZaEditovanje)
        {
            tbIme.Text = studentZaEditovanje.Ime;
            tbPrezime.Text= studentZaEditovanje.Prezime;
            tbJMBG.Text = studentZaEditovanje.JMBG;
            tbBrojIndeksa.Text = studentZaEditovanje.BrojIndeksa;
            cbGodina.SelectedItem = studentZaEditovanje.GodinaStudija.ToString();
            cbGodina.Text = studentZaEditovanje.GodinaStudija.ToString();

            cbSmer.SelectedItem = studentZaEditovanje.Smer.ToString();
            cbSmer.Text = studentZaEditovanje.Smer.ToString();

            if (studentZaEditovanje.StatusStudija.Equals(VrstaStudija.budzet.ToString()))
                rbBudzet.Checked = true;
            else
                rbBudzet.Checked = false;
            if (studentZaEditovanje.StatusStudija.Equals(VrstaStudija.samofinansiranje.ToString()))
                rbSamofinansiranje.Checked = true;
            else
                rbSamofinansiranje.Checked = false;

            if (studentZaEditovanje.Praksa)

                chkPraksa.Checked = true;
            else
                chkPraksa.Checked = false;
            if (studentZaEditovanje.DnevnikPrakse)
                chkDnevnik.Checked = true;
            else
                chkDnevnik.Checked = false;


            if (File.Exists(studentZaEditovanje.SlikaPath))  //using system io
            {
                Image slika = Image.FromFile(studentZaEditovanje.SlikaPath);
                picSlikaStudenta.Image = slika;
                pathSlikeStudenta = studentZaEditovanje.SlikaPath;


            }
            else
            {
                picSlikaStudenta.Image = null;
                pathSlikeStudenta = String.Empty;

            }



            }

        private void btnOcisti_Click(object sender, EventArgs e)
        {
            tbBrojIndeksa.Clear();
            tbJMBG.Clear();
            tbIme.Clear();
            tbPrezime.Clear();

            cbSmer.SelectedIndex = -1;
            cbGodina.SelectedIndex = -1;
            rbBudzet.Checked = false;
            rbSamofinansiranje.Checked = false;

            chkPraksa.Checked = false;
            chkDnevnik.Checked = false;
            
            picSlikaStudenta.Image = null;
        }
    }
    
}
