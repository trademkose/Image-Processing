namespace goruntu_isleme_okuma
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_orjinal = new System.Windows.Forms.PictureBox();
            this.buttonyukle = new System.Windows.Forms.Button();
            this.buttonislegoster = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox_sobel = new System.Windows.Forms.PictureBox();
            this.pictureBox_sonuc = new System.Windows.Forms.PictureBox();
            this.pictureBox_hough = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label_hough_benzerlik = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_orjinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sobel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sonuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hough)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_orjinal
            // 
            this.pictureBox_orjinal.Image = global::goruntu_isleme_okuma.Properties.Resources.image;
            this.pictureBox_orjinal.Location = new System.Drawing.Point(12, 76);
            this.pictureBox_orjinal.Name = "pictureBox_orjinal";
            this.pictureBox_orjinal.Size = new System.Drawing.Size(386, 256);
            this.pictureBox_orjinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_orjinal.TabIndex = 0;
            this.pictureBox_orjinal.TabStop = false;
            this.pictureBox_orjinal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox_orjinal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // buttonyukle
            // 
            this.buttonyukle.Location = new System.Drawing.Point(12, 12);
            this.buttonyukle.Name = "buttonyukle";
            this.buttonyukle.Size = new System.Drawing.Size(75, 23);
            this.buttonyukle.TabIndex = 1;
            this.buttonyukle.Text = "Yükle";
            this.buttonyukle.UseVisualStyleBackColor = true;
            this.buttonyukle.Click += new System.EventHandler(this.buttonyukle_Click);
            // 
            // buttonislegoster
            // 
            this.buttonislegoster.Location = new System.Drawing.Point(111, 12);
            this.buttonislegoster.Name = "buttonislegoster";
            this.buttonislegoster.Size = new System.Drawing.Size(75, 23);
            this.buttonislegoster.TabIndex = 2;
            this.buttonislegoster.Text = "İşle Göster";
            this.buttonislegoster.UseVisualStyleBackColor = true;
            this.buttonislegoster.Click += new System.EventHandler(this.buttonislegoster_Click);
            // 
            // pictureBox_sobel
            // 
            this.pictureBox_sobel.Location = new System.Drawing.Point(415, 76);
            this.pictureBox_sobel.Name = "pictureBox_sobel";
            this.pictureBox_sobel.Size = new System.Drawing.Size(386, 256);
            this.pictureBox_sobel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_sobel.TabIndex = 3;
            this.pictureBox_sobel.TabStop = false;
            // 
            // pictureBox_sonuc
            // 
            this.pictureBox_sonuc.Location = new System.Drawing.Point(415, 365);
            this.pictureBox_sonuc.Name = "pictureBox_sonuc";
            this.pictureBox_sonuc.Size = new System.Drawing.Size(386, 264);
            this.pictureBox_sonuc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_sonuc.TabIndex = 4;
            this.pictureBox_sonuc.TabStop = false;
            // 
            // pictureBox_hough
            // 
            this.pictureBox_hough.Location = new System.Drawing.Point(12, 365);
            this.pictureBox_hough.Name = "pictureBox_hough";
            this.pictureBox_hough.Size = new System.Drawing.Size(386, 264);
            this.pictureBox_hough.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_hough.TabIndex = 5;
            this.pictureBox_hough.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ham Görüntü - Orjinal Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(212, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sobel Kenar Tespiti - Sobel Edge Detection";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 349);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "2B Hough Uzayı -2D Hough Space";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Çember Tespiti - Circle Detection";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(396, 9);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 30;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(431, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Value = 85;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label_hough_benzerlik
            // 
            this.label_hough_benzerlik.AutoSize = true;
            this.label_hough_benzerlik.Location = new System.Drawing.Point(233, 17);
            this.label_hough_benzerlik.Name = "label_hough_benzerlik";
            this.label_hough_benzerlik.Size = new System.Drawing.Size(152, 13);
            this.label_hough_benzerlik.TabIndex = 11;
            this.label_hough_benzerlik.Text = "Hough Benzerlik Oranı (Yüzde)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 648);
            this.Controls.Add(this.label_hough_benzerlik);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_hough);
            this.Controls.Add(this.buttonislegoster);
            this.Controls.Add(this.buttonyukle);
            this.Controls.Add(this.pictureBox_sonuc);
            this.Controls.Add(this.pictureBox_sobel);
            this.Controls.Add(this.pictureBox_orjinal);
            this.Controls.Add(this.trackBar1);
            this.Name = "Form1";
            this.Text = "Adem KÖSE 279980";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_orjinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sobel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_sonuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_hough)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_orjinal;
        private System.Windows.Forms.Button buttonyukle;
        private System.Windows.Forms.Button buttonislegoster;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox_sobel;
        private System.Windows.Forms.PictureBox pictureBox_sonuc;
        private System.Windows.Forms.PictureBox pictureBox_hough;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label_hough_benzerlik;
    }
}

