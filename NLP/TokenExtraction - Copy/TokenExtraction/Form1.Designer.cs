namespace TokenExtraction
{
    partial class Form1
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
            this.button2 = new System.Windows.Forms.Button();
            this.lbFileName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabWord = new System.Windows.Forms.TabPage();
            this.dataGridViewWord = new System.Windows.Forms.DataGridView();
            this.tabDigit = new System.Windows.Forms.TabPage();
            this.dataGridViewDigit = new System.Windows.Forms.DataGridView();
            this.tabTrap = new System.Windows.Forms.TabPage();
            this.dataGridViewTrap = new System.Windows.Forms.DataGridView();
            this.tabMark = new System.Windows.Forms.TabPage();
            this.dataGridViewMark = new System.Windows.Forms.DataGridView();
            this.tabSentence = new System.Windows.Forms.TabPage();
            this.listBoxSentence = new System.Windows.Forms.ListBox();
            this.tabBigram = new System.Windows.Forms.TabPage();
            this.dataGridViewBigram = new System.Windows.Forms.DataGridView();
            this.tabTrigram = new System.Windows.Forms.TabPage();
            this.dataGridViewTrigram = new System.Windows.Forms.DataGridView();
            this.txtOriginal = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.KeyTrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueTrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProbTrap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProbWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyDigit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueDigit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProbDigit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProbMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prob = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prob1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabWord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWord)).BeginInit();
            this.tabDigit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDigit)).BeginInit();
            this.tabTrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrap)).BeginInit();
            this.tabMark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMark)).BeginInit();
            this.tabSentence.SuspendLayout();
            this.tabBigram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBigram)).BeginInit();
            this.tabTrigram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrigram)).BeginInit();
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
            this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer2.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtOriginal);
            this.splitContainer2.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer2.Size = new System.Drawing.Size(947, 537);
            this.splitContainer2.SplitterDistance = 478;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabWord);
            this.tabControl1.Controls.Add(this.tabDigit);
            this.tabControl1.Controls.Add(this.tabTrap);
            this.tabControl1.Controls.Add(this.tabMark);
            this.tabControl1.Controls.Add(this.tabSentence);
            this.tabControl1.Controls.Add(this.tabBigram);
            this.tabControl1.Controls.Add(this.tabTrigram);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(478, 537);
            this.tabControl1.TabIndex = 2;
            // 
            // tabWord
            // 
            this.tabWord.Controls.Add(this.dataGridViewWord);
            this.tabWord.Location = new System.Drawing.Point(4, 22);
            this.tabWord.Name = "tabWord";
            this.tabWord.Padding = new System.Windows.Forms.Padding(3);
            this.tabWord.Size = new System.Drawing.Size(470, 511);
            this.tabWord.TabIndex = 0;
            this.tabWord.Text = "Word";
            this.tabWord.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWord
            // 
            this.dataGridViewWord.AllowUserToAddRows = false;
            this.dataGridViewWord.AllowUserToDeleteRows = false;
            this.dataGridViewWord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyWord,
            this.ValueWord,
            this.ProbWord});
            this.dataGridViewWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewWord.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewWord.Name = "dataGridViewWord";
            this.dataGridViewWord.ReadOnly = true;
            this.dataGridViewWord.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewWord.Size = new System.Drawing.Size(464, 505);
            this.dataGridViewWord.TabIndex = 1;
            // 
            // tabDigit
            // 
            this.tabDigit.Controls.Add(this.dataGridViewDigit);
            this.tabDigit.Location = new System.Drawing.Point(4, 22);
            this.tabDigit.Name = "tabDigit";
            this.tabDigit.Padding = new System.Windows.Forms.Padding(3);
            this.tabDigit.Size = new System.Drawing.Size(470, 511);
            this.tabDigit.TabIndex = 1;
            this.tabDigit.Text = "Digit";
            this.tabDigit.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDigit
            // 
            this.dataGridViewDigit.AllowUserToAddRows = false;
            this.dataGridViewDigit.AllowUserToDeleteRows = false;
            this.dataGridViewDigit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDigit.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyDigit,
            this.ValueDigit,
            this.ProbDigit});
            this.dataGridViewDigit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDigit.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewDigit.Name = "dataGridViewDigit";
            this.dataGridViewDigit.ReadOnly = true;
            this.dataGridViewDigit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewDigit.Size = new System.Drawing.Size(464, 505);
            this.dataGridViewDigit.TabIndex = 1;
            // 
            // tabTrap
            // 
            this.tabTrap.Controls.Add(this.dataGridViewTrap);
            this.tabTrap.Location = new System.Drawing.Point(4, 22);
            this.tabTrap.Name = "tabTrap";
            this.tabTrap.Size = new System.Drawing.Size(470, 511);
            this.tabTrap.TabIndex = 2;
            this.tabTrap.Text = "Trap";
            this.tabTrap.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTrap
            // 
            this.dataGridViewTrap.AllowUserToAddRows = false;
            this.dataGridViewTrap.AllowUserToDeleteRows = false;
            this.dataGridViewTrap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyTrap,
            this.ValueTrap,
            this.ProbTrap});
            this.dataGridViewTrap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrap.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTrap.Name = "dataGridViewTrap";
            this.dataGridViewTrap.ReadOnly = true;
            this.dataGridViewTrap.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewTrap.Size = new System.Drawing.Size(470, 511);
            this.dataGridViewTrap.TabIndex = 1;
            // 
            // tabMark
            // 
            this.tabMark.Controls.Add(this.dataGridViewMark);
            this.tabMark.Location = new System.Drawing.Point(4, 22);
            this.tabMark.Name = "tabMark";
            this.tabMark.Size = new System.Drawing.Size(470, 511);
            this.tabMark.TabIndex = 3;
            this.tabMark.Text = "Mark";
            this.tabMark.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMark
            // 
            this.dataGridViewMark.AllowUserToAddRows = false;
            this.dataGridViewMark.AllowUserToDeleteRows = false;
            this.dataGridViewMark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyMark,
            this.ValueMark,
            this.ProbMark});
            this.dataGridViewMark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewMark.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewMark.Name = "dataGridViewMark";
            this.dataGridViewMark.ReadOnly = true;
            this.dataGridViewMark.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewMark.Size = new System.Drawing.Size(470, 511);
            this.dataGridViewMark.TabIndex = 0;
            // 
            // tabSentence
            // 
            this.tabSentence.Controls.Add(this.listBoxSentence);
            this.tabSentence.Location = new System.Drawing.Point(4, 22);
            this.tabSentence.Name = "tabSentence";
            this.tabSentence.Size = new System.Drawing.Size(470, 511);
            this.tabSentence.TabIndex = 4;
            this.tabSentence.Text = "Sentence";
            this.tabSentence.UseVisualStyleBackColor = true;
            // 
            // listBoxSentence
            // 
            this.listBoxSentence.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxSentence.FormattingEnabled = true;
            this.listBoxSentence.HorizontalScrollbar = true;
            this.listBoxSentence.Location = new System.Drawing.Point(0, 0);
            this.listBoxSentence.Name = "listBoxSentence";
            this.listBoxSentence.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBoxSentence.Size = new System.Drawing.Size(470, 511);
            this.listBoxSentence.TabIndex = 1;
            // 
            // tabBigram
            // 
            this.tabBigram.Controls.Add(this.dataGridViewBigram);
            this.tabBigram.Location = new System.Drawing.Point(4, 22);
            this.tabBigram.Name = "tabBigram";
            this.tabBigram.Size = new System.Drawing.Size(470, 511);
            this.tabBigram.TabIndex = 5;
            this.tabBigram.Text = "Bigram";
            this.tabBigram.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBigram
            // 
            this.dataGridViewBigram.AllowUserToAddRows = false;
            this.dataGridViewBigram.AllowUserToDeleteRows = false;
            this.dataGridViewBigram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBigram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key,
            this.Value,
            this.Prob});
            this.dataGridViewBigram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBigram.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewBigram.Name = "dataGridViewBigram";
            this.dataGridViewBigram.ReadOnly = true;
            this.dataGridViewBigram.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewBigram.Size = new System.Drawing.Size(470, 511);
            this.dataGridViewBigram.TabIndex = 1;
            // 
            // tabTrigram
            // 
            this.tabTrigram.Controls.Add(this.dataGridViewTrigram);
            this.tabTrigram.Location = new System.Drawing.Point(4, 22);
            this.tabTrigram.Name = "tabTrigram";
            this.tabTrigram.Size = new System.Drawing.Size(470, 511);
            this.tabTrigram.TabIndex = 6;
            this.tabTrigram.Text = "Trigram";
            this.tabTrigram.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTrigram
            // 
            this.dataGridViewTrigram.AllowUserToAddRows = false;
            this.dataGridViewTrigram.AllowUserToDeleteRows = false;
            this.dataGridViewTrigram.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTrigram.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Key1,
            this.Value1,
            this.Prob1});
            this.dataGridViewTrigram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTrigram.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTrigram.Name = "dataGridViewTrigram";
            this.dataGridViewTrigram.ReadOnly = true;
            this.dataGridViewTrigram.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewTrigram.Size = new System.Drawing.Size(470, 511);
            this.dataGridViewTrigram.TabIndex = 2;
            // 
            // txtOriginal
            // 
            this.txtOriginal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOriginal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtOriginal.Location = new System.Drawing.Point(0, 0);
            this.txtOriginal.Name = "txtOriginal";
            this.txtOriginal.Size = new System.Drawing.Size(465, 537);
            this.txtOriginal.TabIndex = 0;
            this.txtOriginal.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.txt|*.doc|*.docx";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // KeyTrap
            // 
            this.KeyTrap.HeaderText = "نشانه";
            this.KeyTrap.Name = "KeyTrap";
            this.KeyTrap.ReadOnly = true;
            // 
            // ValueTrap
            // 
            this.ValueTrap.HeaderText = "تعداد";
            this.ValueTrap.Name = "ValueTrap";
            this.ValueTrap.ReadOnly = true;
            // 
            // ProbTrap
            // 
            this.ProbTrap.HeaderText = "احتمال";
            this.ProbTrap.Name = "ProbTrap";
            this.ProbTrap.ReadOnly = true;
            this.ProbTrap.Width = 150;
            // 
            // KeyWord
            // 
            this.KeyWord.HeaderText = "لغت";
            this.KeyWord.Name = "KeyWord";
            this.KeyWord.ReadOnly = true;
            // 
            // ValueWord
            // 
            this.ValueWord.HeaderText = "تعداد";
            this.ValueWord.Name = "ValueWord";
            this.ValueWord.ReadOnly = true;
            // 
            // ProbWord
            // 
            this.ProbWord.HeaderText = "احتمال";
            this.ProbWord.Name = "ProbWord";
            this.ProbWord.ReadOnly = true;
            this.ProbWord.Width = 150;
            // 
            // KeyDigit
            // 
            this.KeyDigit.HeaderText = "عدد";
            this.KeyDigit.Name = "KeyDigit";
            this.KeyDigit.ReadOnly = true;
            // 
            // ValueDigit
            // 
            this.ValueDigit.HeaderText = "تعداد";
            this.ValueDigit.Name = "ValueDigit";
            this.ValueDigit.ReadOnly = true;
            // 
            // ProbDigit
            // 
            this.ProbDigit.HeaderText = "احتمال";
            this.ProbDigit.Name = "ProbDigit";
            this.ProbDigit.ReadOnly = true;
            this.ProbDigit.Width = 150;
            // 
            // KeyMark
            // 
            this.KeyMark.HeaderText = "نشانه";
            this.KeyMark.Name = "KeyMark";
            this.KeyMark.ReadOnly = true;
            // 
            // ValueMark
            // 
            this.ValueMark.HeaderText = "تعداد";
            this.ValueMark.Name = "ValueMark";
            this.ValueMark.ReadOnly = true;
            // 
            // ProbMark
            // 
            this.ProbMark.HeaderText = "احتمال";
            this.ProbMark.Name = "ProbMark";
            this.ProbMark.ReadOnly = true;
            this.ProbMark.Width = 150;
            // 
            // Key
            // 
            this.Key.HeaderText = "شرط";
            this.Key.Name = "Key";
            this.Key.ReadOnly = true;
            this.Key.Width = 120;
            // 
            // Value
            // 
            this.Value.HeaderText = "تعداد";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Prob
            // 
            this.Prob.HeaderText = "احتمال";
            this.Prob.Name = "Prob";
            this.Prob.ReadOnly = true;
            this.Prob.Width = 150;
            // 
            // Key1
            // 
            this.Key1.HeaderText = "شرط";
            this.Key1.Name = "Key1";
            this.Key1.ReadOnly = true;
            this.Key1.Width = 120;
            // 
            // Value1
            // 
            this.Value1.HeaderText = "تعداد";
            this.Value1.Name = "Value1";
            this.Value1.ReadOnly = true;
            // 
            // Prob1
            // 
            this.Prob1.HeaderText = "احتمال";
            this.Prob1.Name = "Prob1";
            this.Prob1.ReadOnly = true;
            this.Prob1.Width = 150;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 639);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabWord.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWord)).EndInit();
            this.tabDigit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDigit)).EndInit();
            this.tabTrap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrap)).EndInit();
            this.tabMark.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMark)).EndInit();
            this.tabSentence.ResumeLayout(false);
            this.tabBigram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBigram)).EndInit();
            this.tabTrigram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTrigram)).EndInit();
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabWord;
        private System.Windows.Forms.TabPage tabDigit;
        private System.Windows.Forms.TabPage tabTrap;
        private System.Windows.Forms.TabPage tabMark;
        private System.Windows.Forms.TabPage tabSentence;
        private System.Windows.Forms.TabPage tabBigram;
        private System.Windows.Forms.TabPage tabTrigram;
        private System.Windows.Forms.ListBox listBoxSentence;
        private System.Windows.Forms.RichTextBox txtOriginal;
        private System.Windows.Forms.DataGridView dataGridViewBigram;
        private System.Windows.Forms.DataGridView dataGridViewTrigram;
        private System.Windows.Forms.DataGridView dataGridViewDigit;
        private System.Windows.Forms.DataGridView dataGridViewTrap;
        private System.Windows.Forms.DataGridView dataGridViewMark;
        private System.Windows.Forms.DataGridView dataGridViewWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyTrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueTrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProbTrap;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProbWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyDigit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueDigit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProbDigit;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProbMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prob;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prob1;
    }
}

