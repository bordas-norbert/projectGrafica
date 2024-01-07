using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graficaProject
{
    public partial class Form1 : Form
    {
        private int centruX;
        private int centruY;
        private int diametru;
        public Form1()
        {
            InitializeComponent();

            this.Text = "Circle to Square Transformation";
            this.Size = new Size(741, 741);
            this.Paint += new PaintEventHandler(TransformCircleToSquare);

            centruX = 300;
            centruY = 300;
            diametru = 150;

        }

        private void TransformCircleToSquare(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen cPen = new Pen(Color.Blue);
            Pen pPen = new Pen(Color.Red);

            g.DrawEllipse(cPen, centruX - diametru, centruY - diametru, diametru * 2, diametru * 2);

            TransformCircleToSquareMidpoint(g, pPen, centruX, centruY, diametru);
        }

        private void TransformCircleToSquareMidpoint(Graphics g, Pen pen, int cx, int cy, int dia)
        {
            int x = dia;
            int y = 0;

            while (x >= y)
            {
                DrawSquarePoints(g, pen, cx, cy, x, y);

                y++;

                // In cazul in care midpoint este in cerc sau pe perimetrul lui
                if (GetCircleDistance(x, y, dia) <= 0)
                {
                    x--;
                }
            }
        }

        private void DrawSquarePoints(Graphics g, Pen pen, int cx, int cy, int x, int y)
        {
            // Desenam punctele in cele 4 octeti bazat pe simetrie

            // Partea stanga si partea dreapta
            Thread.Sleep(20);
            g.DrawRectangle(pen, cx + x, cy + y, 2, 2);
            g.DrawRectangle(pen, cx - x, cy + y, 2, 2);
            g.DrawRectangle(pen, cx + x, cy - y, 2, 2);
            g.DrawRectangle(pen, cx - x, cy - y, 2, 2);

            // Partea sus si partea jos
            Thread.Sleep(20);
            pen = new Pen(Color.DarkGoldenrod);
            g.DrawRectangle(pen, cx + y, cy + x, 2, 2);
            g.DrawRectangle(pen, cx - y, cy + x, 2, 2);
            g.DrawRectangle(pen, cx + y, cy - x, 2, 2);
            g.DrawRectangle(pen, cx - y, cy - x, 2, 2);
        }

        private double GetCircleDistance(int x, int y, int r)
        {
            return Math.Pow(x, 2) + Math.Pow(y, 2) - Math.Pow(r, 2);
        }
    }
}
