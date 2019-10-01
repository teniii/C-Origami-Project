using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Tenita_Alexandru
{
    public partial class FormTestulet : Form
    {
        public FormTestulet()
        {
            InitializeComponent();
        }

        int nrIntrebari = 0;
        int IntrebareCurenta = 0;
        int RaspunsuriCorecte = 0;
        StreamReader inputfile = new StreamReader("resurse\\Test\\raspunsuri.txt");

        private void CitesteIntrebare()
        {
            string linie;
            IntrebareCurenta++;
            linie = inputfile.ReadLine();
            groupBox1.Text = linie;
            linie = inputfile.ReadLine();
            radioButton1.Text = linie;
            linie = inputfile.ReadLine();
            radioButton1.Tag = linie;
            linie = inputfile.ReadLine();
            radioButton2.Text = linie;
            linie = inputfile.ReadLine();
            radioButton2.Tag = linie;
            linie = inputfile.ReadLine();
            radioButton3.Text = linie;
            linie = inputfile.ReadLine();
            radioButton3.Tag = linie;
            linie = inputfile.ReadLine();
            radioButton4.Text = linie;
            linie = inputfile.ReadLine();
            radioButton4.Tag = linie;
        }

        private void FormTestulet_Load(object sender, EventArgs e)
        {
            nrIntrebari = Convert.ToInt32(inputfile.ReadLine());
            CitesteIntrebare();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Tag.Equals("1") == true && radioButton1.Checked == true || radioButton2.Tag.Equals("1") == true && radioButton2.Checked == true || radioButton3.Tag.Equals("1") == true && radioButton3.Checked == true || radioButton4.Tag.Equals("1") == true && radioButton4.Checked == true)
                RaspunsuriCorecte++;
            if (IntrebareCurenta < nrIntrebari)
                CitesteIntrebare();
            else MessageBox.Show("Ati raspuns corect la " + Convert.ToString(RaspunsuriCorecte) + " dintre intrebari.");

        }
    }
}
