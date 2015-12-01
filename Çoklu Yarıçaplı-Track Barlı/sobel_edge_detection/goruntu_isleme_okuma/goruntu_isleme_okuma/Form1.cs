using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace goruntu_isleme_okuma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonyukle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = "C:\\Users\\AdemKose\\Desktop";
            openFileDialog1.RestoreDirectory = true;
            pictureBox_orjinal.Image = Image.FromFile(openFileDialog1.FileName.ToString());
            pictureBox_orjinal.SizeMode = PictureBoxSizeMode.AutoSize;
        }



        public void gurultu()
        {

            int[,] GX = new int[3, 3];
            int[,] GY = new int[3, 3];



            GX[0, 0] = -1; GX[0, 1] = 0; GX[0, 2] = 1;
            GX[1, 0] = -2; GX[1, 1] = 0; GX[1, 2] = 2;
            GX[2, 0] = -1; GX[2, 1] = 0; GX[2, 2] = 1;

            GY[0, 0] = 1; GY[0, 1] = 2; GY[0, 2] = 1;
            GY[1, 0] = 0; GY[1, 1] = 0; GY[1, 2] = 0;
            GY[2, 0] = -1; GY[2, 1] = -2; GY[2, 2] = -1;


            Bitmap resimorjinal = new Bitmap(pictureBox_orjinal.Image);
            Bitmap resimsobel = new Bitmap(pictureBox_orjinal.Image);

            //int[,] resimgx = new int[pictureBox_orjinal.Image.Width, pictureBox_orjinal.Image.Height];
            //int[,] resimgy = new int[pictureBox_orjinal.Image.Width, pictureBox_orjinal.Image.Height];

            Color pixelColor_1_1, pixelColor_0_0, pixelColor_0_2, pixelColor_0_1, pixelColor_2_0, pixelColor_2_1, pixelColor_2_2, pixelColor_1_2, pixelColor_1_0;
            byte Ix, Iy;
            for (int i = 1; i < pictureBox_orjinal.Image.Width - 1; i++)
            {

                for (int j = 1; j < pictureBox_orjinal.Image.Height - 1; j++)
                {



                    pixelColor_1_1 = resimorjinal.GetPixel(i, j);

                    pixelColor_0_0 = resimorjinal.GetPixel(i - 1, j - 1);
                    pixelColor_0_2 = resimorjinal.GetPixel(i - 1, j + 1);
                    pixelColor_0_1 = resimorjinal.GetPixel(i - 1, j);

                    pixelColor_2_0 = resimorjinal.GetPixel(i + 1, j - 1);
                    pixelColor_2_2 = resimorjinal.GetPixel(i + 1, j + 1);
                    pixelColor_2_1 = resimorjinal.GetPixel(i + 1, j);

                    pixelColor_1_2 = resimorjinal.GetPixel(i, j + 1);
                    pixelColor_1_0 = resimorjinal.GetPixel(i, j - 1);



                    Ix = (byte)Math.Abs(
                        GX[0, 0] * pixelColor_0_0.R +
                        GX[0, 1] * pixelColor_0_1.R +
                        GX[0, 2] * pixelColor_0_2.R +
                        GX[1, 0] * pixelColor_1_0.R +
                        GX[1, 1] * pixelColor_1_1.R +
                        GX[1, 2] * pixelColor_1_2.R +
                        GX[2, 0] * pixelColor_2_0.R +
                        GX[2, 1] * pixelColor_2_1.R +
                        GX[2, 2] * pixelColor_2_2.R
                        );


                    Iy = (byte)Math.Abs(
                        GY[0, 0] * pixelColor_0_0.R +
                        GY[0, 1] * pixelColor_0_1.R +
                        GY[0, 2] * pixelColor_0_2.R +
                        GY[1, 0] * pixelColor_1_0.R +
                        GY[1, 1] * pixelColor_1_1.R +
                        GY[1, 2] * pixelColor_1_2.R +
                        GY[2, 0] * pixelColor_2_0.R +
                        GY[2, 1] * pixelColor_2_1.R +
                        GY[2, 2] * pixelColor_2_2.R
                        );


                    int toplam_kareleri;
                    int deger;
                    toplam_kareleri = Ix * Ix + Iy * Iy;
                    deger = Convert.ToInt32(Math.Sqrt(toplam_kareleri));
                    if (deger > 255) deger = 255;
                    if (deger < 0) deger = 0;
                    //sobel basılıyor
                    resimsobel.SetPixel(i, j, Color.FromArgb(deger, deger, deger));


                }
            }
                      
           
            pictureBox_sobel.Image = resimsobel;

           
            int x0, y0;
            double t;

            int[, ,] acu = new int[pictureBox_orjinal.Image.Width, pictureBox_orjinal.Image.Height, 5];

            for (int i = 1; i < pictureBox_orjinal.Image.Width - 1; i++)
            {

                for (int j = 1; j < pictureBox_orjinal.Image.Height - 1; j++)
                {
                    //R 25 ile 45 arasında
                    for (int r = 0; r < 5; r++)
                    {

                        for (int theta = 0; theta < 360; theta += 3)
                        {
                            int yaricap = ((r + 1) * 5 + 20);
                            t = ((double)theta * 3.14) / 180;
                            x0 = i + (int)(yaricap * Math.Cos(t));
                            y0 = j + (int)(yaricap * Math.Sin(t));
                            if (x0 > 0 && y0 > 0 && y0 < pictureBox_orjinal.Image.Height && x0 < pictureBox_orjinal.Image.Width)
                            {
                                acu[i, j, r] += resimsobel.GetPixel(x0, y0).R;
                            }
                        }//end for theta

                    }//end for r

                }
            }
            Bitmap resimhough = new Bitmap(pictureBox_orjinal.Image);

            for (int i = 1; i < pictureBox_orjinal.Image.Width - 1; i++)
            {

                for (int j = 1; j < pictureBox_orjinal.Image.Height - 1; j++)
                {
                    int topla_deger = 0;
                    for (int r = 0; r < 5; r++)
                    {
                        topla_deger += acu[i, j, r];
                    }
                    resimhough.SetPixel(i, j, Color.FromArgb((topla_deger / 500), (topla_deger / 500), (topla_deger / 500)));

                }
            }

            //hough space görüntüsü
            pictureBox_hough.Image = resimhough;


            int[] degerler_x = new int[50];
            int[] degerler_y = new int[50];
            int[] degerler_yaricap = new int[50];
            int enbuyuk = 0;
            int en_x = 0, en_y = 0;

            int esik = 0;
            for (int donme = 0; donme < 50; donme++)
            {
                enbuyuk = 0;
                for (int i = 1; i < pictureBox_orjinal.Image.Width - 1; i++)
                {

                    for (int j = 1; j < pictureBox_orjinal.Image.Height - 1; j++)
                    {
                        for (int r = 0; r < 5; r++)
                        {

                            if (acu[i, j, r] > enbuyuk)
                            {
                                enbuyuk = acu[i, j, r];
                                en_x = i;
                                en_y = j;
                                degerler_x[donme] = en_x;
                                degerler_y[donme] = en_y;
                                degerler_yaricap[donme] = ((r + 1) * 5 + 20);
                            }
                        }

                    }
                }
                if (enbuyuk < esik) { break; }
                if (donme == 0)
                {
                    //yüzde 90 benzemeli
                    esik = enbuyuk * (trackBar1.Value) / 100;
                }

                for (int theta = 0; theta < 360; theta++)
                {
                    for (int tarama_r = 0; tarama_r <= degerler_yaricap[donme] + 12; tarama_r++)
                    {
                        t = ((double)theta * 3.14) / 180;
                        x0 = en_x - (int)(tarama_r * Math.Cos(t));
                        y0 = en_y - (int)(tarama_r * Math.Sin(t));

                        if (x0 > 0 && y0 > 0 && y0 < pictureBox_orjinal.Image.Height && x0 < pictureBox_orjinal.Image.Width)
                        {
                            acu[x0, y0, 0] = 0;
                            acu[x0, y0, 1] = 0;
                            acu[x0, y0, 2] = 0;
                            acu[x0, y0, 3] = 0;
                        }
                    }
                }








            }

            //daireler çizdiriliyor
            for (int donme = 0; donme < 50; donme++)
            {
                if (degerler_x[donme] != 0 && degerler_y[donme] != 0)
                {
                    pictureBox_sonuc.Image = daire_ciz(degerler_x[donme], degerler_y[donme], degerler_yaricap[donme], resimorjinal);
                }
                else
                {
                    break;
                }
            }
        }
        public Bitmap daire_ciz(int a, int b, int r, Bitmap resimimiz)
        {
            int x0, y0;
            double t;

            for (int theta = 0; theta < 360; theta++)
            {

                t = ((double)theta * 3.141592653) / 180;
                x0 = a - (int)(r * Math.Cos(t));
                y0 = b - (int)(r * Math.Sin(t));

                if (x0 > 0 && y0 > 0 && y0 < resimimiz.Height && x0 < resimimiz.Width)
                {
                    resimimiz.SetPixel(x0, y0, Color.Red);

                }

            }
            return resimimiz;

        }


        private void buttonislegoster_Click(object sender, EventArgs e)
        {

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
          
            

            
            gurultu();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime =  ts.Seconds.ToString() +":"+ (ts.Milliseconds / 10).ToString();
            
            this.Text = "Adem KÖSE 279980    İcra Zamanı : "+elapsedTime;





        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            Bitmap resim = new Bitmap(pictureBox_orjinal.Image);
            Color pixelColor_gx = resim.GetPixel(e.X, e.Y);
            MessageBox.Show(pixelColor_gx.R.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Bitmap resim = new Bitmap(pictureBox1.Image);
            //pictureBox1.Image=DrawCircle(resim, 50, 10, 20, Color.Blue);
        }

        public static Bitmap DrawCircle(Bitmap image, int centerX, int centerY, int radius, Color color)
        {

            int d = (5 - radius * 4) / 4;
            int x = 0;
            int y = radius;

            do
            {
                // ensure index is in range before setting (depends on your image implementation)
                // in this case we check if the pixel location is within the bounds of the image before setting the pixel
                if (centerX + x >= 0 && centerX + x <= image.Width - 1 && centerY + y >= 0 && centerY + y <= image.Height - 1) image.SetPixel(centerX + x, centerY + y, color);
                if (centerX + x >= 0 && centerX + x <= image.Width - 1 && centerY - y >= 0 && centerY - y <= image.Height - 1) image.SetPixel(centerX + x, centerY - y, color);
                if (centerX - x >= 0 && centerX - x <= image.Width - 1 && centerY + y >= 0 && centerY + y <= image.Height - 1) image.SetPixel(centerX - x, centerY + y, color);
                if (centerX - x >= 0 && centerX - x <= image.Width - 1 && centerY - y >= 0 && centerY - y <= image.Height - 1) image.SetPixel(centerX - x, centerY - y, color);
                if (centerX + y >= 0 && centerX + y <= image.Width - 1 && centerY + x >= 0 && centerY + x <= image.Height - 1) image.SetPixel(centerX + y, centerY + x, color);
                if (centerX + y >= 0 && centerX + y <= image.Width - 1 && centerY - x >= 0 && centerY - x <= image.Height - 1) image.SetPixel(centerX + y, centerY - x, color);
                if (centerX - y >= 0 && centerX - y <= image.Width - 1 && centerY + x >= 0 && centerY + x <= image.Height - 1) image.SetPixel(centerX - y, centerY + x, color);
                if (centerX - y >= 0 && centerX - y <= image.Width - 1 && centerY - x >= 0 && centerY - x <= image.Height - 1) image.SetPixel(centerX - y, centerY - x, color);
                if (d < 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    d += 2 * (x - y) + 1;
                    y--;
                }
                x++;
            } while (x <= y);
            return image;

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label_hough_benzerlik.Text = "Hough Benzerlik %" + trackBar1.Value;
        }

    }
}
