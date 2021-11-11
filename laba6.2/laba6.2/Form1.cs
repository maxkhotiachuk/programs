using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba6._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            textBox2.Enabled = false;
        }
        double a;
        double b;
        bool check;
        private void Button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Cassini_Oval"].Points.Clear();
            chart1.Series["Cassini_Oval2"].Points.Clear();
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.ChartAreas[0].AxisX.Title = "R";
            chart1.ChartAreas[0].AxisY.Title = "Ѳ";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;

            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);

            double r;
            if (a < 0 || b < 0)
                MessageBox.Show("а або b < 0");
            else 
            {
                    for (double x = -Math.Pow(Math.Abs(b * b - a * a), 0.5) - b - a; x <= Math.Pow(Math.Abs(b * b - a * a), 0.5) + b + a; x += 0.005)
                    {
                        r = Math.Pow(Math.Pow(Math.Pow(b, 4) + 4 * Math.Pow(x * a, 2), 0.5) - x * x - a * a, 0.5);
                        chart1.Series["Cassini_Oval"].Points.AddXY(x, r); 
                        r = -Math.Pow(Math.Pow(Math.Pow(b, 4) + 4 * Math.Pow(x * a, 2), 0.5) - x * x - a * a, 0.5);
                        chart1.Series["Cassini_Oval2"].Points.AddXY(x, r); 

                    }

            }
        }
        ~Form1()
        {
            Dispose();
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            }
            if (checkBox1.Checked)
            {
                chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
            }
        }
        Help h;
        private void Button2_Click(object sender, EventArgs e)
        {
            if ((h == null) || (h.IsDisposed))
            {
                h = new Help();
                h.Show();
            }
        }
        About ab;
        private void Button4_Click(object sender, EventArgs e)
        {
            if ((ab == null) || (ab.IsDisposed))
            {
                ab = new About();
                ab.Show();
            }
        }

        private void Check(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == ',' || e.KeyChar == '.') && !(sender as TextBox).Text.Contains(','))
                e.KeyChar = ',';
            else if (!(Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
                e.Handled = true;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }    

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {

            Check(sender, e);
            if (textBox1.Text != String.Empty)
            {
                textBox2.Enabled = true;
            }
            else
            {
                textBox2.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Check(sender,e);
            if(textBox2.Text != String.Empty)
            {
                button1.Enabled = true;
            }
            else
            button1.Enabled = false;
        }
    }
}
