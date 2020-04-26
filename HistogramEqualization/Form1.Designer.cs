namespace HistogramEqualization
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
            this.InitialImage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.OpenImage = new System.Windows.Forms.Button();
            this.processHistogram = new System.Windows.Forms.Button();
            this.equalizingHistogram = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.InitialImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // InitialImage
            // 
            this.InitialImage.Location = new System.Drawing.Point(30, 12);
            this.InitialImage.Name = "InitialImage";
            this.InitialImage.Size = new System.Drawing.Size(288, 318);
            this.InitialImage.TabIndex = 0;
            this.InitialImage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(348, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(266, 318);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(640, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(259, 318);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(929, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(261, 318);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // OpenImage
            // 
            this.OpenImage.Location = new System.Drawing.Point(217, 415);
            this.OpenImage.Name = "OpenImage";
            this.OpenImage.Size = new System.Drawing.Size(232, 78);
            this.OpenImage.TabIndex = 4;
            this.OpenImage.Text = "Open Image";
            this.OpenImage.UseVisualStyleBackColor = true;
            this.OpenImage.Click += new System.EventHandler(this.OpenImage_Click);
            // 
            // processHistogram
            // 
            this.processHistogram.Location = new System.Drawing.Point(510, 415);
            this.processHistogram.Name = "processHistogram";
            this.processHistogram.Size = new System.Drawing.Size(227, 78);
            this.processHistogram.TabIndex = 5;
            this.processHistogram.Text = "Process Histogram";
            this.processHistogram.UseVisualStyleBackColor = true;
            this.processHistogram.Click += new System.EventHandler(this.processHistogram_Click);
            // 
            // equalizingHistogram
            // 
            this.equalizingHistogram.Location = new System.Drawing.Point(836, 415);
            this.equalizingHistogram.Name = "equalizingHistogram";
            this.equalizingHistogram.Size = new System.Drawing.Size(203, 78);
            this.equalizingHistogram.TabIndex = 6;
            this.equalizingHistogram.Text = "equalizing Histogram";
            this.equalizingHistogram.UseVisualStyleBackColor = true;
            this.equalizingHistogram.Click += new System.EventHandler(this.equalizingHistogram_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 549);
            this.Controls.Add(this.equalizingHistogram);
            this.Controls.Add(this.processHistogram);
            this.Controls.Add(this.OpenImage);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.InitialImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InitialImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox InitialImage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button OpenImage;
        private System.Windows.Forms.Button processHistogram;
        private System.Windows.Forms.Button equalizingHistogram;
    }
}

