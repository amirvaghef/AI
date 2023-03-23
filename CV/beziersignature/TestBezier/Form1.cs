using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using GravelInnovation.BezierSignature;

namespace TestBezier
{
    public partial class Form1 : Form
    {
        private Rectangle rect;
        private Graphics graphics;
        private List<GravelInnovation.BezierSignature.PointF> points;

        public Form1()
        {
            InitializeComponent();
            this.pictureBox.Image = new Bitmap(this.pictureBox.Width, this.pictureBox.Height);
            this.graphics = Graphics.FromImage(this.pictureBox.Image);
            this.points = new List<GravelInnovation.BezierSignature.PointF>();
            this.rect = new Rectangle(0, 0, this.pictureBox.Width, this.pictureBox.Height);
            this.graphics.FillRectangle(Brushes.White, this.rect);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.points.Add(new GravelInnovation.BezierSignature.PointF(e.X, e.Y));
            this.graphics.DrawLine(
                Pens.Red, 
                new Point(e.X - 3, e.Y), 
                new Point(e.X + 3, e.Y));
            this.graphics.DrawLine(
                Pens.Red,
                new Point(e.X, e.Y - 3),
                new Point(e.X, e.Y + 3));
            this.pictureBox.Refresh();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            this.points.Clear();
            this.graphics.FillRectangle(Brushes.White, this.rect);
            this.pictureBox.Refresh();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            Point[] pts = Bezier.Interpolate(100, this.points.ToArray());
            this.graphics.DrawLines(Pens.Black, pts);
            this.pictureBox.Refresh();
        }
    }
}