using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpariPolja_igra_za_2_igraca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            Stop();
            labelskor.Text = String.Empty;
            
        }
        
        public string IzbaciPobednika(Igrac bilokoji)
        {
            return string.Format("Победио је играч {0} са {1} поена", bilokoji.Ime, bilokoji.BrojPoena);
        }           //
        public string statusreport(Igrac bilokoji)
        {
            return "Играч " + bilokoji.Ime.ToString() + " има " + bilokoji.BrojPoena.ToString() + " поена ";

        }              //
        //int drugistart=0;
        int zezalica=0;
        string status = String.Empty;
        int i = 0;
        int k = 2; 
        Control[] Ctrl = new Control[2];
        string p = String.Empty;
        Random pomocni = new Random();
        int[] niz = new int[36];     //////prepravi na 36
        string[] niz2 = new string[2];
        Dictionary<int, string> recnik = new Dictionary<int, string>
        {
            {1,"Београд"},
            {2,"Србија"},
            {3,"Софија"},
            {4,"Бугарска"},
            {5,"Скопје"},
            {6,"Македонија"},
            {7,"Тирана"},
            {8,"Албанија"},
            {9,"Вашингтон"},
            {10,"САД"},
            {11,"Токио"},
            {12,"Јапан"},
            {13,"Москва"},
            {14,"Русија"},
            {15,"Кијев"},
            {16,"Украјина"},
            {17,"Пекинг"},
            {18,"Кина"},
            {19,"Анкара"},
            {20,"Турска"},
            {21,"Атина"},
            {22,"Грчкa"},
            {23,"Каиро"},
            {24,"Египат"},
            {25,"Праг"},
            {26,"Чешка"},
            {27,"Братислава"},
            {28,"Словачка"},
            {29,"Берлин"},
            {30,"Немачка"},
            {31,"Брисел"},
            {32,"Белгија"},
            {33,"Букурешт"},
            {34,"Румунија"},
            {35,"Будимпешта"},
            {36,"Мађарска"}

        };
        Dictionary<int, string> recnik2 = new Dictionary<int, string>
        {
            {1,"БеоградСрбија"},
            {2,"СрбијаБеоград"},
            {3,"СофијаБугарска"},
            {4,"БугарскаСофија"},
            {5,"СкопјеМакедонија"},
            {6,"МакедонијаСкопје"},
            {7,"ТиранаАлбанија"},
            {8,"АлбанијаТирана"},
            {9,"ВашингтонСАД"},
            {10,"САДВашингтон"},
            {11,"ТокиоЈапан"},
            {12,"ЈапанТокио"},
            {13,"МоскваРусија"},
            {14,"РусијаМосква"},
            {15,"КијевУкрајина"},
            {16,"УкрајинаКијев"},
            {17,"ПекингКина"},
            {18,"КинаПекинг"},
            {19,"АнкараТурска"},
            {20,"ТурскаАнкара"},
            {21,"АтинаГрчкa"},
            {22,"ГрчкaАтина"},
            {23,"КаироЕгипат"},
            {24,"ЕгипатКаиро"},
            {25,"ПрагЧешка"},
            {26,"ЧешкаПраг"},
            {27,"БратиславаСловачка"},
            {28,"СловачкаБратислава"},
            {29,"БерлинНемачка"},
            {30,"НемачкаБерлин"},
            {31,"БриселБелгија"},
            {32,"БелгијаБрисел"},
            {33,"БукурештРумунија"},
            {34,"РумунијаБукурешт"},
            {35,"БудимпештаМађарска"},
            {36,"МађарскаБудимпешта"}


        };
        

        public void Stop()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            button14.Enabled = false;
            button15.Enabled = false;
            button16.Enabled = false;
            button17.Enabled = false;
            button18.Enabled = false;
            button19.Enabled = false;
            button20.Enabled = false;
            button21.Enabled = false;
            button22.Enabled = false;
            button23.Enabled = false;
            button24.Enabled = false;
            button25.Enabled = false;
            button26.Enabled = false;
            button27.Enabled = false;
            button28.Enabled = false;
            button29.Enabled = false;
            button30.Enabled = false;
            button31.Enabled = false;
            button32.Enabled = false;
            button33.Enabled = false;
            button34.Enabled = false;
            button35.Enabled = false;
            button36.Enabled = false;

        }                      
        public void Continue()
        {

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
            button17.Enabled = true;
            button18.Enabled = true;
            button19.Enabled = true;
            button20.Enabled = true;
            button21.Enabled = true;
            button22.Enabled = true;
            button23.Enabled = true;
            button24.Enabled = true;
            button25.Enabled = true;
            button26.Enabled = true;
            button27.Enabled = true;
            button28.Enabled = true;
            button29.Enabled = true;
            button30.Enabled = true;
            button31.Enabled = true;
            button32.Enabled = true;
            button33.Enabled = true;
            button34.Enabled = true;
            button35.Enabled = true;
            button36.Enabled = true;
        }                   

        public void Add(RichTextBox box)
        {

            Ctrl[i] = box;
            p += box.Text.ToString();
            i++;
            if (i == 2 && zezalica%2==0)
            {

                Check1(ref zezalica);


            }
            if(i == 2 && zezalica % 2 != 0)
            {

                Check2(ref zezalica);
            }
            

        }   //
        public void Check1(ref int zez)
        {
            labelred.Text = "На реду је играч " + ListaIgraca.NovalistaIgraca[1].Ime.ToString();

            if (zez%2==0)
            {
                if (recnik2.ContainsValue(p))
                {
                    labelred.Text = "На реду је играч " + ListaIgraca.NovalistaIgraca[0].Ime.ToString();
                    ListaIgraca.NovalistaIgraca[0].BrojPoena += 10;
                    labelskor.Text = statusreport(ListaIgraca.NovalistaIgraca[0]) + statusreport(ListaIgraca.NovalistaIgraca[1]);
                    
                    Ctrl[0].Visible = true;
                    Ctrl[1].Visible = true;
                    p = String.Empty;
                    i = 0;
                    k += 2;
                    
                    
                }
                else
                {
                    
                    Ctrl[0].Visible = false;
                    Ctrl[1].Visible = false;
                    p = String.Empty;
                    i = 0;
                    ++zez;
                    
                }


            }
           

        }     //
        private void Check2(ref int zez)
        {
            labelred.Text = "На реду је играч " + ListaIgraca.NovalistaIgraca[0].Ime.ToString();
            if (zez%2==1)
            {
                if (recnik2.ContainsValue(p))
                {
                    labelred.Text = "На реду је играч " + ListaIgraca.NovalistaIgraca[1].Ime.ToString();
                    ListaIgraca.NovalistaIgraca[1].BrojPoena += 10;
                    labelskor.Text = statusreport(ListaIgraca.NovalistaIgraca[0]) + statusreport(ListaIgraca.NovalistaIgraca[1]);
                    Ctrl[0].Visible = true;
                    Ctrl[1].Visible = true;
                    p = String.Empty;
                    i = 0;
                    k += 2;
                    
                    
                }
                else
                {
                    
                    Ctrl[0].Visible = false;
                    Ctrl[1].Visible = false;
                    p = String.Empty;
                    i = 0;
                    ++zez;
                   
                }

            }
            


        }    //
         

        public void Win() 
        {
            


            if (k == 38)     
            {
                if (ListaIgraca.NovalistaIgraca[0].BrojPoena> ListaIgraca.NovalistaIgraca[1].BrojPoena)
                    MessageBox.Show("Игра је завршена, победио је "+ ListaIgraca.NovalistaIgraca[0].Ime + " са " + ListaIgraca.NovalistaIgraca[0].BrojPoena.ToString() + " поена ");
                else
                    MessageBox.Show("Игра је завршена, победио је " + ListaIgraca.NovalistaIgraca[1].Ime + " са " + ListaIgraca.NovalistaIgraca[1].BrojPoena.ToString() + " поена ");

                k = 2;
                Application.Restart();
            }
        }                  ///////prepravi k na 36+2

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
        async Task UseDelay()
        {
            await Task.Delay(1000);
        }


        private void buttonnovaigra_Click(object sender, EventArgs e)
        {
            if (richIme1.Text == String.Empty || richIme2.Text == String.Empty)
            {
                
                MessageBox.Show("Унесите имена играча");
                return;
                
            }
            else

            {
                Igrac prvi = new Igrac();
                Igrac drugi = new Igrac();
                prvi.Ime = richIme1.Text;
                prvi.BrojPoena = 0;
                drugi.Ime = richIme2.Text;
                drugi.BrojPoena = 0;
                labelskor.Text = statusreport(prvi) + statusreport(drugi);
                
                
                ListaIgraca.NovalistaIgraca.Add(prvi);
                ListaIgraca.NovalistaIgraca.Add(drugi);
                labelred.Visible = true;
                labelred.Text = "На реду је играч " + ListaIgraca.NovalistaIgraca[0].Ime.ToString();
                richIme1.Clear();
                richIme1.Enabled = false;
                richIme2.Clear();
                richIme2.Enabled = false;
                buttonnovaigra.Enabled = false;
                buttonprekini.Enabled = true;
                


                for (int i = 0; i < 36; i++)
                {
                    int x = pomocni.Next(1, 37);
                    while (Duplikat(x, niz))
                    {
                        x = pomocni.Next(1, 37);
                    }
                    niz[i] = x;
                }

                richTextBox1.Text = recnik[niz[0]].ToString();
                richTextBox2.Text = recnik[niz[1]].ToString();
                richTextBox3.Text = recnik[niz[2]].ToString();
                richTextBox4.Text = recnik[niz[3]].ToString();
                richTextBox5.Text = recnik[niz[4]].ToString();
                richTextBox6.Text = recnik[niz[5]].ToString();
                richTextBox7.Text = recnik[niz[6]].ToString();
                richTextBox8.Text = recnik[niz[7]].ToString();
                richTextBox9.Text = recnik[niz[8]].ToString();
                richTextBox10.Text = recnik[niz[9]].ToString();
                richTextBox11.Text = recnik[niz[10]].ToString();
                richTextBox12.Text = recnik[niz[11]].ToString();
                richTextBox13.Text = recnik[niz[12]].ToString();
                richTextBox14.Text = recnik[niz[13]].ToString();
                richTextBox15.Text = recnik[niz[14]].ToString();
                richTextBox16.Text = recnik[niz[15]].ToString();
                richTextBox17.Text = recnik[niz[16]].ToString();
                richTextBox18.Text = recnik[niz[17]].ToString();
                richTextBox19.Text = recnik[niz[18]].ToString();
                richTextBox20.Text = recnik[niz[19]].ToString();
                richTextBox21.Text = recnik[niz[20]].ToString();
                richTextBox22.Text = recnik[niz[21]].ToString();
                richTextBox23.Text = recnik[niz[22]].ToString();
                richTextBox24.Text = recnik[niz[23]].ToString();
                richTextBox25.Text = recnik[niz[24]].ToString();
                richTextBox26.Text = recnik[niz[25]].ToString();
                richTextBox27.Text = recnik[niz[26]].ToString();
                richTextBox28.Text = recnik[niz[27]].ToString();
                richTextBox29.Text = recnik[niz[28]].ToString();
                richTextBox30.Text = recnik[niz[29]].ToString();
                richTextBox31.Text = recnik[niz[30]].ToString();
                richTextBox32.Text = recnik[niz[31]].ToString();
                richTextBox33.Text = recnik[niz[32]].ToString();
                richTextBox34.Text = recnik[niz[33]].ToString();
                richTextBox35.Text = recnik[niz[34]].ToString();
                richTextBox36.Text = recnik[niz[35]].ToString();
                Continue();
            }
        }       ///////prepravi for u sredinu i na kraju punjenje
                                                                                ///////duplikat se ovde koristi


        async void button1_Click(object sender, EventArgs e)
        {
            
            richTextBox1.Visible = true;
            await Task.Delay(500);
            Add(richTextBox1);
            Win();

        }

        async void button2_Click(object sender, EventArgs e)
        {
           
            richTextBox2.Visible = true;
            await Task.Delay(500);
            Add(richTextBox2);
            Win();

        }

        async void button3_Click(object sender, EventArgs e)
        {
            
            richTextBox3.Visible = true;
            await Task.Delay(500);
            Add(richTextBox3);
            Win();

        }

        async void button4_Click(object sender, EventArgs e)
        {
            
            richTextBox4.Visible = true;
            await Task.Delay(500);
            Add(richTextBox4);
            Win();

        }

        async void button5_Click(object sender, EventArgs e)
        {
            
            richTextBox5.Visible = true;
            await Task.Delay(500);
            Add(richTextBox5);
            Win();

        }

        async void button6_Click_1(object sender, EventArgs e)
        {
            
            richTextBox6.Visible = true;
            await Task.Delay(500);
            Add(richTextBox6);
            Win();


        }

        async void button7_Click(object sender, EventArgs e)
        {
            richTextBox7.Visible = true;
            await Task.Delay(500);
            Add(richTextBox7);
            Win();
        }

        async void button8_Click(object sender, EventArgs e)
        {
            richTextBox8.Visible = true;
            await Task.Delay(500);
            Add(richTextBox8);
            Win();
        }

        async void button9_Click(object sender, EventArgs e)
        {
            richTextBox9.Visible = true;
            await Task.Delay(500);
            Add(richTextBox9);
            Win();
        }

        async void button10_Click(object sender, EventArgs e)
        {
            richTextBox10.Visible = true;
            await Task.Delay(500);
            Add(richTextBox10);
            Win();
        }

        async void button11_Click(object sender, EventArgs e)
        {
            richTextBox11.Visible = true;
            await Task.Delay(500);
            Add(richTextBox11);
            Win();
        }

        async void button12_Click(object sender, EventArgs e)
        {
            richTextBox12.Visible = true;
            await Task.Delay(500);
            Add(richTextBox12);
            Win();
        }

        async void button13_Click(object sender, EventArgs e)
        {
            richTextBox13.Visible = true;
            await Task.Delay(500);
            Add(richTextBox13);
            Win();
        }

        async void button14_Click(object sender, EventArgs e)
        {
            richTextBox14.Visible = true;
            await Task.Delay(500);
            Add(richTextBox14);
            Win();
        }

        async void button15_Click(object sender, EventArgs e)
        {
            richTextBox15.Visible = true;
            await Task.Delay(500);
            Add(richTextBox15);
            Win();
        }

        async void button16_Click(object sender, EventArgs e)
        {
            richTextBox16.Visible = true;
            await Task.Delay(500);
            Add(richTextBox16);
            Win();
        }

        async void button17_Click(object sender, EventArgs e)
        {
            richTextBox17.Visible = true;
            await Task.Delay(500);
            Add(richTextBox17);
            Win();
        }

        async void button18_Click(object sender, EventArgs e)
        {
            richTextBox18.Visible = true;
            await Task.Delay(500);
            Add(richTextBox18);
            Win();
        }

        async void button19_Click(object sender, EventArgs e)
        {
            richTextBox19.Visible = true;
            await Task.Delay(500);
            Add(richTextBox19);
            Win();
        }

        async void button20_Click(object sender, EventArgs e)
        {
            richTextBox20.Visible = true;
            await Task.Delay(500);
            Add(richTextBox20);
            Win();
        }

        async void button21_Click(object sender, EventArgs e)
        {
            richTextBox21.Visible = true;
            await Task.Delay(500);
            Add(richTextBox21);
            Win();
        }

        async void button22_Click(object sender, EventArgs e)
        {
            richTextBox22.Visible = true;
            await Task.Delay(500);
            Add(richTextBox22);
            Win();
        }

        async void button23_Click(object sender, EventArgs e)
        {
            richTextBox23.Visible = true;
            await Task.Delay(500);
            Add(richTextBox23);
            Win();
        }

        async void button24_Click(object sender, EventArgs e)
        {
            richTextBox24.Visible = true;
            await Task.Delay(500);
            Add(richTextBox24);
            Win();
        }

        async void button25_Click(object sender, EventArgs e)
        {
            richTextBox25.Visible = true;
            await Task.Delay(500);
            Add(richTextBox25);
            Win();
        }

        async void button26_Click(object sender, EventArgs e)
        {
            richTextBox26.Visible = true;
            await Task.Delay(500);
            Add(richTextBox26);
            Win();
        }

        async void button27_Click(object sender, EventArgs e)
        {
            richTextBox27.Visible = true;
            await Task.Delay(500);
            Add(richTextBox27);
            Win();
        }

        async void button28_Click(object sender, EventArgs e)
        {
            richTextBox28.Visible = true;
            await Task.Delay(500);
            Add(richTextBox28);
            Win();
        }

        async void button29_Click(object sender, EventArgs e)
        {
            richTextBox29.Visible = true;
            await Task.Delay(500);
            Add(richTextBox29);
            Win();
        }

        async void button30_Click(object sender, EventArgs e)
        {
            richTextBox30.Visible = true;
            await Task.Delay(500);
            Add(richTextBox30);
            Win();
        }

        async void button31_Click(object sender, EventArgs e)
        {
            richTextBox31.Visible = true;
            await Task.Delay(500);
            Add(richTextBox31);
            Win();
        }

        async void button32_Click(object sender, EventArgs e)
        {
            richTextBox32.Visible = true;
            await Task.Delay(500);
            Add(richTextBox32);
            Win();
        }

        async void button33_Click(object sender, EventArgs e)
        {
            richTextBox33.Visible = true;
            await Task.Delay(500);
            Add(richTextBox33);
            Win();
        }

        async void button34_Click(object sender, EventArgs e)
        {
            richTextBox34.Visible = true;
            await Task.Delay(500);
            Add(richTextBox34);
            Win();
        }

        async void button35_Click(object sender, EventArgs e)
        {
            richTextBox35.Visible = true;
            await Task.Delay(500);
            Add(richTextBox35);
            Win();
        }

        async void button36_Click(object sender, EventArgs e)
        {
            richTextBox36.Visible = true;
            await Task.Delay(500);
            Add(richTextBox36);
            Win();
        }

        private void buttonprekini_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
