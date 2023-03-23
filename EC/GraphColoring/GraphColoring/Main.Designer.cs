namespace GraphColoring
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.uiPanelManager1 = new Janus.Windows.UI.Dock.UIPanelManager(this.components);
            this.uiPanelNavigator = new Janus.Windows.UI.Dock.UIPanelGroup();
            this.uiPanelGraph = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanelGraphContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.flowLayoutPanelColorButton = new System.Windows.Forms.FlowLayoutPanel();
            this.numericUpDownColor = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonLine = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            this.uiPanelParameters = new Janus.Windows.UI.Dock.UIPanel();
            this.uiPanelParametersContainer = new Janus.Windows.UI.Dock.UIPanelInnerContainer();
            this.buttonExecute = new System.Windows.Forms.Button();
            this.textBoxProbMutation = new System.Windows.Forms.MaskedTextBox();
            this.textBoxProbCrossOver = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDownGeneration = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPopulation = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.comboBoxReplacement = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxMutation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCrossOver = new System.Windows.Forms.ComboBox();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelNavigator)).BeginInit();
            this.uiPanelNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGraph)).BeginInit();
            this.uiPanelGraph.SuspendLayout();
            this.uiPanelGraphContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelParameters)).BeginInit();
            this.uiPanelParameters.SuspendLayout();
            this.uiPanelParametersContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiPanelManager1
            // 
            this.uiPanelManager1.ContainerControl = this;
            this.uiPanelManager1.GroupSelectedPanelChanged += new Janus.Windows.UI.Dock.GroupSelectedPanelChangedEventHandler(this.uiPanelManager1_GroupSelectedPanelChanged);
            this.uiPanelNavigator.Id = new System.Guid("4400b1d6-e9fb-465e-9ed6-9f05b40b7593");
            this.uiPanelNavigator.StaticGroup = true;
            this.uiPanelGraph.Id = new System.Guid("3ed2984f-5370-4cc3-927c-fd5eea550c86");
            this.uiPanelNavigator.Panels.Add(this.uiPanelGraph);
            this.uiPanelParameters.Id = new System.Guid("a0152498-1b97-463f-bd96-42f9b7ed65da");
            this.uiPanelNavigator.Panels.Add(this.uiPanelParameters);
            this.uiPanelManager1.Panels.Add(this.uiPanelNavigator);
            // 
            // Design Time Panel Info:
            // 
            this.uiPanelManager1.BeginPanelInfo();
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("68928eae-b767-40f0-af30-b979e9e47102"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(200, 483), false);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("3f330227-bf34-4e5f-aa25-86b33a56443e"), Janus.Windows.UI.Dock.PanelDockStyle.Left, new System.Drawing.Size(200, 483), false);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("4400b1d6-e9fb-465e-9ed6-9f05b40b7593"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, Janus.Windows.UI.Dock.PanelDockStyle.Left, true, new System.Drawing.Size(190, 596), true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("3ed2984f-5370-4cc3-927c-fd5eea550c86"), new System.Guid("4400b1d6-e9fb-465e-9ed6-9f05b40b7593"), -1, true);
            this.uiPanelManager1.AddDockPanelInfo(new System.Guid("a0152498-1b97-463f-bd96-42f9b7ed65da"), new System.Guid("4400b1d6-e9fb-465e-9ed6-9f05b40b7593"), -1, true);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("4400b1d6-e9fb-465e-9ed6-9f05b40b7593"), Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator, true, new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("3ed2984f-5370-4cc3-927c-fd5eea550c86"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.AddFloatingPanelInfo(new System.Guid("a0152498-1b97-463f-bd96-42f9b7ed65da"), new System.Drawing.Point(-1, -1), new System.Drawing.Size(-1, -1), false);
            this.uiPanelManager1.EndPanelInfo();
            // 
            // uiPanelNavigator
            // 
            this.uiPanelNavigator.GroupStyle = Janus.Windows.UI.Dock.PanelGroupStyle.OutlookNavigator;
            this.uiPanelNavigator.Location = new System.Drawing.Point(3, 3);
            this.uiPanelNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiPanelNavigator.Name = "uiPanelNavigator";
            this.uiPanelNavigator.SelectedPanel = this.uiPanelGraph;
            this.uiPanelNavigator.Size = new System.Drawing.Size(190, 596);
            this.uiPanelNavigator.TabIndex = 4;
            // 
            // uiPanelGraph
            // 
            this.uiPanelGraph.InnerContainer = this.uiPanelGraphContainer;
            this.uiPanelGraph.Location = new System.Drawing.Point(0, 0);
            this.uiPanelGraph.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiPanelGraph.Name = "uiPanelGraph";
            this.uiPanelGraph.Size = new System.Drawing.Size(186, 494);
            this.uiPanelGraph.TabIndex = 4;
            this.uiPanelGraph.Text = "رسم گراف";
            // 
            // uiPanelGraphContainer
            // 
            this.uiPanelGraphContainer.AutoScroll = true;
            this.uiPanelGraphContainer.Controls.Add(this.flowLayoutPanelColorButton);
            this.uiPanelGraphContainer.Controls.Add(this.numericUpDownColor);
            this.uiPanelGraphContainer.Controls.Add(this.label1);
            this.uiPanelGraphContainer.Controls.Add(this.buttonNew);
            this.uiPanelGraphContainer.Controls.Add(this.buttonLine);
            this.uiPanelGraphContainer.Controls.Add(this.buttonCircle);
            this.uiPanelGraphContainer.Location = new System.Drawing.Point(1, 24);
            this.uiPanelGraphContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiPanelGraphContainer.Name = "uiPanelGraphContainer";
            this.uiPanelGraphContainer.Size = new System.Drawing.Size(184, 470);
            this.uiPanelGraphContainer.TabIndex = 0;
            // 
            // flowLayoutPanelColorButton
            // 
            this.flowLayoutPanelColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelColorButton.AutoScroll = true;
            this.flowLayoutPanelColorButton.Location = new System.Drawing.Point(-1, 275);
            this.flowLayoutPanelColorButton.Name = "flowLayoutPanelColorButton";
            this.flowLayoutPanelColorButton.Size = new System.Drawing.Size(177, 209);
            this.flowLayoutPanelColorButton.TabIndex = 5;
            // 
            // numericUpDownColor
            // 
            this.numericUpDownColor.Location = new System.Drawing.Point(54, 246);
            this.numericUpDownColor.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownColor.Name = "numericUpDownColor";
            this.numericUpDownColor.Size = new System.Drawing.Size(77, 23);
            this.numericUpDownColor.TabIndex = 4;
            this.numericUpDownColor.Enter += new System.EventHandler(this.numericUpDownColor_Enter);
            this.numericUpDownColor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numericUpDownColor_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "تعداد رنگ: ";
            // 
            // buttonNew
            // 
            this.buttonNew.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNew.Image = global::GraphColoring.Properties.Resources.New;
            this.buttonNew.Location = new System.Drawing.Point(65, 6);
            this.buttonNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(58, 62);
            this.buttonNew.TabIndex = 2;
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonLine
            // 
            this.buttonLine.FlatAppearance.BorderSize = 0;
            this.buttonLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLine.Image = global::GraphColoring.Properties.Resources.Line;
            this.buttonLine.Location = new System.Drawing.Point(65, 145);
            this.buttonLine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonLine.Name = "buttonLine";
            this.buttonLine.Size = new System.Drawing.Size(58, 62);
            this.buttonLine.TabIndex = 1;
            this.buttonLine.UseVisualStyleBackColor = true;
            this.buttonLine.Click += new System.EventHandler(this.buttonLine_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonCircle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.buttonCircle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonCircle.Image = global::GraphColoring.Properties.Resources.Circle;
            this.buttonCircle.Location = new System.Drawing.Point(65, 75);
            this.buttonCircle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(58, 62);
            this.buttonCircle.TabIndex = 0;
            this.buttonCircle.UseVisualStyleBackColor = true;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // uiPanelParameters
            // 
            this.uiPanelParameters.InnerContainer = this.uiPanelParametersContainer;
            this.uiPanelParameters.Location = new System.Drawing.Point(0, 0);
            this.uiPanelParameters.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiPanelParameters.Name = "uiPanelParameters";
            this.uiPanelParameters.Size = new System.Drawing.Size(186, 494);
            this.uiPanelParameters.TabIndex = 4;
            this.uiPanelParameters.Text = "پارامترها";
            // 
            // uiPanelParametersContainer
            // 
            this.uiPanelParametersContainer.AutoScroll = true;
            this.uiPanelParametersContainer.Controls.Add(this.buttonExecute);
            this.uiPanelParametersContainer.Controls.Add(this.textBoxProbMutation);
            this.uiPanelParametersContainer.Controls.Add(this.textBoxProbCrossOver);
            this.uiPanelParametersContainer.Controls.Add(this.label12);
            this.uiPanelParametersContainer.Controls.Add(this.label11);
            this.uiPanelParametersContainer.Controls.Add(this.label10);
            this.uiPanelParametersContainer.Controls.Add(this.label9);
            this.uiPanelParametersContainer.Controls.Add(this.label8);
            this.uiPanelParametersContainer.Controls.Add(this.numericUpDownGeneration);
            this.uiPanelParametersContainer.Controls.Add(this.numericUpDownPopulation);
            this.uiPanelParametersContainer.Controls.Add(this.label7);
            this.uiPanelParametersContainer.Controls.Add(this.label6);
            this.uiPanelParametersContainer.Controls.Add(this.label5);
            this.uiPanelParametersContainer.Controls.Add(this.label4);
            this.uiPanelParametersContainer.Controls.Add(this.comboBoxSelection);
            this.uiPanelParametersContainer.Controls.Add(this.comboBoxReplacement);
            this.uiPanelParametersContainer.Controls.Add(this.label3);
            this.uiPanelParametersContainer.Controls.Add(this.comboBoxMutation);
            this.uiPanelParametersContainer.Controls.Add(this.label2);
            this.uiPanelParametersContainer.Controls.Add(this.comboBoxCrossOver);
            this.uiPanelParametersContainer.Location = new System.Drawing.Point(1, 24);
            this.uiPanelParametersContainer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uiPanelParametersContainer.Name = "uiPanelParametersContainer";
            this.uiPanelParametersContainer.Size = new System.Drawing.Size(184, 470);
            this.uiPanelParametersContainer.TabIndex = 0;
            // 
            // buttonExecute
            // 
            this.buttonExecute.BackColor = System.Drawing.Color.Lime;
            this.buttonExecute.Location = new System.Drawing.Point(16, 424);
            this.buttonExecute.Name = "buttonExecute";
            this.buttonExecute.Size = new System.Drawing.Size(149, 36);
            this.buttonExecute.TabIndex = 18;
            this.buttonExecute.Text = "اجرا";
            this.buttonExecute.UseVisualStyleBackColor = false;
            this.buttonExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // textBoxProbMutation
            // 
            this.textBoxProbMutation.Location = new System.Drawing.Point(15, 150);
            this.textBoxProbMutation.Mask = ".00";
            this.textBoxProbMutation.Name = "textBoxProbMutation";
            this.textBoxProbMutation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxProbMutation.Size = new System.Drawing.Size(39, 23);
            this.textBoxProbMutation.TabIndex = 4;
            this.textBoxProbMutation.Text = "50";
            // 
            // textBoxProbCrossOver
            // 
            this.textBoxProbCrossOver.Location = new System.Drawing.Point(15, 60);
            this.textBoxProbCrossOver.Mask = ".00";
            this.textBoxProbCrossOver.Name = "textBoxProbCrossOver";
            this.textBoxProbCrossOver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxProbCrossOver.Size = new System.Drawing.Size(39, 23);
            this.textBoxProbCrossOver.TabIndex = 2;
            this.textBoxProbCrossOver.Text = "50";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 288);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(173, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "---------------------------------";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "---------------------------------";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 82);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(173, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "---------------------------------";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(60, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 16);
            this.label9.TabIndex = 13;
            this.label9.Text = "احتمال Mutation: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "احتمال CrossOver: ";
            // 
            // numericUpDownGeneration
            // 
            this.numericUpDownGeneration.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownGeneration.Location = new System.Drawing.Point(13, 341);
            this.numericUpDownGeneration.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDownGeneration.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDownGeneration.Name = "numericUpDownGeneration";
            this.numericUpDownGeneration.Size = new System.Drawing.Size(77, 23);
            this.numericUpDownGeneration.TabIndex = 8;
            this.numericUpDownGeneration.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // numericUpDownPopulation
            // 
            this.numericUpDownPopulation.Location = new System.Drawing.Point(13, 312);
            this.numericUpDownPopulation.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownPopulation.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPopulation.Name = "numericUpDownPopulation";
            this.numericUpDownPopulation.Size = new System.Drawing.Size(76, 23);
            this.numericUpDownPopulation.TabIndex = 7;
            this.numericUpDownPopulation.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(90, 344);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "تعداد نسل ها: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "جمعیت اولیه: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "انواع Selection:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "انواع Replacement:";
            // 
            // comboBoxSelection
            // 
            this.comboBoxSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelection.Items.AddRange(new object[] {
            "Roulette",
            "Ranking",
            "Tournament",
            "SUS"});
            this.comboBoxSelection.Location = new System.Drawing.Point(41, 264);
            this.comboBoxSelection.Name = "comboBoxSelection";
            this.comboBoxSelection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxSelection.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSelection.TabIndex = 6;
            // 
            // comboBoxReplacement
            // 
            this.comboBoxReplacement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReplacement.Items.AddRange(new object[] {
            "Generational + elitism",
            "Generational",
            "Steady State"});
            this.comboBoxReplacement.Location = new System.Drawing.Point(41, 212);
            this.comboBoxReplacement.Name = "comboBoxReplacement";
            this.comboBoxReplacement.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxReplacement.Size = new System.Drawing.Size(121, 24);
            this.comboBoxReplacement.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(73, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "انواع Mutation:";
            // 
            // comboBoxMutation
            // 
            this.comboBoxMutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMutation.Items.AddRange(new object[] {
            "Bit Fliping",
            "Swap"});
            this.comboBoxMutation.Location = new System.Drawing.Point(41, 120);
            this.comboBoxMutation.Name = "comboBoxMutation";
            this.comboBoxMutation.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxMutation.Size = new System.Drawing.Size(121, 24);
            this.comboBoxMutation.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "انواع CrossOver:";
            // 
            // comboBoxCrossOver
            // 
            this.comboBoxCrossOver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrossOver.Items.AddRange(new object[] {
            "Uniform",
            "1-pt",
            "2-pt",
            "3-pt"});
            this.comboBoxCrossOver.Location = new System.Drawing.Point(41, 31);
            this.comboBoxCrossOver.Name = "comboBoxCrossOver";
            this.comboBoxCrossOver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBoxCrossOver.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCrossOver.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.White;
            this.mainPanel.Controls.Add(this.buttonCancel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(193, 3);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(881, 596);
            this.mainPanel.TabIndex = 5;
            this.mainPanel.Click += new System.EventHandler(this.mainPanel_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(1, 1);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(1, 1);
            this.buttonCancel.TabIndex = 0;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(1077, 602);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.uiPanelNavigator);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(814, 484);
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "رنگ آمیزی گراف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelNavigator)).EndInit();
            this.uiPanelNavigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelGraph)).EndInit();
            this.uiPanelGraph.ResumeLayout(false);
            this.uiPanelGraphContainer.ResumeLayout(false);
            this.uiPanelGraphContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiPanelParameters)).EndInit();
            this.uiPanelParameters.ResumeLayout(false);
            this.uiPanelParametersContainer.ResumeLayout(false);
            this.uiPanelParametersContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGeneration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPopulation)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.UI.Dock.UIPanelManager uiPanelManager1;
        private Janus.Windows.UI.Dock.UIPanelGroup uiPanelNavigator;
        private Janus.Windows.UI.Dock.UIPanel uiPanelGraph;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanelGraphContainer;
        private Janus.Windows.UI.Dock.UIPanel uiPanelParameters;
        private Janus.Windows.UI.Dock.UIPanelInnerContainer uiPanelParametersContainer;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonLine;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelColorButton;
        private System.Windows.Forms.NumericUpDown numericUpDownColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCrossOver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxMutation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxReplacement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDownGeneration;
        private System.Windows.Forms.NumericUpDown numericUpDownPopulation;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox textBoxProbCrossOver;
        private System.Windows.Forms.MaskedTextBox textBoxProbMutation;
        private System.Windows.Forms.Button buttonExecute;
        private System.Windows.Forms.Button buttonCancel;

    }
}

