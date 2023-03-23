/****************************************************************************
 * Copyright 2011 Jean-Philippe Gravel, p. eng.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *    http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 ***************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace GravelInnovation.BezierSignature
{
    public partial class SignatureBox : UserControl
    {
        private const int LINE_POINTS_PER_CURVE = 4;
        private const float SAMPLING_INTERVAL = 1.5f; // How far a new point must be from the previous one to be sampled.

        private List<PointF> points;
        private Image image;
        private Graphics graphics;
        private Pen pen;
        private PointF lastPoint;
        private int pointCount;
        private Boolean bezierEnabled;

        public SignatureBox()
        {
            InitializeComponent();
            this.points = new List<PointF>();
            this.image = new Bitmap(
                this.Width, 
                this.Height);
            this.graphics = Graphics.FromImage(this.image);
            this.graphics.FillRectangle(
                new SolidBrush(Color.White), 
                new Rectangle(0, 0, this.Width, this.Height));
            this.lastPoint = PointF.Empty;
            this.pen = new Pen(Color.Black, 1);
            this.pictureBox.Image = this.image;
            this.pointCount = 0;
            this.bezierEnabled = true;
        }


        public float PenWidth
        {
            get { return this.pen.Width; }
            set { this.pen.Width = value; }
        }

        public Color PenColor
        {
            get { return this.pen.Color; }
            set { this.pen.Color = value; }
        }

        public byte[] Data
        {
            get { return this.PointsToByteArray(); }
            set { this.ByteArrayToPoints(value); }
        }

        public bool IsBezierEnabled
        {
            get { return this.bezierEnabled; }
            set { this.bezierEnabled = value; }
        }

        public void Clear()
        {
            this.points.Clear();
            this.graphics.FillRectangle(
                new SolidBrush(Color.White),
                new Rectangle(0, 0, this.image.Width, this.image.Height));
            this.lastPoint = PointF.Empty;
            this.pictureBox.Refresh();
        }

        public void Redraw()
        {
            this.ByteArrayToPoints(this.PointsToByteArray());
        }

        public Image CreateImage()
        {
            Rectangle srcRect = this.FindSignature();
            Rectangle destRect = new Rectangle(
                0, 0, srcRect.Width, srcRect.Height);
            Bitmap newImage = new Bitmap(srcRect.Width, srcRect.Height);
            Graphics g = Graphics.FromImage(newImage);
            g.DrawImage(this.image, destRect, srcRect, GraphicsUnit.Pixel);
            return newImage;
        }

        public void SurroundSignature()
        {
            Rectangle rect = this.FindSignature();
            rect.X--;
            rect.Y--;
            rect.Width += 2;
            rect.Height += 2;
            this.graphics.DrawRectangle(new Pen(Color.Red), rect);
            this.pictureBox.Refresh();
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.lastPoint = new PointF(e.X, e.Y);
            this.points.Add(this.lastPoint);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            PointF newPoint = new PointF(e.X, e.Y);
            if (Graph.Distance(this.lastPoint, newPoint) > SAMPLING_INTERVAL)
            {
                this.points.Add(newPoint);
                this.Draw(LINE_POINTS_PER_CURVE);
                this.lastPoint = newPoint;
                this.pictureBox.Refresh();
            }
        }

        private void Draw(int nbPoints)
        {
            this.pointCount++;
            if (this.bezierEnabled)
            {
                if ((this.pointCount > 0) && ((this.pointCount % nbPoints) == 0))
                {
                    PointF[] pts = new PointF[nbPoints + 1];
                    try
                    {
                        Array.Copy(
                            this.points.ToArray(),
                            this.points.Count - nbPoints - 1,
                            pts,
                            0,
                            nbPoints + 1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this.points.Count + " " + nbPoints);
                        throw ex;
                    }
                    Point[] flattened = Bezier.Interpolate(nbPoints + 1, pts);
                    this.graphics.DrawLines(this.pen, flattened);
                }
            }
            else
            {
                this.graphics.DrawLine(
                    this.pen,
                    (int)this.points[this.points.Count - 2].X,
                    (int)this.points[this.points.Count - 2].Y,
                    (int)this.points[this.points.Count - 1].X,
                    (int)this.points[this.points.Count - 1].Y);
            }
        }



        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.StopDraw();
        }

        private void StopDraw()
        {
            if (this.bezierEnabled)
            {
                this.Draw(this.pointCount);
            }
            this.lastPoint = PointF.Empty;
            this.points.Add(PointF.Empty);
            this.pointCount = 0;
        }

        private Rectangle FindSignature()
        {
            Point upperLeft = new Point(int.MaxValue, int.MaxValue);
            Point lowerRight = new Point(int.MinValue, int.MinValue);
            foreach (PointF p in this.points)
            {
                if (!p.Equals(PointF.Empty))
                {
                    upperLeft.X = (int)Math.Min(p.X, upperLeft.X);
                    upperLeft.Y = (int)Math.Min(p.Y, upperLeft.Y);
                    lowerRight.X = (int)Math.Max(p.X, lowerRight.X);
                    lowerRight.Y = (int)Math.Max(p.Y, lowerRight.Y);
                }
            }

            Size size = new Size(
                lowerRight.X - upperLeft.X,
                lowerRight.Y - upperLeft.Y);

            Rectangle srcRect = new Rectangle(
                upperLeft.X, upperLeft.Y, size.Width, size.Height);

            return srcRect;
        }

        private byte[] PointsToByteArray()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);
            foreach (PointF p in this.points)
            {
                if (p.Equals(PointF.Empty))
                    bw.Write((short)-1);
                else
                {
                    bw.Write((short)p.X);
                    bw.Write((short)p.Y);
                }
            }
            bw.Close();

            return ms.ToArray();
        }

        private void ByteArrayToPoints(byte[] data)
        {
            this.Clear();
            MemoryStream ms = new MemoryStream(data);
            BinaryReader br = new BinaryReader(ms);
            int pos = 0;
            while (pos < data.Length)
            {
                short x = br.ReadInt16();
                pos += 2;
                if (x == -1)
                {
                    this.StopDraw();
                }
                else
                {
                    short y = br.ReadInt16();
                    PointF newPoint = new PointF(x, y);
                    pos += 2;
                    if (!this.lastPoint.Equals(PointF.Empty))
                    {
                        this.points.Add(newPoint);
                        this.Draw(LINE_POINTS_PER_CURVE);
                        this.lastPoint = newPoint;
                    }
                    else
                    {
                        this.lastPoint = newPoint;
                        this.points.Add(newPoint);
                    }
                }
            }
            br.Close();
            this.pictureBox.Refresh();
        }

        private void SignatureBox_Resize(object sender, EventArgs e)
        {
            if (this.image == null)
                return;
            Bitmap newBitmap = new Bitmap(this.Width, this.Height);
            Graphics newGraphics = Graphics.FromImage(newBitmap);
            newGraphics.FillRectangle(
                new SolidBrush(Color.White),
                new Rectangle(0, 0, this.Width, this.Height));
            newGraphics.DrawImage(this.image, 0, 0);
            this.graphics.Dispose();
            this.image.Dispose();
            this.graphics = newGraphics;
            this.image = newBitmap;
            this.pictureBox.Image = this.image;
        }
    }
}
