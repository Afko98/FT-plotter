using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Graphics g;
        Graphics g2;
        bool mouse_down = false;
        int[] time_function = new int[450];
        double[] abs_function = new double[450];
        double[] f_re = new double[450];
        double[] f_im = new double[450];
        Pen pen,pen_red;
        bool abs = true, re = false, im = false;
        int lastIndex = 0;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g2 = panel2.CreateGraphics();
            g2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 1);
            pen_red = new Pen(Color.Red, 1);
        }
     
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g.DrawLine(pen_red, new Point(0, 200), new Point(450, 200));
            g.DrawLine(pen_red, new Point(225, 0), new Point(225, 400));
            for (int i=0; i < 450; i++)
            {
                time_function[i] = 200;
            }
        }
        private void addGrid()
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            g2.DrawLine(pen_red, new Point(0, 200), new Point(450, 200));
            g2.DrawLine(pen_red, new Point(225, 0), new Point(225, 400));
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (mouse_down)
            {
                time_function[e.X] =e.Y;
                g.DrawLine(pen, new Point(e.X, time_function[e.X]), new Point(e.X - 1, time_function[e.X - 1]));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            abs = true;
            im = false;
            re = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            re = true;
            abs = false;
            im = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            im = true;
            re = false;
            abs = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 450; i++)
                time_function[i] = (int)(200+100*Math.Sin(0.05f * (i - 225)));
            mouse_down = false;
            g.Clear(Color.White);
            g.DrawLine(pen_red, new Point(0, 200), new Point(450, 200));
            g.DrawLine(pen_red, new Point(225, 0), new Point(225, 400));
            for (int i = 0; i < 450; i++)
            {
                if (i > 0)
                    g.DrawLine(pen, new Point(i, time_function[i]), new Point(i - 1, time_function[i]));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            g.DrawLine(pen_red, new Point(0, 200), new Point(450, 200));
            g.DrawLine(pen_red, new Point(225, 0), new Point(225, 400));
            for (int i = 0; i < 450; i++)
            {
                time_function[i] = 200;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f_re = new double[450];
            f_im = new double[450];
            for (int i = 0; i < 450; i++)
            {
                for (int j = 0; j < 450; j++)
                {
                    f_re[i] = f_re[i] + ((double)(200 - time_function[j]) * Math.Cos((double)(i - 225) * j*0.0005f));
                    f_im[i] = f_im[i] - ((double)(200 - time_function[j]) * Math.Sin((double)(i - 225) * j*0.0005f));
                }
                abs_function[i] = Math.Sqrt(Math.Pow(f_re[i], 2) + Math.Pow(f_im[i], 2))/200f;
            }
            g2.Clear(Color.White);
            g2.DrawLine(pen_red, new Point(0, 200), new Point(450, 200));
            g2.DrawLine(pen_red, new Point(225, 0), new Point(225, 400));
            if (abs)
                for (int i = 0; i < 450; i++)
                {
                    if (i > 0)
                        g2.DrawLine(pen, new Point(i, (int)(200-abs_function[i])), new Point(i - 1, (int)(200-abs_function[i])));
                }
            if(re)
                for (int i = 0; i < 450; i++)
                {
                    if (i > 0)
                        g2.DrawLine(pen, new Point(i, (int)(200 - (f_re[i] / 200f))), new Point(i - 1, (int)(200 - (f_re[i] / 200f))));
                }
            if(im)
                for (int i = 0; i < 450; i++)
                {
                    if (i > 0)
                        g2.DrawLine(pen, new Point(i, (int)(200 - (f_im[i] / 200f))), new Point(i - 1, (int)(200 - (f_im[i]/200f))));
                }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
            g.Clear(Color.White);
            g.DrawLine(pen_red, new Point(0, 200), new Point(450, 200));
            g.DrawLine(pen_red, new Point(225, 0), new Point(225, 400));
            for (int i = 0; i < 450; i++)
            {
                if (i > 0)
                    g.DrawLine(pen, new Point(i, time_function[i]), new Point(i - 1, time_function[i]));
            }
        }
    }
}
