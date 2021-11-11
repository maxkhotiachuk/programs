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
    public partial class Form1 : Form
    {
        public string riadoc;
        public bool rtl;
        public bool caps;
        public Form1()
        {
            InitializeComponent();
            workToolStripMenuItem.Enabled = false;
        }
        Help h;
        About a;
        Revers r;
        Work w;
        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((h == null) || (h.IsDisposed))
            {
                h = new Help();
                h.Show();
            }
        }

        private void ReversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((r == null) || (r.IsDisposed))
            {
                r = new Revers();
                r.Owner = this;
                r.ShowDialog();
                workToolStripMenuItem.Enabled = true;
            }
        }

        private void WorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((w == null) || (w.IsDisposed))
            {
                w = new Work();
                w.Owner = this;
                w.Show();
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((a == null) || (a.IsDisposed))
            {
                a = new About();
                a.Show();
            }
        }
    }
}
