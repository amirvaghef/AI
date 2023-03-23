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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace TestSignature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            this.signatureBox1.Clear();
        }

        private void checkBoxBezier_CheckStateChanged(object sender, EventArgs e)
        {
            this.signatureBox1.IsBezierEnabled = this.checkBoxBezier.Checked;
        }

        private void buttonFindSignature_Click(object sender, EventArgs e)
        {
            this.signatureBox1.SurroundSignature();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonRedraw_Click(object sender, EventArgs e)
        {
            this.signatureBox1.Redraw();
        }

        private void menuItemSaveImage_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Filter = "Gif image|*.gif";
            this.saveFileDialog.FileName = "signature.gif";
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.signatureBox1.CreateImage().Save(
                        this.saveFileDialog.FileName, 
                        ImageFormat.Gif);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void menuItemSaveVector_Click(object sender, EventArgs e)
        {
            this.saveFileDialog.Filter = "Vector files|*.vect";
            this.saveFileDialog.FileName = "signature.vect";
            if (this.saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(
                    this.saveFileDialog.FileName, 
                    FileMode.Create);
                Byte[] buf = this.signatureBox1.Data;
                try
                {
                    fs.Write(buf, 0, buf.Length);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        private void menuItemLoadVector_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(
                    this.openFileDialog.FileName, 
                    FileMode.Open);
                Byte[] buf = new byte[fs.Length];
                fs.Read(buf, 0, buf.Length);
                fs.Close();
                this.signatureBox1.Data = buf;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.checkBoxBezier.Checked = this.signatureBox1.IsBezierEnabled;
        }

    }
}