using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z25_studenti
{
    static class KlasaSmerovi
    {
        private static List<KlasaSmer> smeroviList = new List<KlasaSmer>(); 

        public static List<KlasaSmer> SmeroviList
        {
            get { return smeroviList; }
            set { smeroviList = value; }
        }
       



    }
}
