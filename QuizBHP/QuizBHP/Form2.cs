using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizBHP
{
    public partial class Form2 : Form
    {
        ListaPytan list;
        private int n = 0;

        bool[] odpowiedzi = new bool[20];
        short[] wybrane = new short[20];
        Pytanie[] pulaPytan = new Pytanie[20];
        short nrPytania;
        public Form2(short tryb)
        {
            InitializeComponent();
            n = 0;
            list = new ListaPytan();
            for (short i = 0; i < 20; i++)
            {
                odpowiedzi[i] = false;
                wybrane[i] = 0;
            }
            /*************Dobor pytan*************/
            nrPytania = 0;
            switch (tryb)
            {
                case 1:
                    list.losujPytanie(88, 121); //2
                    list.losujPytanie(122, 185); //5
                    list.losujPytanie(186, 246); //5
                    list.losujPytanie(247, 300); //5
                    list.losujPytanie(301, 325); //3
                    dodajPytania(2, 88);
                    dodajPytania(5, 122);
                    dodajPytania(5, 186);
                    dodajPytania(5, 247);
                    dodajPytania(3, 301);
                    
                    break;
                case 2:
                    list.losujPytanie(0, 11); //2
                    list.losujPytanie(55, 60); //1
                    list.losujPytanie(62, 87); //2
                    list.losujPytanie(88, 121); //2
                    list.losujPytanie(122, 185); //4
                    list.losujPytanie(186, 246); //4
                    list.losujPytanie(247, 300); //2
                    list.losujPytanie(301, 325); //3
                    dodajPytania(2, 0);
                    dodajPytania(1, 55);
                    dodajPytania(2, 62);
                    dodajPytania(2, 88);
                    dodajPytania(4, 122);
                    dodajPytania(4, 186);
                    dodajPytania(2, 247);
                    dodajPytania(3, 301);
                    break;
                case 3:
                    list.losujPytanie(15, 87); //5
                    list.losujPytanie(88, 121); //2
                    list.losujPytanie(122, 185); //4
                    list.losujPytanie(186, 246); //4
                    list.losujPytanie(247, 300); //2
                    list.losujPytanie(301, 325); //3
                    dodajPytania(5, 15);
                    dodajPytania(2, 88);
                    dodajPytania(4, 122);
                    dodajPytania(4, 186);
                    dodajPytania(2, 247);
                    dodajPytania(3, 301);
                    break;
                case 4:
                    list.losujPytanie(51, 54); //1
                    list.losujPytanie(57, 60); //1
                    list.losujPytanie(88, 121); //2
                    list.losujPytanie(122, 185); //5
                    list.losujPytanie(186, 246); //5
                    list.losujPytanie(247, 300); //2
                    list.losujPytanie(301, 325); //4
                    dodajPytania(1, 51);
                    dodajPytania(1, 57);
                    dodajPytania(2, 88);
                    dodajPytania(5, 122);
                    dodajPytania(5, 186);
                    dodajPytania(2, 247);
                    dodajPytania(4, 301);
                    break;
                case 5:
                    list.losujPytanie(61, 87); //4
                    list.losujPytanie(88, 121); //2
                    list.losujPytanie(122, 185); //5
                    list.losujPytanie(186, 246); //5
                    list.losujPytanie(247, 300); //2
                    list.losujPytanie(301, 325); //2
                    dodajPytania(4, 61);
                    dodajPytania(2, 88);
                    dodajPytania(5, 122);
                    dodajPytania(5, 186);
                    dodajPytania(2, 247);
                    dodajPytania(2, 301);
                    break;
                default:
                    break;

            }



            /**************************/
            pokazPytanie(n);
            button2.Text = "Następne";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();

            n++;
            if (n == 19)
            {
                button2.Text = "Zakończ";
            }
            else
            {
                button2.Text = "Następne";
            }
            if (n == 20) //test zakonczony
            {

                int j = 0;
                for (int i = 0; i < 20; i++)
                {
                    if (odpowiedzi[i] == true)
                        j++;
                   
                }
                MessageBox.Show("Udzielono poprawnej odpowiedzi na " + j + " z " + n + " pytan");
                
                this.Close();
                
            }
            else
            {
                
                pokazPytanie(n);
            }

        }

        private void dodajPytania(short zakres1, int zakres2)
        {
            short i = 0;
            while (i < zakres1)
            {
                pulaPytan[nrPytania] = list.listapytan[i + zakres2];
                nrPytania++; i++;
            }
        }

        private void uwzglednijNulle(int numerpytania)
        {
            int nulle = 0;
            for (int i = 0; i < 4; i++)
            {
                if (pulaPytan[numerpytania].odpowiedzi[i].nazwaOdpowiedzi.Equals(""))
                    nulle++;
            }
            if (nulle == 1)
                radioButton3.Show();
            else if (nulle == 0)
            {
                radioButton3.Show();
                radioButton4.Show();
                return;
            }
            if (nulle > 0)
            {
                Odpowiedzi temp;
                for (int i = 0; i < 4; i++)
                {
                    if (pulaPytan[numerpytania].odpowiedzi[i].nazwaOdpowiedzi.Equals("")) {
                        temp = pulaPytan[numerpytania].odpowiedzi[3];
                        pulaPytan[numerpytania].odpowiedzi[3] = pulaPytan[numerpytania].odpowiedzi[i];
                        pulaPytan[numerpytania].odpowiedzi[i] = temp;
                        break;
                            }
                }
                nulle--;
                radioButton4.Hide();
            }
            if (nulle > 0)
            {
                Odpowiedzi temp;
                for (int i = 0; i < 4; i++)
                {
                    if (pulaPytan[numerpytania].odpowiedzi[i].nazwaOdpowiedzi.Equals(""))
                    {
                        temp = pulaPytan[numerpytania].odpowiedzi[2];
                        pulaPytan[numerpytania].odpowiedzi[2] = pulaPytan[numerpytania].odpowiedzi[i];
                        pulaPytan[numerpytania].odpowiedzi[i] = temp;
                        break;
                    }
                }
                if (pulaPytan[numerpytania].odpowiedzi[0].nazwaOdpowiedzi.Equals("FAŁSZ"))
                {
                    temp = pulaPytan[numerpytania].odpowiedzi[1];
                    pulaPytan[numerpytania].odpowiedzi[1] = pulaPytan[numerpytania].odpowiedzi[0];
                    pulaPytan[numerpytania].odpowiedzi[0] = temp;
                }
                nulle--;
                radioButton3.Hide();
            }
        }
        private void pokazPytanie(int numerpytania)
        {
            uwzglednijNulle(numerpytania);
            label1.Text = (n+1)+ ". " + pulaPytan[numerpytania].nazwaPytania;

            radioButton1.Text = pulaPytan[numerpytania].odpowiedzi[0].nazwaOdpowiedzi;
            radioButton2.Text = pulaPytan[numerpytania].odpowiedzi[1].nazwaOdpowiedzi;
            radioButton3.Text = pulaPytan[numerpytania].odpowiedzi[2].nazwaOdpowiedzi;
            radioButton4.Text = pulaPytan[numerpytania].odpowiedzi[3].nazwaOdpowiedzi;
            switch (wybrane[n])
            {
                case 0:
                    radioButton1.Checked = true;
                    break;
                case 1:
                    radioButton2.Checked = true;
                    break;
                case 2:
                    radioButton3.Checked = true;
                    break;
                case 3:
                    radioButton4.Checked = true;
                    break;
                default:
                    break;
            }
            
        }
        private void sprawdzodpowiedz(string trescodpowiedzi)
        {
            int numerpytania = n;
            for (int i = 0; i <= 5; i++)
            {
                if (pulaPytan[numerpytania].odpowiedzi[i].nazwaOdpowiedzi.Equals(trescodpowiedzi))
                {
                    if (pulaPytan[numerpytania].odpowiedzi[i].czyPrawda)
                    {
                        odpowiedzi[n] = true;
                        break;
                    }
                    else
                    {
                        odpowiedzi[n] = false;
                        break;
                    }
                }
            }
        }
        private void sprawdzRadioButton()
        {
            if (radioButton1.Checked)
            {
                wybrane[n] = 0;
                sprawdzodpowiedz(radioButton1.Text);
            }
            if (radioButton2.Checked)
            {
                wybrane[n] = 1;
                sprawdzodpowiedz(radioButton2.Text);
            }
            if (radioButton3.Checked)
            {
                wybrane[n] = 2;
                sprawdzodpowiedz(radioButton3.Text);
            }
            if (radioButton4.Checked)
            {
                wybrane[n] = 3;
                sprawdzodpowiedz(radioButton4.Text);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 0;
            pokazPytanie(n);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 1;
            pokazPytanie(n);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 2;
            pokazPytanie(n);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 3;
            pokazPytanie(n);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 4;
            pokazPytanie(n);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 5;
            pokazPytanie(n);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 6;
            pokazPytanie(n);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 7;
            pokazPytanie(n);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 8;
            pokazPytanie(n);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 9;
            pokazPytanie(n);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 10;
            pokazPytanie(n);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 11;
            pokazPytanie(n);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 12;
            pokazPytanie(n);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 13;
            pokazPytanie(n);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 14;
            pokazPytanie(n);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 15;
            pokazPytanie(n);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 16;
            pokazPytanie(n);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 17;
            pokazPytanie(n);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Następne";
            n = 18;
            pokazPytanie(n);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            sprawdzRadioButton();
            button2.Text = "Zakończ";
            n = 19;
            pokazPytanie(n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
