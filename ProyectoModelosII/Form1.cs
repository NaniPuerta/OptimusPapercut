using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Linker;
using OptimizationCore;

namespace ProyectoModelosII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Pen p = new Pen(Color.Black);
            e.Graphics.Clear(pictureBox1.BackColor);
            foreach (Rectangle item in pieces)
            {
                e.Graphics.DrawRectangle(p, item);
            }
        }

        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }
    }

    
}
