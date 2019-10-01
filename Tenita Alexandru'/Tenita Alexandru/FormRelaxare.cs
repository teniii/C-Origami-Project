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
    public partial class FormRelaxare : Form
    {
        public FormRelaxare()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            (sender as PictureBox).Width *= 2;
            (sender as PictureBox).Height *= 2;
            (sender as PictureBox).BringToFront();
        }

        private void pictureBox1_MouseLeave_1(object sender, EventArgs e)
        {
            (sender as PictureBox).Width /= 2;
            (sender as PictureBox).Height /= 2;
            (sender as PictureBox).SendToBack();
        }

        private void FormRelaxare_Load(object sender, EventArgs e)
        {

        }
    }
}
