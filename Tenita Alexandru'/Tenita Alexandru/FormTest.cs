using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tenita_Alexandru
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (radioButton3.Checked == true)
                i++;
            if (radioButton5.Checked == true)
                i++;
            if (radioButton10.Checked == true)
                i++;

            string text = "Ai raspuns corect la " + i.ToString() + " dintre intrebari";
            MessageBox.Show(text);
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
