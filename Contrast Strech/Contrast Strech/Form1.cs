using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Windows.Forms.DataVisualization.Charting;

namespace Contrast_Strech
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button_resimyukle_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = "C:\\Users\\AdemKose\\Desktop";
            openFileDialog1.RestoreDirectory = true;
            pictureBox_orjinal.Image = Image.FromFile(openFileDialog1.FileName.ToString());
            pictureBox_orjinal.SizeMode = PictureBoxSizeMode.AutoSize;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap resimorjinal = new Bitmap(pictureBox_orjinal.Image);
            Bitmap resim_strech = new Bitmap(pictureBox_orjinal.Image);
            int[] histogram = new int[256];
            int[] histogram_R = new int[256];
            int[] histogram_G = new int[256];
            int[] histogram_B = new int[256];
            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    histogram[(int)(resimorjinal.GetPixel(i, j).R * 0.3 + resimorjinal.GetPixel(i, j).G * 0.59 + resimorjinal.GetPixel(i, j).B * 0.11)]++;
                    histogram_R[resimorjinal.GetPixel(i, j).R]++;
                    histogram_G[resimorjinal.GetPixel(i, j).G]++;
                    histogram_B[resimorjinal.GetPixel(i, j).B]++;
                }
            }



            //histogram ekrana basılıyor
            Series seri_R = chart1.Series.Add("Histogram R");
            Series seri_G = chart2.Series.Add("Histogram G");
            Series seri_B = chart3.Series.Add("Histogram B");
           
            int index_enbuyuk_histogram = 0;
            int index_enkucuk_histogram = 255;

            int index_enbuyuk_histogram_R = 0;
            int index_enkucuk_histogram_R = 255;


            int index_enbuyuk_histogram_G = 0;
            int index_enkucuk_histogram_G = 255;


            int index_enbuyuk_histogram_B = 0;
            int index_enkucuk_histogram_B = 255;

            for (int i = 0; i < 256; i++)
            {
                seri_R.Points.Add(histogram_R[i]);
                seri_G.Points.Add(histogram_G[i]);
                seri_B.Points.Add(histogram_B[i]);

                if (i < index_enkucuk_histogram && histogram[i] != 0)
                {                    
                    index_enkucuk_histogram = i;
                }
                if (i > index_enbuyuk_histogram && histogram[i] != 0)
                {                  
                    index_enbuyuk_histogram = i;
                }


                if (i < index_enkucuk_histogram_R && histogram_R[i] != 0)
                {
                    index_enkucuk_histogram_R = i;
                }
                if (i > index_enbuyuk_histogram_R && histogram_R[i] != 0)
                {
                    index_enbuyuk_histogram_R = i;
                }

                if (i < index_enkucuk_histogram_G && histogram_G[i] != 0)
                {
                    index_enkucuk_histogram_G = i;
                }
                if (i > index_enbuyuk_histogram_G && histogram_G[i] != 0)
                {
                    index_enbuyuk_histogram_G = i;
                }

                if (i < index_enkucuk_histogram_B && histogram_B[i] != 0)
                {
                    index_enkucuk_histogram_B = i;
                }
                if (i > index_enbuyuk_histogram_B && histogram_B[i] != 0)
                {
                    index_enbuyuk_histogram_B = i;
                }







            }
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
                histogram_R[i] = 0;
                histogram_G[i] = 0;
                histogram_B[i] = 0;
            }

            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    Color a = new Color();
                    a = resimorjinal.GetPixel(i, j);
                    
                    int Rout, Gout, Bout, Iout;
                    int z = (int)(a.R * 0.3 + a.G * 0.59 + a.B * 0.11);

                    Iout = (z - index_enkucuk_histogram) * ((255 - 0) / (index_enbuyuk_histogram - index_enkucuk_histogram)) + 0;

                    Rout = (a.R - index_enkucuk_histogram_R) * ((255 - 0) / (index_enbuyuk_histogram_R - index_enkucuk_histogram_R)) + 0;

                    Gout = (a.G - index_enkucuk_histogram_G) * ((255 - 0) / (index_enbuyuk_histogram_G - index_enkucuk_histogram_G)) + 0;

                    Bout = (a.B - index_enkucuk_histogram_B) * ((255 - 0) / (index_enbuyuk_histogram_B - index_enkucuk_histogram_B)) + 0;


                    histogram[Iout]++;
                    histogram_R[Rout]++;
                    histogram_G[Rout]++;
                    histogram_B[Rout]++;

                    resim_strech.SetPixel(i, j, Color.FromArgb( Rout, Gout, Bout));
                }

            }
            pictureBox_odsu.Image = resim_strech;


            //MessageBox.Show(enkucuk_histogram.ToString() + "  " + enbuyuk_histogram.ToString());
           this.Text=(index_enkucuk_histogram.ToString() + "  " + index_enbuyuk_histogram.ToString());



          


            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    histogram[(int)(resim_strech.GetPixel(i, j).R * 0.3 + resim_strech.GetPixel(i, j).G * 0.59 + resim_strech.GetPixel(i, j).B * 0.11)]++;
                }
            }



            //histogram ekrana basılıyor

            Series seri_R2 = chart1.Series.Add("Strech Histogram R");
            Series seri_G2 = chart2.Series.Add("Strech Histogram G");
            Series seri_B2 = chart3.Series.Add("Strech Histogram B");

            for (int i = 0; i < 256; i++)
            {
                seri_R2.Points.Add(histogram_R[i]);
                seri_G2.Points.Add(histogram_G[i]);
                seri_B2.Points.Add(histogram_B[i]);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int kaydirma_degeri =Convert.ToInt32(textBox1.Text);
            Bitmap resimorjinal = new Bitmap(pictureBox_orjinal.Image);
            Bitmap resim_strech = new Bitmap(pictureBox_orjinal.Image);
            int[] histogram = new int[256];
            int[] histogram_R = new int[256];
            int[] histogram_G = new int[256];
            int[] histogram_B = new int[256];
            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    histogram[(int)(resimorjinal.GetPixel(i, j).R * 0.3 + resimorjinal.GetPixel(i, j).G * 0.59 + resimorjinal.GetPixel(i, j).B * 0.11)]++;
                    histogram_R[resimorjinal.GetPixel(i, j).R]++;
                    histogram_G[resimorjinal.GetPixel(i, j).G]++;
                    histogram_B[resimorjinal.GetPixel(i, j).B]++;
                }
            }



            //histogram ekrana basılıyor
            Series seri_R = chart1.Series.Add("Histogram R");
            Series seri_G = chart2.Series.Add("Histogram G");
            Series seri_B = chart3.Series.Add("Histogram B");

            int index_enbuyuk_histogram = 0;
            int index_enkucuk_histogram = 255;

            int index_enbuyuk_histogram_R = 0;
            int index_enkucuk_histogram_R = 255;


            int index_enbuyuk_histogram_G = 0;
            int index_enkucuk_histogram_G = 255;


            int index_enbuyuk_histogram_B = 0;
            int index_enkucuk_histogram_B = 255;

            for (int i = 0; i < 256; i++)
            {
                seri_R.Points.Add(histogram_R[i]);
                seri_G.Points.Add(histogram_G[i]);
                seri_B.Points.Add(histogram_B[i]);

                if (i < index_enkucuk_histogram && histogram[i] != 0)
                {
                    index_enkucuk_histogram = i;
                }
                if (i > index_enbuyuk_histogram && histogram[i] != 0)
                {
                    index_enbuyuk_histogram = i;
                }


                if (i < index_enkucuk_histogram_R && histogram_R[i] != 0)
                {
                    index_enkucuk_histogram_R = i;
                }
                if (i > index_enbuyuk_histogram_R && histogram_R[i] != 0)
                {
                    index_enbuyuk_histogram_R = i;
                }

                if (i < index_enkucuk_histogram_G && histogram_G[i] != 0)
                {
                    index_enkucuk_histogram_G = i;
                }
                if (i > index_enbuyuk_histogram_G && histogram_G[i] != 0)
                {
                    index_enbuyuk_histogram_G = i;
                }

                if (i < index_enkucuk_histogram_B && histogram_B[i] != 0)
                {
                    index_enkucuk_histogram_B = i;
                }
                if (i > index_enbuyuk_histogram_B && histogram_B[i] != 0)
                {
                    index_enbuyuk_histogram_B = i;
                }







            }
            for (int i = 0; i < 256; i++)
            {
                histogram[i] = 0;
                histogram_R[i] = 0;
                histogram_G[i] = 0;
                histogram_B[i] = 0;
            }

            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    Color a = new Color();
                    a = resimorjinal.GetPixel(i, j);

                    int Rout, Gout, Bout, Iout;
                    int z = (int)(a.R * 0.3 + a.G * 0.59 + a.B * 0.11);

                    Iout = (z - index_enkucuk_histogram) * ((index_enbuyuk_histogram - index_enkucuk_histogram) / (index_enbuyuk_histogram - index_enkucuk_histogram)) +index_enkucuk_histogram+kaydirma_degeri;

                    Rout = (a.R - index_enkucuk_histogram_R) * ((index_enbuyuk_histogram - index_enkucuk_histogram) / (index_enbuyuk_histogram_R - index_enkucuk_histogram_R)) + index_enkucuk_histogram + kaydirma_degeri;

                    Gout = (a.G - index_enkucuk_histogram_G) * ((index_enbuyuk_histogram - index_enkucuk_histogram) / (index_enbuyuk_histogram_G - index_enkucuk_histogram_G)) + index_enkucuk_histogram + kaydirma_degeri;

                    Bout = (a.B - index_enkucuk_histogram_B) * ((index_enbuyuk_histogram - index_enkucuk_histogram) / (index_enbuyuk_histogram_B - index_enkucuk_histogram_B)) + index_enkucuk_histogram + kaydirma_degeri;
                    histogram[Iout]++;
                    histogram_R[Rout]++;
                    histogram_G[Rout]++;
                    histogram_B[Rout]++;

                    resim_strech.SetPixel(i, j, Color.FromArgb(Rout, Gout, Bout));
                }

            }
            pictureBox_odsu.Image = resim_strech;


            //MessageBox.Show(enkucuk_histogram.ToString() + "  " + enbuyuk_histogram.ToString());
            this.Text = (index_enkucuk_histogram.ToString() + "  " + index_enbuyuk_histogram.ToString());






            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    histogram[(int)(resim_strech.GetPixel(i, j).R * 0.3 + resim_strech.GetPixel(i, j).G * 0.59 + resim_strech.GetPixel(i, j).B * 0.11)]++;
                }
            }



            //histogram ekrana basılıyor

            Series seri_R2 = chart1.Series.Add("Slide Histogram R");
            Series seri_G2 = chart2.Series.Add("Slide Histogram G");
            Series seri_B2 = chart3.Series.Add("Slide Histogram B");

            for (int i = 0; i < 256; i++)
            {
                seri_R2.Points.Add(histogram_R[i]);
                seri_G2.Points.Add(histogram_G[i]);
                seri_B2.Points.Add(histogram_B[i]);
            }
        }


    }
}
