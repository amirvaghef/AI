namespace TokenExtraction
{
    partial class Form2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblTrigram = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblBigram = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUnigram = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lbFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtOriginal = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridViewSentence = new System.Windows.Forms.DataGridView();
            this.Edit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Sentence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unigram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bigram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Trigram = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSentence)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblTrigram);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lblBigram);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.lblUnigram);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.lbFileName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(947, 639);
            this.splitContainer1.SplitterDistance = 98;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblTrigram
            // 
            this.lblTrigram.AutoSize = true;
            this.lblTrigram.Location = new System.Drawing.Point(750, 10);
            this.lblTrigram.Name = "lblTrigram";
            this.lblTrigram.Size = new System.Drawing.Size(0, 13);
            this.lblTrigram.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(647, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = " : Trigram Average";
            // 
            // lblBigram
            // 
            this.lblBigram.AutoSize = true;
            this.lblBigram.Location = new System.Drawing.Point(423, 10);
            this.lblBigram.Name = "lblBigram";
            this.lblBigram.Size = new System.Drawing.Size(0, 13);
            this.lblBigram.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(324, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = " : Bigram Average";
            // 
            // lblUnigram
            // 
            this.lblUnigram.AutoSize = true;
            this.lblUnigram.Location = new System.Drawing.Point(109, 10);
            this.lblUnigram.Name = "lblUnigram";
            this.lblUnigram.Size = new System.Drawing.Size(0, 13);
            this.lblUnigram.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = " : Unigram Average";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 26);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Execute";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbFileName
            // 
            this.lbFileName.AutoSize = true;
            this.lbFileName.Location = new System.Drawing.Point(12, 65);
            this.lbFileName.Name = "lbFileName";
            this.lbFileName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbFileName.Size = new System.Drawing.Size(0, 13);
            this.lbFileName.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(862, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "فایل انتخابی: ";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(781, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridViewSentence);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtOriginal);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(947, 537);
            this.splitContainer2.SplitterDistance = 555;
            this.splitContainer2.TabIndex = 0;
            // 
            // txtOriginal
            // 
            this.txtOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOriginal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtOriginal.Location = new System.Drawing.Point(0, 0);
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(388, 537);
            this.txtOriginal.TabIndex = 0;
            this.txtOriginal.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.txt|*.doc|*.docx";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridViewSentence
            // 
            this.dataGridViewSentence.AllowUserToAddRows = false;
            this.dataGridViewSentence.AllowUserToDeleteRows = false;
            this.dataGridViewSentence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSentence.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Edit,
            this.Sentence,
            this.Unigram,
            this.Bigram,
            this.Trigram});
            this.dataGridViewSentence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSentence.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSentence.Name = "dataGridViewSentence";
            this.dataGridViewSentence.ReadOnly = true;
            this.dataGridViewSentence.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewSentence.Size = new System.Drawing.Size(555, 537);
            this.dataGridViewSentence.TabIndex = 2;
            this.dataGridViewSentence.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSentence_CellClick);
            // 
            // Edit
            // 
            this.Edit.HeaderText = "ویرایش";
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Width = 50;
            // 
            // Sentence
            // 
            this.Sentence.HeaderText = "جمله";
            this.Sentence.Name = "Sentence";
            this.Sentence.ReadOnly = true;
            this.Sentence.Width = 300;
            // 
            // Unigram
            // 
            this.Unigram.HeaderText = "Unigram";
            this.Unigram.Name = "Unigram";
            this.Unigram.ReadOnly = true;
            this.Unigram.Width = 120;
            // 
            // Bigram
            // 
            this.Bigram.HeaderText = "Bigram";
            this.Bigram.Name = "Bigram";
            this.Bigram.ReadOnly = true;
            this.Bigram.Width = 120;
            // 
            // Trigram
            // 
            this.Trigram.HeaderText = "Trigram";
            this.Trigram.Name = "Trigram";
            this.Trigram.ReadOnly = true;
            this.Trigram.Width = 120;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 639);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "Form2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم احتمالات جملات براساس Corpuse پایه";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSentence)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbFileName;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox txtOriginal;
        private System.Windows.Forms.DataGridView dataGridViewSentence;
        private System.Windows.Forms.DataGridViewButtonColumn Edit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sentence;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unigram;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bigram;
        private System.Windows.Forms.DataGridViewTextBoxColumn Trigram;
        private System.Windows.Forms.Label lblTrigram;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBigram;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUnigram;
        private System.Windows.Forms.Label label2;
    }
}

