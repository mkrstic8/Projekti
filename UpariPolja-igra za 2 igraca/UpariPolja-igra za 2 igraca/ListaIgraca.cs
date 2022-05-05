using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpariPolja_igra_za_2_igraca
{
    static class ListaIgraca
    {


        private static List<Igrac> novalistaIgraca = new List<Igrac>();

        public static List<Igrac> NovalistaIgraca
        {
            get { return novalistaIgraca; }
            set { novalistaIgraca = value; }
        }
    }
        
}
