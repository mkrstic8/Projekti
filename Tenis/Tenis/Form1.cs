using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tenis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int[] niz = new int[8];
        Random rand = new Random();
        Dictionary<int, string> recnik = new Dictionary<int, string>
        {
            {1,"Novak Djoković"},
            {2,"Danil Medvedev"},
            {3,"Aleksandar Zverev"},
            {4,"Rafael Nadal"},
            {5,"Stefanos Cicipas"},
            {6,"Karlos Alkaraz"},
            {7,"Andrej Rubljov"},
            {8,"Mateo Beretini"}

        };
        int[] poeni = new int[9] { 0, 8260, 7990, 7020, 6435, 5750, 4773, 4115, 3895 };



       public void Stani()
        {
            Application.DoEvents();
            Thread.Sleep(800);
            

        }

        public double Verovatnoca(Igrac igracx, Igrac igracy)
        {
            if (igracx.Vrv > igracy.Vrv)
                return (double)igracy.Vrv / (igracx.Vrv + igracy.Vrv);
            else
                return (double)igracx.Vrv / (igracx.Vrv + igracy.Vrv);
        }


        public int Uvecaj(Igrac igracprvi, Igrac igracdrugi,Label labelx,Label labely)
        {

            double j = Verovatnoca(igracprvi, igracdrugi);
            int k = 3;
            while (k == 3)
            {
                labelx.Text = igracprvi.Set.ToString() + igracprvi.Ime + igracprvi.Gem.ToString();
                labely.Text = igracdrugi.Gem.ToString() + igracdrugi.Ime + igracdrugi.Set.ToString();
                Stani();
                double test = rand.NextDouble();
                if(test >= j)
                {
                    igracprvi.Gem += 1;
                    if (igracprvi.Gem >= 6 && igracprvi.Gem >= (igracdrugi.Gem + 2))
                        {
                        Stani();
                        labelx.Text = igracprvi.Set.ToString() + igracprvi.Ime + igracprvi.Gem.ToString();
                        labely.Text = igracdrugi.Gem.ToString() + igracdrugi.Ime + igracdrugi.Set.ToString();
                        Stani();
                        igracprvi.Set += 1;
                        igracprvi.Gem = 0;
                        igracdrugi.Gem = 0;
                        labelx.Text = igracprvi.Set.ToString() + igracprvi.Ime + igracprvi.Gem.ToString();
                        labely.Text = igracdrugi.Gem.ToString() + igracdrugi.Ime + igracdrugi.Set.ToString();
                        Stani();

                    }
                    if (igracprvi.Set == 2)
                    {
                        k = 1;
                        break;
                    }

                }
                if (test < j)
                {

                    igracdrugi.Gem += 1;

                    if (igracdrugi.Gem >= 6 && igracdrugi.Gem >= (igracprvi.Gem + 2))
                        {
                        Stani();
                        labelx.Text = igracprvi.Set.ToString() + igracprvi.Ime + igracprvi.Gem.ToString();
                        labely.Text = igracdrugi.Gem.ToString() + igracdrugi.Ime + igracdrugi.Set.ToString();
                        Stani();
                        igracdrugi.Set += 1;
                        igracprvi.Gem = 0;
                        igracdrugi.Gem = 0;
                        labelx.Text = igracprvi.Set.ToString() + igracprvi.Ime + igracprvi.Gem.ToString();
                        labely.Text = igracdrugi.Gem.ToString() + igracdrugi.Ime + igracdrugi.Set.ToString();
                        Stani();

                    }
                    if (igracdrugi.Set == 2)
                    {
                        k = 2;
                        break;
                    }

                }

                Stani();
            }
            
            return k;
        }
        private static bool Duplikat(int privremen, int[] niz)
        {

            foreach (var item in niz)
            {
                if (item == privremen)
                {

                    return true;
                }

            }
            return false;

        }


        public void button1_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 6; i++)
            {
                int x = rand.Next(3, 9);
                while (Duplikat(x, niz))
                {
                    x = rand.Next(3, 9);
                }
                niz[i] = x;
            }
            
            Igrac igrac1 = new Igrac();
            igrac1.Gem = 0;
            igrac1.Set = 0;
            igrac1.Ime = recnik[1].ToString();
            igrac1.Vrv = poeni[1];
            Igrac igrac2 = new Igrac();
            igrac2.Gem = 0;
            igrac2.Set = 0;
            igrac2.Ime = recnik[niz[0]].ToString();
            igrac2.Vrv = poeni[niz[0]];
            Igrac igrac3 = new Igrac();
            igrac3.Gem = 0;
            igrac3.Set = 0;
            igrac3.Ime = recnik[niz[1]].ToString();
            igrac3.Vrv = poeni[niz[1]];
            Igrac igrac4 = new Igrac();
            igrac4.Gem = 0;
            igrac4.Set = 0;
            igrac4.Ime = recnik[niz[2]].ToString();
            igrac4.Vrv = poeni[niz[2]];
            Igrac igrac5 = new Igrac();
            Igrac igrac6 = new Igrac();
            igrac5.Gem = 0;
            igrac5.Set = 0;
            igrac5.Ime = recnik[2].ToString();
            igrac5.Vrv = poeni[2];
            igrac6.Gem = 0;
            igrac6.Set = 0;
            igrac6.Ime = recnik[niz[3]].ToString();
            igrac6.Vrv = poeni[niz[3]];
            Igrac igrac7 = new Igrac();
            Igrac igrac8 = new Igrac();
            igrac7.Ime = recnik[niz[4]].ToString();
            igrac7.Vrv = poeni[niz[4]];
            igrac7.Gem = 0;
            igrac7.Set = 0;
            igrac8.Ime = recnik[niz[5]].ToString();
            igrac8.Vrv = poeni[niz[5]];
            igrac8.Gem = 0;
            igrac8.Set = 0;
            Igrac igrac9 = new Igrac();
            Igrac igrac10 = new Igrac();
            igrac9.Gem = 0;
            igrac9.Set = 0;
            igrac10.Gem = 0;
            igrac10.Set = 0;
            Igrac igrac11 = new Igrac();
            Igrac igrac12 = new Igrac();
            igrac11.Gem = 0;
            igrac11.Set = 0;
            igrac12.Gem = 0;
            igrac12.Set = 0;
            Igrac igrac13 = new Igrac();
            Igrac igrac14 = new Igrac();
            igrac13.Gem = 0;
            igrac13.Set = 0;
            igrac14.Gem = 0;
            igrac14.Set = 0;
            label1.Text =  igrac1.Ime ;
            label2.Text = igrac2.Ime  ;
            label3.Text =  igrac3.Ime ;
            label4.Text =  igrac4.Ime;
            label5.Text =  igrac5.Ime ;
            label6.Text =  igrac6.Ime;
            label7.Text =  igrac7.Ime ;
            label8.Text =  igrac8.Ime ;

            if (Uvecaj(igrac1, igrac2, label1, label2) == 1)
            {

                label12.Text =  igrac1.Ime ;
                igrac9 = igrac1;
            }
            else
            {
                label12.Text = igrac2.Ime ;
                igrac9 = igrac2;
            }
            if (Uvecaj(igrac3, igrac4, label3, label4) == 1)
            {
                label34.Text =  igrac3.Ime ;
                igrac10 = igrac3;
            }
            else
            {
                label34.Text =  igrac4.Ime ;
                igrac10 = igrac4;
            }

            if (Uvecaj(igrac5, igrac6, label5, label6) == 1)
            {

                label56.Text =  igrac5.Ime ;
                igrac11 = igrac5;
            }
            else
            {
                label56.Text = igrac6.Ime ;
                igrac11 = igrac6;
            }
            if (Uvecaj(igrac7, igrac8, label7, label8) == 1)
            {
                label78.Text =  igrac7.Ime ;
                igrac12 = igrac7;
            }
            else
            {
                label78.Text =  igrac8.Ime;
                igrac12 = igrac8;
            }

            //2 deo

            igrac9.Gem = 0;
            igrac10.Gem = 0;
            igrac9.Set = 0;
            igrac10.Set = 0;

            if (Uvecaj(igrac9, igrac10, label12, label34) == 1)
            {

                label1234.Text =  igrac9.Ime  ;
                igrac13 = igrac9;
            }
            else
            {
                label1234.Text = igrac10.Ime ;
                igrac13 = igrac10;
            }
            igrac11.Gem = 0;
            igrac11.Set = 0;
            igrac12.Gem = 0;
            igrac12.Set = 0;

            if (Uvecaj(igrac11, igrac12, label56, label78) == 1)
            {

                label5678.Text = igrac11.Ime ;
                igrac14 = igrac11;
            }
            else
            {
                label5678.Text =  igrac12.Ime ;
                igrac14 = igrac12;
            }

            //winer deo
            igrac13.Gem = 0;
            igrac14.Gem = 0;
            igrac13.Set = 0;
            igrac14.Set = 0;
            if (Uvecaj(igrac13, igrac14, label1234, label5678) == 1)
            {

                labelwiner.Text =   igrac13.Ime;
                
            }
            else
            {
                labelwiner.Text =  igrac14.Ime;
                
            }



        }

       
    }

    
    
    










}
