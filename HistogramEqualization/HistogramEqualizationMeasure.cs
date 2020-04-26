using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace HistogramEqualization
{

    class HistogramEqualizationMeasure
    {
        IplImage srcImage;
        IplImage grayscaleImage;
        IplImage histogramImage;
        IplImage redImage;
        IplImage greenImage;
        IplImage blueImage;
        IplImage grayscaleRed, grayscaleGreen, grayscaleBlue;

        public void OpenInitialImage(string fileName)
        {
            srcImage = Cv.LoadImage(fileName, LoadMode.Color);
            Cv.SaveImage(fileName, srcImage);
        }

        public void convertionGrayScale()
        {
            grayscaleImage = Cv.CreateImage(srcImage.Size, BitDepth.U8, 1);
            Cv.CvtColor(srcImage,grayscaleImage, ColorConversion.RgbToGray);
            Cv.SaveImage("second.jpg", grayscaleImage);
        }

        public void colorConversion(string fileName)
        {
            srcImage = Cv.LoadImage(fileName, LoadMode.Color);
            redImage = new IplImage(srcImage.Size, srcImage.Depth, srcImage.NChannels);
            greenImage = new IplImage(srcImage.Size, srcImage.Depth, srcImage.NChannels);
            blueImage = new IplImage(srcImage.Size, srcImage.Depth, srcImage.NChannels);

            for (var p = 0; p < srcImage.Height; p++)
            {
                for (var q = 0; q < srcImage.Width; q++)
                {
                    CvColor pixels = srcImage[p, q];
                    redImage[p, q] = new CvColor
                    {
                        R = (byte)(255 - pixels.R)
                    };
                    greenImage[p, q] = new CvColor
                    {
                        G = (byte)(255 - pixels.G)
                    };
                    blueImage[p, q] = new CvColor
                    {
                        B = (byte)(255 - pixels.B)
                    };

                }
            }

            Cv.SaveImage("red.jpg", redImage);
            Cv.SaveImage("green.jpg", greenImage);
            Cv.SaveImage("blue.jpg", blueImage);

            float[] range = { 0, 255 };
            float[][] ranges = { range };

            int histogramSize = 255;

            float minimumValue, maximumValue = 0;

            grayscaleRed = Cv.CreateImage(redImage.Size, BitDepth.U8, 1);
            Cv.CvtColor(redImage, grayscaleRed, ColorConversion.RgbToGray);

            grayscaleGreen = Cv.CreateImage(greenImage.Size, BitDepth.U8, 1);
            Cv.CvtColor(greenImage, grayscaleGreen, ColorConversion.RgbToGray);

            grayscaleBlue = Cv.CreateImage(blueImage.Size, BitDepth.U8, 1);
            Cv.CvtColor(blueImage, grayscaleBlue, ColorConversion.RgbToGray);

            CvHistogram histogramR = Cv.CreateHist(new int[] { histogramSize }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayscaleRed, histogramR);
            Cv.GetMinMaxHistValue(histogramR, out minimumValue, out maximumValue);
            Cv.Scale(histogramR.Bins, histogramR.Bins, ((double)redImage.Height) / maximumValue, 0);
            redImage.Set(CvColor.White);

            CvHistogram histogramG = Cv.CreateHist(new int[] { histogramSize }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayscaleGreen, histogramG);
            Cv.GetMinMaxHistValue(histogramG, out minimumValue, out maximumValue);
            Cv.Scale(histogramG.Bins, histogramG.Bins, ((double)greenImage.Height) / maximumValue, 0);
            greenImage.Set(CvColor.White);

            CvHistogram histogramB = Cv.CreateHist(new int[] { histogramSize }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayscaleBlue, histogramB);
            Cv.GetMinMaxHistValue(histogramB, out minimumValue, out maximumValue);
            Cv.Scale(histogramB.Bins, histogramB.Bins, ((double)blueImage.Height) / maximumValue, 0);
            blueImage.Set(CvColor.White);

            int bin_red = Cv.Round((double)redImage.Width / histogramSize);
            int bin_green = Cv.Round((double)greenImage.Width / histogramSize);
            int bin_blue = Cv.Round((double)blueImage.Width / histogramSize);


            int r;

            for (r = 0; r < histogramSize; r++)
            {
                redImage.Rectangle(new CvPoint(r * bin_red, grayscaleRed.Height), new CvPoint((r + 1) * bin_red, grayscaleRed.Height - Cv.Round(histogramR.Bins[r])), CvColor.Black, -1, LineType.Link8, 0);
            }

            int g;

            for (g = 0; g < histogramSize; g++)
            {
                greenImage.Rectangle(new CvPoint(g * bin_green, grayscaleGreen.Height), new CvPoint((r + 1) * bin_green, grayscaleGreen.Height - Cv.Round(histogramG.Bins[g])), CvColor.Black, -1, LineType.Link8, 0);
            }

            int b;

            for (b = 0; b < histogramSize; b++)
            {
                blueImage.Rectangle(new CvPoint(b * bin_blue, grayscaleBlue.Height), new CvPoint((r + 1) * bin_blue, grayscaleBlue.Height - Cv.Round(histogramR.Bins[b])), CvColor.Black, -1, LineType.Link8, 0);
            }

            Cv.SaveImage("histogramRed.jpg", redImage);
            Cv.SaveImage("histogramGreen.jpg", greenImage);
            Cv.SaveImage("histogramBlue.jpg", blueImage);
        }

        public void createHistogram()
        {
            float[] range = { 0, 255 };
            float[][] ranges = { range };

            int histogramSize = 255;

            float minimumValue, maximumValue = 0;

            histogramImage = Cv.CreateImage(srcImage.Size,BitDepth.U8, 1);

            convertionGrayScale();

            CvHistogram histogramR = Cv.CreateHist(new int[] { histogramSize }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayscaleImage, histogramR);
            Cv.GetMinMaxHistValue(histogramR, out minimumValue, out minimumValue);
            Cv.Scale(histogramR.Bins, histogramR.Bins, ((double)histogramImage.Height) / maximumValue, 0);
            histogramImage.Set(CvColor.White);
            int bin_red = Cv.Round((double)histogramImage.Width / histogramSize);

            int r;

            for (r = 0; r < histogramSize; r++)
            {
                histogramImage.Rectangle(
                      new CvPoint(r * bin_red, grayscaleImage.Height),
                      new CvPoint((r + 1) * bin_red, grayscaleImage.Height - Cv.Round(histogramR.Bins[r])), CvColor.Black, -1, LineType.Link8, 0);
            }
            Cv.SaveImage("newHisto.jpg", histogramImage);
        }

            public void createEqualizedHistogram()
        {
            float[] range = { 0, 255 };
            float[][] ranges = { range };

            int histogramSize = 255;

            float minimumValue, maximumValue = 0;

            histogramImage = Cv.CreateImage(srcImage.Size, BitDepth.U8, 1);
            convertionGrayScale();

            Cv.EqualizeHist(grayscaleImage, grayscaleImage);

            CvHistogram histogramR = Cv.CreateHist(new int[] { histogramSize }, HistogramFormat.Array, ranges, true);
            Cv.CalcHist(grayscaleImage, histogramR);
            Cv.GetMinMaxHistValue(histogramR, out minimumValue, out maximumValue);
            Cv.Scale(histogramR.Bins, histogramR.Bins, ((double)histogramImage.Height) / maximumValue, 0);
            histogramImage.Set(CvColor.White);
            int bin_red = Cv.Round((double)histogramImage.Width / histogramSize);

            int r;
            for (r = 0; r < histogramSize; r++)
            {
                histogramImage.Rectangle(new CvPoint(r * bin_red, grayscaleImage.Height), new CvPoint((r + 1) * bin_red, grayscaleImage.Height - Cv.Round(histogramR.Bins[r])), CvColor.Black, -1, LineType.Link8, 0);
            }

            Cv.SaveImage("newHistoMode1.jpg", histogramImage);
            Cv.SaveImage("newHistoMode2.jpg", grayscaleImage);
        }

    }
}
