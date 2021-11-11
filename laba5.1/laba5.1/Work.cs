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
    public partial class Work : Form
    {
        public Work()
        {
            InitializeComponent();
        }

        private void Work_Load(object sender, EventArgs e)
        {
            Form1 f = (Form1)this.Owner;
            if(f.caps)
            textBox1.Text = f.riadoc.ToUpper().ToString();
            if(f.rtl)
            {
                char[] right = f.riadoc.ToCharArray();
                Array.Reverse(right);
                textBox1.Text = new string(right).ToString();
            }
        }
    }
}
