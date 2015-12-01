namespace _279980_Proje4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_labeling = new System.Windows.Forms.PictureBox();
            this.pictureBox_aobject = new System.Windows.Forms.PictureBox();
            this.pictureBox_odsu = new System.Windows.Forms.PictureBox();
            this.pictureBox_orjinal = new System.Windows.Forms.PictureBox();
            this.button_odsu = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_nesne_saiyisi = new System.Windows.Forms.Label();
            this.button_resimyukle = new System.Windows.Forms.Button();
            this.button_etiketleme = new System.Windows.Forms.Button();
            this.button_moment = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_labeling)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aobject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_odsu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_orjinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(412, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Bir Nesne- A Object";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Etiketleme - Labeling";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Odsu Binary ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ham Görüntü - Orjinal Image";
            // 
            // pictureBox_labeling
            // 
            this.pictureBox_labeling.Location = new System.Drawing.Point(12, 321);
            this.pictureBox_labeling.Name = "pictureBox_labeling";
            this.pictureBox_labeling.Size = new System.Drawing.Size(386, 264);
            this.pictureBox_labeling.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_labeling.TabIndex = 13;
            this.pictureBox_labeling.TabStop = false;
            // 
            // pictureBox_aobject
            // 
            this.pictureBox_aobject.Location = new System.Drawing.Point(415, 321);
            this.pictureBox_aobject.Name = "pictureBox_aobject";
            this.pictureBox_aobject.Size = new System.Drawing.Size(386, 264);
            this.pictureBox_aobject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_aobject.TabIndex = 12;
            this.pictureBox_aobject.TabStop = false;
            // 
            // pictureBox_odsu
            // 
            this.pictureBox_odsu.Location = new System.Drawing.Point(415, 32);
            this.pictureBox_odsu.Name = "pictureBox_odsu";
            this.pictureBox_odsu.Size = new System.Drawing.Size(386, 256);
            this.pictureBox_odsu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_odsu.TabIndex = 11;
            this.pictureBox_odsu.TabStop = false;
            // 
            // pictureBox_orjinal
            // 
            this.pictureBox_orjinal.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_orjinal.Image")));
            this.pictureBox_orjinal.Location = new System.Drawing.Point(12, 32);
            this.pictureBox_orjinal.Name = "pictureBox_orjinal";
            this.pictureBox_orjinal.Size = new System.Drawing.Size(386, 256);
            this.pictureBox_orjinal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_orjinal.TabIndex = 10;
            this.pictureBox_orjinal.TabStop = false;
            // 
            // button_odsu
            // 
            this.button_odsu.Location = new System.Drawing.Point(1095, 312);
            this.button_odsu.Name = "button_odsu";
            this.button_odsu.Size = new System.Drawing.Size(108, 23);
            this.button_odsu.TabIndex = 19;
            this.button_odsu.Text = "Başlat";
            this.button_odsu.UseVisualStyleBackColor = true;
            this.button_odsu.Click += new System.EventHandler(this.button_odsu_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(817, 1);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.Size = new System.Drawing.Size(386, 256);
            this.chart1.TabIndex = 22;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // label_nesne_saiyisi
            // 
            this.label_nesne_saiyisi.AutoSize = true;
            this.label_nesne_saiyisi.Location = new System.Drawing.Point(819, 268);
            this.label_nesne_saiyisi.Name = "label_nesne_saiyisi";
            this.label_nesne_saiyisi.Size = new System.Drawing.Size(35, 13);
            this.label_nesne_saiyisi.TabIndex = 23;
            this.label_nesne_saiyisi.Text = "label5";
            // 
            // button_resimyukle
            // 
            this.button_resimyukle.Location = new System.Drawing.Point(1095, 341);
            this.button_resimyukle.Name = "button_resimyukle";
            this.button_resimyukle.Size = new System.Drawing.Size(108, 23);
            this.button_resimyukle.TabIndex = 18;
            this.button_resimyukle.Text = "Orjinal Resim Yükle";
            this.button_resimyukle.UseVisualStyleBackColor = true;
            this.button_resimyukle.Click += new System.EventHandler(this.button_resimyukle_Click);
            // 
            // button_etiketleme
            // 
            this.button_etiketleme.Location = new System.Drawing.Point(1095, 370);
            this.button_etiketleme.Name = "button_etiketleme";
            this.button_etiketleme.Size = new System.Drawing.Size(108, 23);
            this.button_etiketleme.TabIndex = 20;
            this.button_etiketleme.Text = "Etiketleme";
            this.button_etiketleme.UseVisualStyleBackColor = true;
            this.button_etiketleme.Click += new System.EventHandler(this.button_etiketleme_Click);
            // 
            // button_moment
            // 
            this.button_moment.Location = new System.Drawing.Point(1095, 399);
            this.button_moment.Name = "button_moment";
            this.button_moment.Size = new System.Drawing.Size(108, 23);
            this.button_moment.TabIndex = 21;
            this.button_moment.Text = "Moment";
            this.button_moment.UseVisualStyleBackColor = true;
            this.button_moment.Click += new System.EventHandler(this.button_moment_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(817, 314);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(262, 271);
            this.richTextBox1.TabIndex = 24;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1227, 597);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label_nesne_saiyisi);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button_moment);
            this.Controls.Add(this.button_etiketleme);
            this.Controls.Add(this.button_odsu);
            this.Controls.Add(this.button_resimyukle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_labeling);
            this.Controls.Add(this.pictureBox_aobject);
            this.Controls.Add(this.pictureBox_odsu);
            this.Controls.Add(this.pictureBox_orjinal);
            this.Name = "Form1";
            this.Text = "ADEM KÖSE 279980";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_labeling)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_aobject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_odsu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_orjinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_labeling;
        private System.Windows.Forms.PictureBox pictureBox_aobject;
        private System.Windows.Forms.PictureBox pictureBox_odsu;
        private System.Windows.Forms.PictureBox pictureBox_orjinal;
        private System.Windows.Forms.Button button_odsu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label_nesne_saiyisi;
        private System.Windows.Forms.Button button_resimyukle;
        private System.Windows.Forms.Button button_etiketleme;
        private System.Windows.Forms.Button button_moment;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

