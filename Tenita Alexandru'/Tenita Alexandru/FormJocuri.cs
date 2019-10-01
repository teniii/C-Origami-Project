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
    public partial class FormJocuri : Form
    {
        public FormJocuri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMemory3 f = new FormMemory3();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPuzzle f = new FormPuzzle();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLabirint l = new FormLabirint();
            l.Show();
        }
    }
}
