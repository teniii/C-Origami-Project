using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tenita_Alexandru
{
    public partial class FormMemory3 : Form
    {
        PictureBox pictureBoxAux;

        public FormMemory3()
        {
            InitializeComponent();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

           
            (sender as PictureBox).Load("resurse\\" + Convert.ToString((sender as PictureBox).Tag)+ ".jpg");
            if (pictureBoxAux == null)
                pictureBoxAux = sender as PictureBox;
            else
                if (pictureBoxAux.Tag.Equals((sender as PictureBox).Tag) == true)
            {
                pictureBoxAux.Enabled = false;
                (sender as PictureBox).Enabled = false;
                richTextBox1.LoadFile("resurse/" + Convert.ToString((sender as PictureBox).Tag) + ".rtf");
                pictureBoxAux = null;
            }
            else
            {
                pictureBoxAux.Image = Properties.Resources._0;
                pictureBoxAux = (sender as PictureBox);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormMemory3_Load(object sender, EventArgs e)
        {
            int nrPerechi = 5, i, tag;
            int[] perechi = new int[nrPerechi + 1];
            Random r = new Random();

            for (i = 0; i <= nrPerechi; i++)
                perechi[i] = 0;
            
            foreach (PictureBox p in groupBox1.Controls)
            {
               
                do
                {
                    tag = 1 + r.Next(nrPerechi);
                } while (perechi[tag] == 2);
                
                perechi[tag]++;
                p.Tag = tag;
               
               
            }
            
            pictureBoxAux = null;
            

        }



        //(sender as PictureBox).Load("resurse//" + Convert.ToString((sender as PictureBox).Tag) + ".jpg");
        //            (sender as PictureBox).Image=Properties.Resources._1;

    }
}
