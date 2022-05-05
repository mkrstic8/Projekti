using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z25_studenti
{//3
    public enum VrstaStudija {budzet, samofinansiranje}; //ako si cekirao radio buton budzet, u StatusStudija ubaci budzet itd...
    class KlasaStudent
    {
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
        private string brojIndeksa;

        public string BrojIndeksa
        {
            get { return brojIndeksa; }
            set { brojIndeksa = value; }
        }

        private string jmbg;

        public string JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        private int godinaStudija;

        public int GodinaStudija
        {
            get { return godinaStudija; }
            set { godinaStudija = value; }
        }
        private string smer;

        public string Smer
        {
            get { return smer; }
            set { smer = value; }
        }

        //status studija uz pomoc enuma se zadaje

        private string statusStudija;

        public string StatusStudija
        {
            get { return statusStudija; }
            set { statusStudija = value; }
        }

        //boleean

        private bool praksa;

        public bool Praksa
        {
            get { return praksa; }
            set { praksa = value; }
        }

        private bool dnevnikPrakse;

        public bool DnevnikPrakse
        {
            get { return dnevnikPrakse; }
            set { dnevnikPrakse = value; }
        }

        //ime slike i putanja do slike...
        //c:\...

        private string slikaPath;

        public string SlikaPath   
        {
            get { return slikaPath; }
            set { slikaPath = value; }
        }

        //overajdovanje

        public override string ToString()
        {
            //return base.ToString();
            return String.Format("Br.ind:{0}, ime:{1}, prezime:{2}, jmbg{3}", brojIndeksa, ime, prezime, jmbg);
        }

        //enum je dat iznad klase

    }
}
