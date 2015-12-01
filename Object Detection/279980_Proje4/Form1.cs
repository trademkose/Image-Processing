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

namespace _279980_Proje4
{
    public partial class Form1 : Form
    {
        double[,] M = new double[100, 8];
        public Form1()
        {
            InitializeComponent();
        }

        private void button_resimyukle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = "C:\\Users\\AdemKose\\Desktop";
            openFileDialog1.RestoreDirectory = true;
            pictureBox_orjinal.Image = Image.FromFile(openFileDialog1.FileName.ToString());
            pictureBox_orjinal.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void button_odsu_Click(object sender, EventArgs e)
        {
            List<string> esitlik = new List<string>();

            Bitmap resimorjinal = new Bitmap(pictureBox_orjinal.Image);
            Bitmap resimbinary = new Bitmap(pictureBox_orjinal.Image);
            int[] histogram = new int[256];

            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {

                    histogram[(int)(resimorjinal.GetPixel(i, j).R * 0.3 + resimorjinal.GetPixel(i, j).G * 0.59 + resimorjinal.GetPixel(i, j).B * 0.11)]++;
                }
            }

            //histogram ekrana basılıyor
            Series seri = chart1.Series.Add("Histogram");

            for (int i = 0; i < 256; i++)
            {
                seri.Points.Add(histogram[i]);

            }

            int toplampixel_sayisi = (resimorjinal.Width + 1) * (resimorjinal.Height + 1);


            // odsu 

            float toplam_histogram_x_index = 0;
            for (int t = 0; t < 256; t++)
            {
                toplam_histogram_x_index += t * histogram[t];
            }


            float toplamB = 0,EnyuksekVaryans = 0;
            int wB = 0,wF=0,EsikDegeri = 0;
            float mB, mF;
            float varSınıflarArasi;

            for (int t = 0; t < 256; t++)
            {
                wB += histogram[t];               // Arkaplan için  Weight Background
                if (wB == 0)
                {
                    //atla bu histogram elemanını
                    continue;
                }

                /// wb+ wf = toplam piksel sayısı kadardır/ tekrar hesaplanmasına gerek yoktur
                wF = toplampixel_sayisi - wB;                 // Önplan için ---Weight Foreground
                if (wF == 0)
                {
                   //bundan sonrakiler olamaz zaten
                    break;
                }

                toplamB += (float)(t * histogram[t]);

                 mB = toplamB / wB;            //  Arkaplan için ortalama ---  Mean Background
                mF = (toplam_histogram_x_index - toplamB) / wF;    // Önplan için ortalama ---Mean Foreground

                // Sınıflar arası varyans hesaplama  wb*wf(mb-mf)^2
                varSınıflarArasi =  (mB - mF) * (mB - mF);
                varSınıflarArasi = varSınıflarArasi * (float)wB * (float)wF;



                // en büyük varyans değeri bulunuyor ,eğerki büyükse en büyük ol 
                if (varSınıflarArasi > EnyuksekVaryans)
                {
                    EnyuksekVaryans = varSınıflarArasi;
                    EsikDegeri = t;
                }
            }



            //------------------------------- otsu yukarısı -----------------------

            int[,] binary_resim_dizisi = new int[pictureBox_orjinal.Image.Width, pictureBox_orjinal.Image.Height];
            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {
                    if (((int)(resimorjinal.GetPixel(i, j).R * 0.3 + resimorjinal.GetPixel(i, j).G * 0.59 + resimorjinal.GetPixel(i, j).B * 0.11)) > EsikDegeri)
                    {
                        resimbinary.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        binary_resim_dizisi[i, j] = 0;
                    }
                    else
                    {
                        resimbinary.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        binary_resim_dizisi[i, j] = 1;
                    }

                }
            }
            pictureBox_odsu.Image = resimbinary;
            //ODSU BİNARY FİNISH

            //etiketleme
            int etiket_numarası = 1;

            for (int i = 1; i < pictureBox_orjinal.Image.Width - 1; i++)
            {

                for (int j = 1; j < pictureBox_orjinal.Image.Height - 1; j++)
                {
                    //etiket almamıştır
                    if (binary_resim_dizisi[i, j] == 1)
                    {
                        //etiket verilir ve etiket numarası 1 artırılır
                        etiket_numarası++;
                        binary_resim_dizisi[i, j] = etiket_numarası;
                        //8 komuşusu olan 1lerede aynı etiket verilir
                        if (binary_resim_dizisi[i - 1, j - 1] == 1)
                        {
                            binary_resim_dizisi[i - 1, j - 1] = etiket_numarası;

                        } if (binary_resim_dizisi[i - 1, j] == 1)
                        {
                            binary_resim_dizisi[i - 1, j] = etiket_numarası;

                        } if (binary_resim_dizisi[i - 1, j + 1] == 1)
                        {
                            binary_resim_dizisi[i - 1, j + 1] = etiket_numarası;
                        }



                        if (binary_resim_dizisi[i, j - 1] == 1)
                        {
                            binary_resim_dizisi[i, j - 1] = etiket_numarası;

                        } if (binary_resim_dizisi[i, j + 1] == 1)
                        {
                            binary_resim_dizisi[i, j + 1] = etiket_numarası;

                        }


                        if (binary_resim_dizisi[i + 1, j - 1] == 1)
                        {
                            binary_resim_dizisi[i + 1, j - 1] = etiket_numarası;

                        } if (binary_resim_dizisi[i + 1, j] == 1)
                        {
                            binary_resim_dizisi[i + 1, j] = etiket_numarası;

                        } if (binary_resim_dizisi[i + 1, j + 1] == 1)
                        {
                            binary_resim_dizisi[i + 1, j + 1] = etiket_numarası;

                        }


                    }//etiket almışsa 
                    else if (binary_resim_dizisi[i, j] > 1)
                    {
                        //8 komşuna bakılır ve onlarda aynı etiket verilir
                        if (binary_resim_dizisi[i - 1, j - 1] == 1)
                        {
                            binary_resim_dizisi[i - 1, j - 1] = binary_resim_dizisi[i, j];

                        } if (binary_resim_dizisi[i - 1, j] == 1)
                        {
                            binary_resim_dizisi[i - 1, j] = binary_resim_dizisi[i, j];

                        } if (binary_resim_dizisi[i - 1, j + 1] == 1)
                        {
                            binary_resim_dizisi[i - 1, j + 1] = binary_resim_dizisi[i, j];
                        }

                        if (binary_resim_dizisi[i, j - 1] == 1)
                        {
                            binary_resim_dizisi[i, j - 1] = binary_resim_dizisi[i, j];

                        } if (binary_resim_dizisi[i, j + 1] == 1)
                        {
                            binary_resim_dizisi[i, j + 1] = binary_resim_dizisi[i, j];

                        }


                        if (binary_resim_dizisi[i + 1, j - 1] == 1)
                        {
                            binary_resim_dizisi[i + 1, j - 1] = binary_resim_dizisi[i, j];

                        }
                        if (binary_resim_dizisi[i + 1, j] == 1)
                        {
                            binary_resim_dizisi[i + 1, j] = binary_resim_dizisi[i, j];

                        } if (binary_resim_dizisi[i + 1, j + 1] == 1)
                        {
                            binary_resim_dizisi[i + 1, j + 1] = binary_resim_dizisi[i, j];

                        }



                        //8komşununda etiketi varsa (1den büyükse colison) etiketi olanlarda aynısını almalı ve kendisenden farklı ise
                        if (binary_resim_dizisi[i - 1, j - 1] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i - 1, j - 1])
                        {


                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i - 1, j - 1])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }


                        } if (binary_resim_dizisi[i - 1, j] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i - 1, j])
                        {


                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i - 1, j])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }

                        } if (binary_resim_dizisi[i - 1, j + 1] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i - 1, j + 1])
                        {


                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i - 1, j + 1])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }
                        }

                        if (binary_resim_dizisi[i, j - 1] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i, j - 1])
                        {



                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i, j - 1])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }

                        } if (binary_resim_dizisi[i, j + 1] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i, j + 1])
                        {


                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i, j + 1])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }
                        }


                        if (binary_resim_dizisi[i + 1, j - 1] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i + 1, j - 1])
                        {
                            //esitlik_kimle.Add(binary_resim_dizisi[i + 1, j - 1]);
                            //esitlik_kim.Add(binary_resim_dizisi[i, j]);

                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i + 1, j - 1])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }
                        }
                        if (binary_resim_dizisi[i + 1, j] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i + 1, j])
                        {
                            //esitlik_kimle.Add(binary_resim_dizisi[i + 1, j]);
                            //esitlik_kim.Add(binary_resim_dizisi[i, j]);
                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i + 1, j])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }

                        } if (binary_resim_dizisi[i + 1, j + 1] > 1 && binary_resim_dizisi[i, j] != binary_resim_dizisi[i + 1, j + 1])
                        {
                            //esitlik_kimle.Add(binary_resim_dizisi[i + 1, j + 1]);
                            //esitlik_kim.Add(binary_resim_dizisi[i, j]);
                            for (int inew = 1; inew < pictureBox_orjinal.Image.Width - 1; inew++)
                            {

                                for (int jnew = 1; jnew < pictureBox_orjinal.Image.Height - 1; jnew++)
                                {


                                    if (binary_resim_dizisi[inew, jnew] == binary_resim_dizisi[i + 1, j + 1])
                                    {

                                        binary_resim_dizisi[inew, jnew] = binary_resim_dizisi[i, j];

                                    }
                                }
                            }
                        }




                    }

                }
            }


            List<int> nesneler = new List<int> { };
            Bitmap resimetiketli = new Bitmap(pictureBox_orjinal.Image);
            for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
            {

                for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                {
                    Color[] renkler = new Color[] { Color.Tomato, Color.DarkBlue, Color.Pink, Color.Blue, Color.Red, Color.DarkOrange, Color.Chocolate, Color.Green, Color.Turquoise, Color.OldLace };
                    if (binary_resim_dizisi[i, j] != 0)
                    {
                        resimetiketli.SetPixel(i, j, renkler[binary_resim_dizisi[i, j] % 9]);

                    }
                    else
                    {
                        resimetiketli.SetPixel(i, j, Color.White);
                    }

                    nesneler.Add(binary_resim_dizisi[i, j]);
                }
            }
            nesneler = nesneler.Distinct().ToList();

            pictureBox_labeling.Image = resimetiketli;
            label_nesne_saiyisi.Text = "Algılanan Nesne Sayisi : " + (nesneler.Count - 1).ToString();


            Bitmap resimeaobje = new Bitmap(pictureBox_orjinal.Image);

            //çerceve
            for (int index = 0; index < nesneler.Count; index++)
            {
                if (nesneler[index] == 0) continue;

                int solkenar = 100000000, sagkenar = 0, ustkenar = 1000000000, altkenar = 0;
                for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
                {

                    for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                    {
                        if (nesneler[index] == binary_resim_dizisi[i, j])
                        {

                            if (i < solkenar)
                            {
                                solkenar = i;
                            }
                            if (i > sagkenar)
                            {
                                sagkenar = i;
                            }
                            if (j < ustkenar)
                            {
                                ustkenar = j;
                            }
                            if (j > altkenar)
                            {
                                altkenar = j;
                            }
                        }
                    }
                }
                //belirli bir bölgenin dizisini oluşturabilitoyuz
                int[,] dizimiz = new int[sagkenar - solkenar + 1, altkenar - ustkenar + 1];
                int yeni_i = 0;
                int yeni_j = 0;

                for (int i = 0; i < pictureBox_orjinal.Image.Width; i++)
                {

                    for (int j = 0; j < pictureBox_orjinal.Image.Height; j++)
                    {

                        if (i >= solkenar && i <= sagkenar && j >= ustkenar && j <= altkenar && nesneler[index] == binary_resim_dizisi[i, j])
                        {
                            dizimiz[i - solkenar, j - ustkenar] = 1;
                            resimeaobje.SetPixel(i, j, Color.Red);
                        }
                        else if (i >= solkenar && i <= sagkenar && j >= ustkenar && j <= altkenar && nesneler[index] != binary_resim_dizisi[i, j])
                        {
                            dizimiz[i - solkenar, j - ustkenar] = 0;
                            resimeaobje.SetPixel(i, j, Color.Black);
                        }
                        else
                        {
                            resimeaobje.SetPixel(i, j, Color.White);
                        }
                    }
                }
                pictureBox_aobject.Image = resimeaobje;

                ///ETİKETLEEME FINISH


                /// moment çıkartma

                double[,] u = new double[4, 4];
                double X, Y;
                u[1, 0] = u_degeri(1, 0, 0, 0, sagkenar - solkenar + 1, altkenar - ustkenar + 1, dizimiz);
                u[0, 1] = u_degeri(0, 1, 0, 0, sagkenar - solkenar + 1, altkenar - ustkenar + 1, dizimiz);
                u[0, 0] = u_degeri(0, 0, 0, 0, sagkenar - solkenar + 1, altkenar - ustkenar + 1, dizimiz);
                //richTextBox1.Text += "u10 = " + u[1, 0].ToString() + "\n";
                //richTextBox1.Text += "u01 = " + u[0, 1].ToString() + "\n";
                //richTextBox1.Text += "u00 = " + u[0, 0].ToString() + "\n";
                X = u[1, 0] / u[0, 0];
                Y = u[0, 1] / u[0, 0];
                //richTextBox1.Text += "X agırlık = " + X.ToString() + "\n";
                //richTextBox1.Text += "Y agırlık = " + Y.ToString() + "\n";



                for (int sira_i = 0; sira_i < 4; sira_i++)
                {
                    for (int sira_j = 0; sira_j < 4; sira_j++)
                    {
                        u[sira_i, sira_j] = u_degeri(sira_i, sira_j, X, Y, sagkenar - solkenar + 1, altkenar - ustkenar + 1, dizimiz);
                        //richTextBox1.Text += "u" + sira_i.ToString() + sira_j.ToString() + " = " + u[sira_i, sira_j].ToString() + "\n";
                    }

                }




                M[index, 1] = (u[2, 0] + u[0, 2]);


                //M[2] = (u[2,0] - u[0,2])^2 + 4*(u[1,1]^2);
                M[index, 2] = (u[2, 0] - u[0, 2]) * (u[2, 0] - u[0, 2]) + 4 * (u[1, 1] * u[1, 1]);

                //M[3] = (u[3,0] - 3*u[1,2])^2 + (3*u[2,1] - u[3,0])^2;
                M[index, 3] = (u[3, 0] - 3 * u[1, 2]) * (u[3, 0] - 3 * u[1, 2]) + (3 * u[2, 1] - u[3, 0]) * (3 * u[2, 1] - u[3, 0]);

                //M[4] = (u[3,0] + u[1,2])^2 + (u[2,1] + u[0,3])^2;

                M[index, 4] = (u[3, 0] + u[1, 2]) * (u[3, 0] + u[1, 2]) + (u[2, 1] + u[0, 3]) * (u[2, 1] + u[0, 3]);

                M[index, 5] = (u[3, 0] - 3 * u[1, 2]) * (u[3, 0] + u[1, 2]) * ((u[3, 0] + u[1, 2]) * (u[3, 0] + u[1, 2]) - 3 * ((u[2, 1] + u[0, 3]) * (u[2, 1] + u[0, 3]))) + (3 * u[2, 1] - u[0, 3]) * (u[2, 1] + u[0, 3]) * (3 * ((u[3, 0] + u[1, 2]) * (u[3, 0] + u[1, 2])) - (u[2, 1] + u[0, 3]) * (u[2, 1] + u[0, 3]));
                ////M[5] = (u[3,0] - 3*u[1,2])*(u[3,0] + u[1,2])*((u[3,0] + u[1,2])^2 - 3*(u[2,1] + u[0,3])^2) + (3*u[2,1] - u[0,3])*(u[2,1] + u[0,3])* (3*(u[3,0] + u[1,2])^2 - (u[2,1] + u[0,3])^2);
                ////M[6] = (u[2,0] - u[0,2])*((u[3,0] + u[1,2])^2 - (u[2,1] + u[0,3])^2) + 4*u[1,1]*(u[3,0] + 3*u[1,2])*(u[2,1] + u[0,3]);

                M[index, 6] = (u[2, 0] - u[0, 2]) * ((u[3, 0] + u[1, 2]) * (u[3, 0] + u[1, 2]) - (u[2, 1] + u[0, 3]) * (u[2, 1] + u[0, 3])) + 4 * u[1, 1] * (u[3, 0] + 3 * u[1, 2]) * (u[2, 1] + u[0, 3]);

                ////M[7] = (3u[2,1] - u[0,3])*(u[3,0] + u[1,2])*((u[3,0] + u[1,2])^2 - 3*(u[2,1] + u[0,3])^2) - (u[3,0] - 3u[1,2])*(u[2,1] + u[0,3])*(3*(u[3,0] + u[1,2])^2 - (u[2,1] + u[0,3])^2);


                M[index, 7] = (3 * u[2, 1] - u[0, 3]) * (u[3, 0] + u[1, 2]) * ((u[3, 0] + u[1, 2]) * (u[3, 0] + u[1, 2]) - 3 * (u[2, 1] + u[0, 3]) * (u[2, 1] + u[0, 3])) - (u[3, 0] - 3 * u[1, 2]) * (u[2, 1] + u[0, 3]) * (3 * (u[3, 0] + u[1, 2]) * (u[3, 0] + u[1, 2]) - (u[2, 1] + u[0, 3]) * (u[2, 1] + u[0, 3]));


                //ekrana bastırma

                for (int sira_i = 1; sira_i < 8; sira_i++)
                {
                    richTextBox1.Text += "M[" + sira_i.ToString() + "] = " + M[index, sira_i].ToString() + "\n";
                }
                richTextBox1.Text += solkenar.ToString() + "-" + sagkenar.ToString() + " ," + ustkenar.ToString() + "-" + altkenar.ToString() + "************* \n";



            }

            //oklid 
            double[,] Mornek = new double[3, 8];
            //for (int sira_satir = 1; sira_satir < 8; sira_satir++)
            //{
            //    Mornek[sira_satir] = (M[6, sira_satir]);
            //}


            ////daire
            //Mornek[0,1] = 1198856;
            //Mornek[0,2] = 1436848622212;
            //Mornek[0,3] = 2876905150452;
            //Mornek[0,4] = 2874147360488;
            //Mornek[0,5] = Convert.ToDouble("8,26075242632991E+24");
            //Mornek[0,6] = Convert.ToDouble("6,89242977479544E+18");
            //Mornek[0,7] = Convert.ToDouble("-2,37051578710149E+21");

            ////yıldız
            //Mornek[1, 1] = 1138868;
            //Mornek[1, 2] = 1301626916944;
            //Mornek[1, 3] = 2592305187732;
            //Mornek[1, 4] = 2594478066592;
            //Mornek[1, 5] = Convert.ToDouble("6,73147269922819E+24");
            //Mornek[1, 6] = Convert.ToDouble("5,91689712767269E+18");
            //Mornek[1, 7] = Convert.ToDouble("-1,90776756180401E+22");

            ////artıyayyık
            //Mornek[2, 1] = 808734;
            //Mornek[2, 2] = 653219698000;
            //Mornek[2, 3] = 1308043746720;
            //Mornek[2, 4] = 1307512673536;
            //Mornek[2, 5] = Convert.ToDouble("1,70956397232304E+24");
            //Mornek[2, 6] = Convert.ToDouble("2,11397844113583E+18");
            //Mornek[2, 7] = Convert.ToDouble("1,59001599503147E+21");


            ///eğitim kısımı
            //tohum
            Mornek[0, 1] = 57094;
            Mornek[0, 2] = 3246959988;
            Mornek[0, 3] = 6512381460;
            Mornek[0, 4] = 6492992656;
            Mornek[0, 5] = Convert.ToDouble("4,21590760104447E+19");
            Mornek[0, 6] = Convert.ToDouble("740669243545152");
            Mornek[0, 7] = Convert.ToDouble("-2,36776174779228E+16");

            //kestane
            Mornek[1, 1] = 314382;
            Mornek[1, 2] = 98390523008;
            Mornek[1, 3] = 198611589536;
            Mornek[1, 4] = 197946614912;
            Mornek[1, 5] = Convert.ToDouble("3,91854627565878E+22");
            Mornek[1, 6] = Convert.ToDouble("1,24307417894428E+17");
            Mornek[1, 7] = Convert.ToDouble("-3,38865482581347E+19");

            //cekirdek
            Mornek[2, 1] = 69828;
            Mornek[2, 2] = 4872042304;
            Mornek[2, 3] = 9788538500;
            Mornek[2, 4] = 9784886120;
            Mornek[2, 5] = Convert.ToDouble("9,57384337133968E+19");
            Mornek[2, 6] = Convert.ToDouble("1,36639942338842E+15");
            Mornek[2, 7] = Convert.ToDouble("1,91632983732732E+17");





            int sayac_tohum=0, sayac_kestane=0, sayac_cekirdek = 0;
            for (int sira_sutun = 1; sira_sutun < nesneler.Count; sira_sutun++)
            {
                int nesne = 0;

                double uzaklık_yeni = Convert.ToDouble("9,37051578710149E+100");
                for (int sira_ornek = 0; sira_ornek <3 ; sira_ornek++)
                {
                    double uzaklık = 0;
                    for (int sira_satir = 1; sira_satir < 8; sira_satir++)
                    {

                        uzaklık += (M[sira_sutun, sira_satir] - Mornek[sira_ornek, sira_satir]) * (M[sira_sutun, sira_satir] - Mornek[sira_ornek, sira_satir]);
                        //richTextBox1.Text += "M[" + sira_satir.ToString() + "] = " + M[sira_sutun,sira_satir].ToString() + "\n";
                    }
                    uzaklık = Math.Sqrt(uzaklık);
                    if (uzaklık < uzaklık_yeni)
                    {
                        nesne = sira_ornek;
                        uzaklık_yeni = uzaklık;
                    }
                }
                if (nesne == 0)
                {
                    sayac_tohum++;
                }else if(nesne==1)
                {
                    sayac_kestane++;
                }else if(nesne==2)
                {
                    sayac_cekirdek++;
                }
            }

            label_nesne_saiyisi.Text += "\n Tohum : "+sayac_tohum.ToString()+"  Kestane : "+ sayac_kestane.ToString()+"  Cekirdek : "+ sayac_cekirdek.ToString();
            

        }

        public int u_degeri(int p, int q, double agırlık_x, double agırlık_y, int N, int K, int[,] binary_resim)
        {
            int u_geridonus = 0;

            for (int j = 0; j < K - 1; j++)
            {

                for (int i = 0; i < N - 1; i++)
                {
                    u_geridonus += (i ^ p) * (j ^ q) * binary_resim[i, j];
                }

            }


            return u_geridonus;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button_etiketleme_Click(object sender, EventArgs e)
        {



        }

        private void button_moment_Click(object sender, EventArgs e)
        {
            int[,] dizimiz = new int[5, 5];
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    dizimiz[i, j] = (i) % 2;

            this.Text = u_degeri(1, 0, 0, 0, 5, 5, dizimiz).ToString();

        }
    }
}
