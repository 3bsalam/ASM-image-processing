using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CsharpGUI
{
    public partial class Form1 : Form
    {
        [DllImport("Project.dll")]
        private static extern void Brightness([In, Out]int[] arr, int sz, int value);

        [DllImport("Project.dll")]
        private static extern void GrayScale([In, Out]int[] arrR, [In]int[] arrG, [In]int[] arrB, int sz);


        public Form1()
        {
            InitializeComponent();
        }
        operation.RGBPixel[,] image;

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the browsed image and display it
                string OpenedFilePath = openFileDialog1.FileName;
                image = operation.OpenImage(OpenedFilePath);
                operation.DisplayImage(image, pictureBox1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int size = image.GetLength(0) * image.GetLength(1);
            int[] red = new int[size];
            int[] blue = new int[size];
            int[] green = new int[size];
            int x = 0;
            for(int i = 0; i < image.GetLength(0); i++)
            {
                for(int j = 0; j < image.GetLength(1); j++)
                {
                    red[x] = image[i, j].red;
                    green[x] = image[i, j].green;
                    blue[x] = image[i, j].blue;
                    x++;
                }
            }
            /////
            Brightness(red, size, 100);
            Brightness(blue, size, 100);
            Brightness(green, size, 100);

            x = 0;
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    image[i, j].red = (byte)red[x];
                    image[i, j].green = (byte)green[x];
                    image[i, j].blue = (byte)blue[x];
                    x++;
                }
            }
            operation.DisplayImage(image, yasser);
        }

        private void GrayScale_Click(object sender, EventArgs e)
        {
            int size = image.GetLength(0) * image.GetLength(1);
            int[] red = new int[size];
            int[] blue = new int[size];
            int[] green = new int[size];
            int x = 0;
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    red[x] = image[i, j].red;
                    green[x] = image[i, j].green;
                    blue[x] = image[i, j].blue;
                    x++;
                }
            }

            GrayScale(red,green,blue,size);

            x = 0;
            for (int i = 0; i < image.GetLength(0); i++)
            {
                for (int j = 0; j < image.GetLength(1); j++)
                {
                    image[i, j].red = (byte)red[x];
                    image[i, j].green = (byte)red[x];
                    image[i, j].blue = (byte)red[x];
                    x++;
                }
            }
            operation.DisplayImage(image, yasser);



        }
    }
}
