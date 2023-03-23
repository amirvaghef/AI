using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        private bool red = true, green = true, blue = true;
        private byte[] levelValue = new byte[256];
        Rectangle imCurveRect = new Rectangle();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            imCurveRect = new Rectangle(imageCurve1.Left - 2, imageCurve1.Top - 2,
                imageCurve1.Width + 4, imageCurve1.Height + 4);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            imCurveRect = new Rectangle(imageCurve1.Left - 2, imageCurve1.Top - 2,
               imageCurve1.Width + 4, imageCurve1.Height + 4);
            Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // draw X ruler
            int x0 = 0;
            int x2 = 255;
            float unitX = (float)imageCurve1.Width / 255f;

            for (int i = x0; i <= x2; i++)
            {
                if (i % 10 == 0) g.DrawLine(new Pen(Color.Black), new PointF((i - x0) * unitX + imageCurve1.Left,
                            imCurveRect.Bottom), new PointF((i - x0) * unitX + imageCurve1.Left, imCurveRect.Bottom + 5)); // ruler line
                if (i % 50 == 0)
                {
                    g.DrawLine(new Pen(Color.Black, 2f), new PointF((i - x0) * unitX + imageCurve1.Left,
                        imCurveRect.Bottom), new PointF((i - x0) * unitX + imageCurve1.Left, imCurveRect.Bottom + 12));
                    SizeF stringSize = g.MeasureString(i.ToString(), this.Font);
                    PointF stringLoc = new PointF((i - x0) * unitX + imageCurve1.Left - stringSize.Width / 2, imCurveRect.Bottom + 12);
                    g.DrawString(i.ToString(), this.Font, new SolidBrush(Color.Black), stringLoc);
                }
            }

            // draw Y ruler
            int y0 = 0; 
            int y2 = 255;
            float unitY = (float)imageCurve1.Height / 255f;
            for (int i = y0; i <= y2; i++)
            {
                if (i % 10 == 0) g.DrawLine(new Pen(Color.Black), new PointF(imCurveRect.Left - 5, imageCurve1.Bottom - (i - y0) * unitY),
                                     new PointF(imCurveRect.Left, imageCurve1.Bottom - (i - y0) * unitY)); // ruler line
                if (i % 50 == 0)
                {
                    g.DrawLine(new Pen(Color.Black, 2f), new PointF(imCurveRect.Left - 10, imageCurve1.Bottom - (i - y0) * unitY),
                             new PointF(imCurveRect.Left, imageCurve1.Bottom - (i - y0) * unitY)); // ruler line
                    SizeF stringSize = g.MeasureString(i.ToString(), this.Font);
                    PointF stringLoc = new PointF(imCurveRect.Left - 10 - stringSize.Width, imageCurve1.Bottom - (i - y0) * unitY - stringSize.Height / 2);
                    g.DrawString(i.ToString(), this.Font, new SolidBrush(Color.Black), stringLoc);
                }
            }
            
            // draw rect for control imageCurve
            g.DrawRectangle(new Pen(Color.Black, 2), imCurveRect);

        }

        YLScsDrawing.Imaging.ImageData srcID = new YLScsDrawing.Imaging.ImageData();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bmp = new Bitmap(o.FileName);
                    srcID.FromBitmap(bmp);
                    canvas1.CanvasSize = bmp.Size;
                    canvas1.ImageLocation = new Point(0, 0);
                    canvas1.CanvasImage = srcID.ToBitmap();
                }
                catch
                {
                    bmp = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmp = canvas1.CanvasImage;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png|TIFF Image|*.tiff";
            saveFileDialog1.Title = "Save an Image File";

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        bmp.Save(fs,
                            System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;

                    case 2:
                        bmp.Save(fs,
                            System.Drawing.Imaging.ImageFormat.Gif);
                        break;

                    case 3:
                        bmp.Save(fs,
                            System.Drawing.Imaging.ImageFormat.Png);
                        break;

                    case 4:
                        bmp.Save(fs,
                            System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                }

                fs.Close();
            }

        }
        
        private void imageCurve1_ImageLevelChanged(object sender, YLScsDrawing.Controls.ImageLevelEventArgs e)
        {
            levelValue = e.LevelValue;
            changeImageLevel();
        }

        private void changeImageLevel()
        {
            Bitmap srcBmp = canvas1.CanvasImage;
            if (srcBmp == null) return;
            YLScsDrawing.Imaging.ImageData nch = srcID.Clone();
            for (int w = 0; w < bmp.Width; w++)
            {
                for (int h = 0; h <bmp.Height; h++)
                {
                    if (red) nch.R[w, h] = levelValue[srcID.R[w, h]];
                    if (green) nch.G[w, h] = levelValue[srcID.G[w, h]];
                    if (blue) nch.B[w, h] = levelValue[srcID.B[w, h]];
                }
            }
            canvas1.CanvasImage = nch.ToBitmap();
        }

        private void checkBoxR_CheckedChanged(object sender, EventArgs e)
        {
            red = checkBoxR.Checked;
            changeImageLevel();
        }

        private void checkBoxG_CheckedChanged(object sender, EventArgs e)
        {
            green = checkBoxG.Checked;
            changeImageLevel();
        }

        private void checkBoxB_CheckedChanged(object sender, EventArgs e)
        {
            blue = checkBoxB.Checked;
            changeImageLevel();
        }
    }
}