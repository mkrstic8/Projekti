using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z25_studenti
{//4
    //isto je ima static...
    static class KlasaStudenti
    {
        private static List<KlasaStudent> studentiList = new List<KlasaStudent>();

        public static List<KlasaStudent> StudentiList
        {
            get { return studentiList; }
            set { studentiList = value; }
        }

        //lista se pretvara nakon unosa u jason fajl...zamena za bazu






    }
}
