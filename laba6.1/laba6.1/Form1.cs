using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba6._1
{
    public partial class Form1 : Form
    {
        int counter = 0;
        Bitmap bmp;
        Graphics graph;
        public Form1()
        {
            InitializeComponent();
        }
        private void Draw()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (graph = Graphics.FromImage(bmp))
            {
                using (Pen penblue = new Pen(Color.Blue))
                {
                    using (Pen penwhite = new Pen(Color.White))
                    {
                        using (SolidBrush brushbue = new SolidBrush(Color.Blue))
                        {
                            if (counter > 0)
                            {

                                graph.FillRectangle(brushbue, 100, 50, 70, 100);


                                pictureBox1.Image = bmp;
                            }
                            
                            if (counter > 1)
                            {
                                RectangleF highrec = new RectangleF(100, 20, 70, 60);
                               
                                RectangleF lowrec = new RectangleF(100, 120, 70, 60);

                                    graph.FillEllipse(brushbue, lowrec);
                                    graph.FillEllipse(brushbue, highrec);
                                    pictureBox1.Image = bmp;
                                
                            }
                        }
                        if (counter > 2)
                        {
                            graph.DrawLine(penwhite, 125, 40, 125, 150);
                            pictureBox1.Image = bmp;
                        }
                        if (counter > 3)
                        {
                            graph.DrawLine(penwhite, 125, 40, 155, 70);
                            graph.DrawLine(penwhite, 125, 150, 155, 120);
                            pictureBox1.Image = bmp;
                        }
                        if (counter > 4)
                        {
                            graph.DrawLine(penwhite, 155, 70, 110, 110);
                            graph.DrawLine(penwhite, 155, 120, 110, 85);
                            pictureBox1.Image = bmp;
                            button1.Enabled = false;
                        }
                    }
                }
            }
        }
    

            

                            
        private void Button1_Click(object sender, EventArgs e)
        {
            Draw();
            counter++;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            counter = 0;
            button1.Enabled = true;
        }
        About a;
        private void Button2_Click(object sender, EventArgs e)
        {
            if ((a == null) || (a.IsDisposed))
            {
                a = new About();
                a.Show();
            }
        }
        Help h;
        private void Button3_Click(object sender, EventArgs e)
        {
            if ((h == null) || (h.IsDisposed))
            {
                h = new Help();
                h.Show();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
