namespace TestSignature
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemSaveImage = new System.Windows.Forms.MenuItem();
            this.menuItemVector = new System.Windows.Forms.MenuItem();
            this.menuItemSaveVector = new System.Windows.Forms.MenuItem();
            this.menuItemLoadVector = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.buttonClear = new System.Windows.Forms.Button();
            this.checkBoxBezier = new System.Windows.Forms.CheckBox();
            this.buttonFindSignature = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonRedraw = new System.Windows.Forms.Button();
            this.signatureBox1 = new GravelInnovation.BezierSignature.SignatureBox();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuItemFile);
            this.mainMenu1.MenuItems.Add(this.menuItemExit);
            // 
            // menuItemFile
            // 
            this.menuItemFile.MenuItems.Add(this.menuItemSaveImage);
            this.menuItemFile.MenuItems.Add(this.menuItemVector);
            this.menuItemFile.Text = "File";
            // 
            // menuItemSaveImage
            // 
            this.menuItemSaveImage.Text = "Save Image...";
            this.menuItemSaveImage.Click += new System.EventHandler(this.menuItemSaveImage_Click);
            // 
            // menuItemVector
            // 
            this.menuItemVector.MenuItems.Add(this.menuItemSaveVector);
            this.menuItemVector.MenuItems.Add(this.menuItemLoadVector);
            this.menuItemVector.Text = "Vector";
            // 
            // menuItemSaveVector
            // 
            this.menuItemSaveVector.Text = "Save...";
            this.menuItemSaveVector.Click += new System.EventHandler(this.menuItemSaveVector_Click);
            // 
            // menuItemLoadVector
            // 
            this.menuItemLoadVector.Text = "Load...";
            this.menuItemLoadVector.Click += new System.EventHandler(this.menuItemLoadVector_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(164, 145);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(72, 20);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // checkBoxBezier
            // 
            this.checkBoxBezier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxBezier.Location = new System.Drawing.Point(164, 171);
            this.checkBoxBezier.Name = "checkBoxBezier";
            this.checkBoxBezier.Size = new System.Drawing.Size(66, 20);
            this.checkBoxBezier.TabIndex = 5;
            this.checkBoxBezier.Text = "Bezier";
            this.checkBoxBezier.CheckStateChanged += new System.EventHandler(this.checkBoxBezier_CheckStateChanged);
            // 
            // buttonFindSignature
            // 
            this.buttonFindSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonFindSignature.Location = new System.Drawing.Point(4, 145);
            this.buttonFindSignature.Name = "buttonFindSignature";
            this.buttonFindSignature.Size = new System.Drawing.Size(72, 20);
            this.buttonFindSignature.TabIndex = 6;
            this.buttonFindSignature.Text = "Find";
            this.buttonFindSignature.Click += new System.EventHandler(this.buttonFindSignature_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "signature.vect";
            this.openFileDialog.Filter = "Vector files|*.vect";
            // 
            // buttonRedraw
            // 
            this.buttonRedraw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRedraw.Location = new System.Drawing.Point(4, 171);
            this.buttonRedraw.Name = "buttonRedraw";
            this.buttonRedraw.Size = new System.Drawing.Size(72, 20);
            this.buttonRedraw.TabIndex = 7;
            this.buttonRedraw.Text = "Redraw";
            this.buttonRedraw.Click += new System.EventHandler(this.buttonRedraw_Click);
            // 
            // signatureBox1
            // 
            this.signatureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.signatureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.signatureBox1.Data = new byte[0];
            this.signatureBox1.IsBezierEnabled = true;
            this.signatureBox1.Location = new System.Drawing.Point(4, 3);
            this.signatureBox1.Name = "signatureBox1";
            this.signatureBox1.Size = new System.Drawing.Size(232, 136);
            this.signatureBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(239, 201);
            this.Controls.Add(this.buttonRedraw);
            this.Controls.Add(this.buttonFindSignature);
            this.Controls.Add(this.checkBoxBezier);
            this.Controls.Add(this.signatureBox1);
            this.Controls.Add(this.buttonClear);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.Button buttonClear;
        private GravelInnovation.BezierSignature.SignatureBox signatureBox1;
        private System.Windows.Forms.CheckBox checkBoxBezier;
        private System.Windows.Forms.Button buttonFindSignature;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MenuItem menuItemSaveImage;
        private System.Windows.Forms.MenuItem menuItemVector;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemSaveVector;
        private System.Windows.Forms.MenuItem menuItemLoadVector;
        private System.Windows.Forms.Button buttonRedraw;
    }
}

