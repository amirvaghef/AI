namespace TokenExtraction
{
    partial class EditSentences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.txtSentence = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblUnigram = new System.Windows.Forms.Label();
            this.lblBigram = new System.Windows.Forms.Label();
            this.lblTrigram = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtSentence
            // 
            this.txtSentence.Location = new System.Drawing.Point(9, 14);
            this.txtSentence.Name = "txtSentence";
            this.txtSentence.Size = new System.Drawing.Size(446, 21);
            this.txtSentence.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(461, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "محاسبه";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bigram Probability";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unigram Probability";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Trigram Probability";
            // 
            // lblUnigram
            // 
            this.lblUnigram.AutoSize = true;
            this.lblUnigram.Location = new System.Drawing.Point(388, 82);
            this.lblUnigram.Name = "lblUnigram";
            this.lblUnigram.Size = new System.Drawing.Size(0, 13);
            this.lblUnigram.TabIndex = 5;
            // 
            // lblBigram
            // 
            this.lblBigram.AutoSize = true;
            this.lblBigram.Location = new System.Drawing.Point(207, 82);
            this.lblBigram.Name = "lblBigram";
            this.lblBigram.Size = new System.Drawing.Size(0, 13);
            this.lblBigram.TabIndex = 6;
            // 
            // lblTrigram
            // 
            this.lblTrigram.AutoSize = true;
            this.lblTrigram.Location = new System.Drawing.Point(24, 82);
            this.lblTrigram.Name = "lblTrigram";
            this.lblTrigram.Size = new System.Drawing.Size(0, 13);
            this.lblTrigram.TabIndex = 7;
            // 
            // EditSentences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 115);
            this.Controls.Add(this.lblTrigram);
            this.Controls.Add(this.lblBigram);
            this.Controls.Add(this.lblUnigram);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSentence);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSentences";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "EditSentences";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSentence;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblUnigram;
        private System.Windows.Forms.Label lblBigram;
        private System.Windows.Forms.Label lblTrigram;
    }
}