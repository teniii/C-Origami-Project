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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormJocuri f = new FormJocuri();
            f.ShowDialog();
           // if (f.Item !=“”) 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormTestulet g = new FormTestulet();
            g.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormInformatii h = new FormInformatii();
            h.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormRelaxare f = new FormRelaxare();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
