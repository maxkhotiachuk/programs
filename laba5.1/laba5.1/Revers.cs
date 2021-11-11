using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba5._1
{
    public partial class Revers : Form
    {
        public Revers()
        {
            InitializeComponent();
            button1.Enabled = false;
        }    
        private void Button1_Click_1(object sender, EventArgs e)
        {
            Form1 f = (Form1)this.Owner;
            f.riadoc = textBox1.Text;
            f.rtl = radioButton1.Checked;
            f.caps = radioButton2.Checked;
            
            Close();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            bool a, b, c;
            a = textBox1.Text.EndsWith(".");
            b = textBox1.Text.EndsWith("!");
            c = textBox1.Text.EndsWith("?");
            if ((a) | (b) | (c))
            {
                errorProvider1.Clear();
                button1.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(textBox1, "Input . or ! or ?");
                button1.Enabled = false;
            }
        }
    }
}
