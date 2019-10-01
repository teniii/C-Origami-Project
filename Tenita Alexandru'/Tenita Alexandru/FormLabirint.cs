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
    public partial class FormLabirint : Form
    {
        public FormLabirint()
        {
            InitializeComponent();
        }

        private int nrLinii = 15, nrcoloane = 15, dwh;
        private int[] dl = { -1, 0, 1, 0 };
        private int[] dc = { 0, 1, 0, -1 };
        private Panel[,] labirint;
        int liniecurentafoarfeca1, coloanacurentafoarfeca1;

        int liniecurentafoarfeca2, coloanacurentafoarfeca2;
        int liniecurentafoarfeca3, coloanacurentafoarfeca3;

        int liniecurentadragon = 1, coloanacurentadragon = 1;

        Random rd = new Random();

        private void FormLabirint_Load(object sender, EventArgs e)
        {
            int i, j;
            int ocupat;
            labirint = new Panel[nrLinii, nrcoloane];
            dwh = this.Width / (nrcoloane + 2);
            pictureBox1.Height = dwh;
            pictureBox1.Width = dwh;
            pictureBox2.Height = dwh;
            pictureBox2.Width = dwh;
            pictureBox3.Height = dwh;
            pictureBox3.Width = dwh;
            pictureBox4.Height = dwh;
            pictureBox4.Width = dwh;
            this.Height = dwh * 18;
            for (i = 0; i < nrLinii; i++)
                for (j = 0; j < nrcoloane; j++)
                {
                    labirint[i, j] = new Panel();
                    labirint[i, j].Height = dwh;
                    labirint[i, j].Width = dwh;
                    labirint[i, j].Top = dwh * (i + 1);
                    labirint[i, j].Left = dwh * (j + 1);
                    ocupat = rd.Next(3);
                    if (ocupat == 1)
                        labirint[i, j].BackColor = Color.Black;
                    else
                        labirint[i, j].BackColor = Color.CadetBlue;
                    this.Controls.Add(labirint[i, j]);

                }

            CautLocLiber(out liniecurentadragon, out coloanacurentadragon);
            PlaseazaPersonaj(liniecurentadragon, coloanacurentadragon, pictureBox1);
            CautLocLiber(out liniecurentafoarfeca1, out coloanacurentafoarfeca1);
            PlaseazaPersonaj(liniecurentafoarfeca1, coloanacurentafoarfeca1, pictureBox2);
            CautLocLiber(out liniecurentafoarfeca2, out coloanacurentafoarfeca2);
            PlaseazaPersonaj(liniecurentafoarfeca2, coloanacurentafoarfeca2, pictureBox3);
            CautLocLiber(out liniecurentafoarfeca3, out coloanacurentafoarfeca3);
            PlaseazaPersonaj(liniecurentafoarfeca3, coloanacurentafoarfeca3, pictureBox4);

            timer1.Start();
        }


        private void FormLabirint_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (valid(liniecurentadragon, coloanacurentadragon + 1, pictureBox1) == 1)
                        coloanacurentadragon++;
                    break;
                case Keys.Left:
                    if (valid(liniecurentadragon, coloanacurentadragon - 1, pictureBox1) == 1)
                        coloanacurentadragon--;
                    break;
                case Keys.Up:
                    if (valid(liniecurentadragon - 1, coloanacurentadragon, pictureBox1) == 1)
                        liniecurentadragon--;
                    break;
                case Keys.Down:
                    if (valid(liniecurentadragon + 1, coloanacurentadragon, pictureBox1) == 1)
                        liniecurentadragon++;
                    break;

            }
            PlaseazaPersonaj(liniecurentadragon, coloanacurentadragon, pictureBox1);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Mutafoarfeca(ref liniecurentafoarfeca1, ref coloanacurentafoarfeca1, pictureBox2);
            Mutafoarfeca(ref liniecurentafoarfeca2, ref coloanacurentafoarfeca2, pictureBox3);
            Mutafoarfeca(ref liniecurentafoarfeca3, ref coloanacurentafoarfeca3, pictureBox4);
        }

        private void pictureBox1_Move(object sender, EventArgs e)
        {
            if (liniecurentadragon == 0 || coloanacurentadragon == 0 || liniecurentadragon == nrLinii - 1 || coloanacurentadragon == nrcoloane - 1)
            {
                label1.Visible = true;
                label1.Text = "Dragonul a invins!";
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void pictureBox2_Move(object sender, EventArgs e)
        {
            if (pictureBox1.Bounds == (sender as PictureBox).Bounds)
            {
                label1.Visible = true;
                label1.Text = "Foarfecele au invins!";
                pictureBox1.Visible = false;
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void pictureBox3_Move(object sender, EventArgs e)
        {
            if (pictureBox1.Bounds == (sender as PictureBox).Bounds)
            {
                label1.Visible = true;
                label1.Text = "Foarfecele au invins!";
                pictureBox1.Visible = false;
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void pictureBox4_Move(object sender, EventArgs e)
        {
            if (pictureBox1.Bounds == (sender as PictureBox).Bounds)
            {
                label1.Visible = true;
                label1.Text = "Foarfecele au invins!";
                pictureBox1.Visible = false;
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private int valid(int linie, int coloana, PictureBox personaj)
        {
            if (linie < 0 || coloana < 0 || linie >= nrLinii | coloana >= nrcoloane)
                return 0;
            if (personaj.Equals(pictureBox1) == true && labirint[linie, coloana].BackColor != Color.CadetBlue)
                return 0;
            if (personaj.Equals(pictureBox1) == false && labirint[linie, coloana].BackColor == Color.Black)
                return 0;
            return 1;
        }

        private void PlaseazaPersonaj(int linie, int coloana, PictureBox personaj)
        {
            if (personaj.Equals(pictureBox1) == false)
                labirint[linie, coloana].BackColor = Color.Red;
            personaj.Top = (linie + 1) * dwh;
            personaj.Left = (coloana + 1) * dwh;
        }

        private void Mutafoarfeca(ref int linie, ref int coloana, PictureBox personaj)
        {
            int linieNoua, coloanaNoua, directieCurenta;
            directieCurenta = rd.Next(4);
            linieNoua = linie + dl[directieCurenta];
            coloanaNoua = coloana + dc[directieCurenta];
            if (valid(linieNoua, coloanaNoua, personaj) == 1)
            {
                linie = linieNoua;
                coloana = coloanaNoua;
                PlaseazaPersonaj(linie, coloana, personaj);
            }

        }

        private void CautLocLiber(out int linie, out int coloana)
        {
            do
            {
                linie = rd.Next(nrLinii);
                coloana = rd.Next(nrcoloane);
            }
            while (labirint[linie, coloana].BackColor == Color.Black);
        }

    }
}
