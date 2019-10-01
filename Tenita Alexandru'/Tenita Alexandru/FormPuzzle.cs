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
    public partial class FormPuzzle : Form
    {
        PictureBox[,] puzzlebutton = new PictureBox[3, 3];
        int[] NumereOcupate = new int[10];

        public FormPuzzle()
        {
            InitializeComponent();
        }

        private void FormPuzzle_Load(object sender, EventArgs e)
        {
            int laturaH, laturaW, numar;
            int i, j;
            laturaH = this.Height/5;
            laturaW = this.Width/5;
            for (i = 0; i < 10; i++)
                NumereOcupate[i] = 0;
            Random r = new Random();
            for (i = 0; i < 3; i++)
                for (j = 0; j < 3; j++)
                {
                    puzzlebutton[i, j] = new PictureBox();
                    puzzlebutton[i, j].Width = laturaW;
                    puzzlebutton[i, j].Height = laturaH;
                    puzzlebutton[i, j].Left = laturaW * (j + 1);
                    puzzlebutton[i, j].Top = laturaH * (i + 1);
                    puzzlebutton[i, j].BackColor = Color.Blue;
                    puzzlebutton[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    do
                    {
                        numar = r.Next(0, 9);
                    } while (NumereOcupate[numar] != 0);
                    NumereOcupate[numar] = 1;
                    puzzlebutton[i, j].Tag = Convert.ToString(numar);
                    puzzlebutton[i, j].Load("resurse//Puzzle//" + Convert.ToString(puzzlebutton[i, j].Tag + ".jpg"));
                    puzzlebutton[i, j].Click += new EventHandler(puzzleButton_Click);
                    this.Controls.Add(puzzlebutton[i, j]);
                }
        }
        private void Vecin(int i, int j, out int iv, out int jv)
        {
            iv = i;
            jv = j;
            if (i > 0 && puzzlebutton[i - 1, j].Tag.Equals("0"))
                iv = i - 1;
            if (j > 0 && puzzlebutton[i, j - 1].Tag.Equals("0"))
                jv = j - 1;
            if (i < 2 && puzzlebutton[i + 1, j].Tag.Equals("0"))
                iv = i + 1;
            if (j < 2 && puzzlebutton[i, j + 1].Tag.Equals("0"))
                jv = j + 1;
        }
        private void Interschimba(int i1, int j1, int i2, int j2)
        {
            PictureBox aux = new PictureBox();
            aux.Image = puzzlebutton[i1, j1].Image;
            puzzlebutton[i1, j1].Image = puzzlebutton[i2, j2].Image;
            puzzlebutton[i2, j2].Image = aux.Image;
            string aux1;
            aux1 = Convert.ToString(puzzlebutton[i1, j1].Tag);
            puzzlebutton[i1, j1].Tag = puzzlebutton[i2, j2].Tag;
            puzzlebutton[i2, j2].Tag = aux1;

        }

        private void puzzleButton_Click(object sender, EventArgs ev)
        {
            int iSender = 0, jSender = 0;
            int iVecinSender, jVecinSender;
            if ((sender as PictureBox).Tag.Equals("0"))
                MessageBox.Show("Nu se poate muta patratul gol!");
            else
            {
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        if ((sender as PictureBox) == puzzlebutton[i, j])
                        {
                            iSender = i; jSender = j;
                        }
                Vecin(iSender, jSender, out iVecinSender, out jVecinSender);
                Interschimba(iSender, jSender, iVecinSender, jVecinSender);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int nr = 0;
            bool ok = true;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (puzzlebutton[i, j].Text != Convert.ToString(nr))
                        ok = false;
                    else nr++;
            if (ok == true) 
                MessageBox.Show("Bravo!");
            else
                MessageBox.Show("Nu e gata!");

        }

       
    }
}
