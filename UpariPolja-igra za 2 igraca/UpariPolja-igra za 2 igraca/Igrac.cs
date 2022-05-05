using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpariPolja_igra_za_2_igraca
{
    public class Igrac
    {

        
        private int brojPoena;

        public int BrojPoena
        {
            get { return brojPoena; }
            set { brojPoena = value; }
        }
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private bool naRedu;

        public bool NaRedu
        {
            get { return naRedu; }
            set { naRedu = value; }
        }

        

    }
}
