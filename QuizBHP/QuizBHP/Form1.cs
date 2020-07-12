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

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Quiz1 = new Form2(1);
            Quiz1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Quiz1 = new Form2(2);
            Quiz1.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Quiz1 = new Form2(3);
            Quiz1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 Quiz1 = new Form2(4);
            Quiz1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 Quiz1 = new Form2(5);
            Quiz1.ShowDialog();
        }
    }
}
