using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorDiff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            // read image
            Bitmap bmp = new Bitmap("F:\\Scientific Instrumentation\\Master Thesis\\Work Student Projects\\Error Diffusion\\A380.jpg");

            //load original image in picturebox1
            pictureBox1.Image = Image.FromFile("F:\\Scientific Instrumentation\\Master Thesis\\Work Student Projects\\Error Diffusion\\A380.jpg");

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //color of pixel
            Color p, q;

            //Image Quantization
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    p = bmp.GetPixel(x, y);

                    //extract pixel component ARGB
                    int a = p.A;
                    float r = p.R;
                    float g = p.G;
                    float b = p.B;

                    //Quantizing Gray Scale Image
                    int R, G, B;
                    if (r < 127)
                    { R = 0; }
                    else
                    { R = 255; }

                    if (g < 127)
                    { G = 0; }
                    else
                    { G = 255; }

                    if (b < 127)
                    { B = 0; }
                    else
                    { B = 255; }



                    //set new pixel value
                    bmp.SetPixel(x, y, Color.FromArgb(a, R, G, B));
                    
                }
            }

            //load Quantized image in picturebox2
            pictureBox2.Image = bmp;

            //write the Quantized image
            bmp.Save("F:\\Scientific Instrumentation\\Master Thesis\\Work Student Projects\\Error Diffusion\\A380BW.jpg");



        }

    }
}
