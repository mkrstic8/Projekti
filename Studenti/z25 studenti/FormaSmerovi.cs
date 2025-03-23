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
{
    public partial class FormaSmerovi : Form
    {
        public FormaSmerovi()
        {
            InitializeComponent();
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            
            KlasaSmerovi.SmeroviList.Clear();  //nema instanciranja jer je static property
            for (int i =0; i<dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[0].Value !=null) //ovo je samo za sifru pokazano, treba za sve sto se koristi inace
                {
                    KlasaSmer noviSmer = new KlasaSmer(); //mora unutar if petlje...
                    noviSmer.Sifra = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);   //iz object to int, moze i Convert.ToInt32
                    noviSmer.Naziv = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    noviSmer.Tip = dataGridView1.Rows[i].Cells[2].Value.ToString();
                    KlasaSmerovi.SmeroviList.Add(noviSmer);
                    
                }



            }
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            //moze i for
            foreach (KlasaSmer smer in KlasaSmerovi.SmeroviList)
            {
                DataGridViewRow red = (DataGridViewRow)dataGridView1.Rows[0].Clone(); //i kad stavis 0 kloniraju se svi redovi...
                red.Cells[0].Value = smer.Sifra;
                red.Cells[1].Value = smer.Naziv;
                red.Cells[2].Value = smer.Tip;
                dataGridView1.Rows.Add(red);


            }
        }
    }
}
