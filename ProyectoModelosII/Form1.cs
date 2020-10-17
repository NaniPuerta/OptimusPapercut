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
        List<Rectangle> pieces;
        CutPattern[] sol;
        int ind = 0;
        int sL;
        int sW;
        public Form1()
        {
            InitializeComponent();
            pieces = new List<Rectangle>();
            
        }        

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            e.Graphics.Clear(pictureBox1.BackColor);
            foreach (Rectangle item in pieces)
            {
                e.Graphics.DrawRectangle(p, item);
            }
        }

        private void GetPieces(CutPattern p, int stockL, int stockW)
        {
            int pbL = pictureBox1.Size.Height;
            int pbW = pictureBox1.Size.Width;
            int ratioL = pbL / stockL;
            int ratioW = pbW / stockW;
            //pieces.Add(new Rectangle(0,0,))
            foreach (Piece item in p.PieceDistribution)
            {
                pieces.Add(new Rectangle(ratioL * item.startX, ratioW * item.startY, ratioL * item.length, ratioW * item.width));
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (ind == sol.Length)
                return;
            GetPieces(sol[ind], sL, sW);
            ind++;
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] lengths = new int[] { 20, 22, 25, 26 };
            int[] widths = new int[] { 1, 1, 1, 1 };
            int[] demands = new int[] { 30, 30, 30, 120 };
            sL = 70;
            sW = 1;
            int cost = 1;

            sol = Linker.Linker.FindSolution(lengths, widths, demands, sL, sW, cost);

            cost = 0;
           
        }
    }

    
}
