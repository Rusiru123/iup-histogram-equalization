using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistogramEqualization
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd = new OpenFileDialog();
        HistogramEqualizationMeasure hem = new HistogramEqualizationMeasure();

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenImage_Click(object sender, EventArgs e)
        {
            ofd.Title = "Choose Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            hem.OpenInitialImage(ofd.FileName);
            string picturePath = ofd.FileName.ToString();
            InitialImage.SizeMode = PictureBoxSizeMode.StretchImage;
            InitialImage.ImageLocation = picturePath;
        }

        private void processHistogram_Click(object sender, EventArgs e)
        {
            hem.createHistogram();
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = "newHisto.jpg";
        }

        private void equalizingHistogram_Click(object sender, EventArgs e)
        {
            hem.createEqualizedHistogram();
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.ImageLocation = "newHistoMode1.jpg";
            pictureBox3.ImageLocation = "newHistoMode2.jpg";
        }
    }
}
