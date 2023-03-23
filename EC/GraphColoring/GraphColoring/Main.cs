using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic.PowerPacks;

namespace GraphColoring
{
    enum ShapeType
    {
        None,
        Circle,
        StartLine,
        EndLine
    }

    public partial class Main : Form
    {
        #region Global Variable
        private OvalShape node;
        private LineShape line;
        private ShapeContainer shapeContainer1;
        private ShapeType shape = ShapeType.None;
        int countNode = 0;
        int firstOval = 0;
        Hashtable edges = new Hashtable();
        List<Array> population;
        int[] fitness;
        #endregion

        public Main()
        {
            InitializeComponent();

            #region Set ComboBox
            comboBoxCrossOver.SelectedIndex = 0;
            comboBoxMutation.SelectedIndex = 0;
            comboBoxReplacement.SelectedIndex = 0;
            comboBoxSelection.SelectedIndex = 0;
            #endregion

            #region Make Shap Container
            shapeContainer1 = new ShapeContainer();
            shapeContainer1.Location = new System.Drawing.Point(203, 3);
            shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            shapeContainer1.Name = "shapeContainer1";
            shapeContainer1.Dock = DockStyle.Fill;
            //shapeContainer1.Shapes.AddRange(new Shape[] {
            //this.lineShape1});
            shapeContainer1.Size = new System.Drawing.Size(717, 483);
            shapeContainer1.TabIndex = 5;
            shapeContainer1.TabStop = false;
            mainPanel.Controls.Add(shapeContainer1);
            #endregion
        }

        #region Cancel Buttons
        private void buttonNew_Click(object sender, EventArgs e)
        {
            node = null;
            line = null;
            shape = ShapeType.None;
            mainPanel.Cursor = DefaultCursor;
            countNode = 0;
            firstOval = 0;
            edges.Clear();
            shapeContainer1.Shapes.Clear();
            numericUpDownColor.Value = numericUpDownColor.Minimum;
            flowLayoutPanelColorButton.Controls.Clear();
        }

        private void uiPanelManager1_GroupSelectedPanelChanged(object sender, Janus.Windows.UI.Dock.GroupSelectedPanelChangedEventArgs e)
        {
            mainPanel.Cursor = DefaultCursor;
            shape = ShapeType.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainPanel.Cursor = DefaultCursor;
            shape = ShapeType.None;
        }

        private void numericUpDownColor_Enter(object sender, EventArgs e)
        {
            mainPanel.Cursor = DefaultCursor;
            shape = ShapeType.None;
        } 
        #endregion

        #region Draw Graph
        private void buttonCircle_Click(object sender, EventArgs e)
        {
            mainPanel.Cursor = Cursors.NoMove2D;
            shape = ShapeType.Circle;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            mainPanel.Cursor = Cursors.No;
            shape = ShapeType.StartLine;
        }

        private void mainPanel_Click(object sender, EventArgs e)
        {
            if (shape == ShapeType.Circle)
            {
                node = new OvalShape();
                Point point = new Point(mainPanel.PointToClient(MousePosition).X - 20, mainPanel.PointToClient(MousePosition).Y - 20);
                node.Location = point;
                node.BorderWidth = 2;
                node.FillStyle = FillStyle.Solid;
                node.FillColor = Color.White;
                node.Name = (++countNode).ToString();
                node.Size = new System.Drawing.Size(40, 40);
                node.Click += new EventHandler(node_Click);
                node.MouseEnter += new EventHandler(node_MouseEnter);
                node.MouseLeave += new EventHandler(node_MouseLeave);
                shapeContainer1.Shapes.Add(node);
                shape = ShapeType.Circle;

                edges.Add(countNode, new ArrayList());
            }
        }

        void node_MouseLeave(object sender, EventArgs e)
        {
            if (shape == ShapeType.StartLine || shape == ShapeType.EndLine)
            {
                mainPanel.Cursor = Cursors.No;
            }
        }

        void node_MouseEnter(object sender, EventArgs e)
        {
            if (shape == ShapeType.StartLine || shape == ShapeType.EndLine)
            {
                mainPanel.Cursor = Cursors.Cross;
            }
        }

        private void node_Click(object sender, EventArgs e)
        {
            if (shape == ShapeType.StartLine)
            {
                line = new LineShape();
                line.BorderWidth = 3;
                firstOval = int.Parse(((OvalShape)sender).Name);
                line.X1 = ((OvalShape)sender).Location.X + 20;
                line.Y1 = ((OvalShape)sender).Location.Y + 20;
                shape = ShapeType.EndLine;
            }
            else
            {
                if (shape == ShapeType.EndLine)
                {
                    int secondOval = int.Parse(((OvalShape)sender).Name);
                    if (firstOval != secondOval)
                    {
                        line.X2 = ((OvalShape)sender).Location.X + 20;
                        line.Y2 = ((OvalShape)sender).Location.Y + 20;
                        shapeContainer1.Shapes.Add(line);

                        if (firstOval < secondOval)
                        {
                            ArrayList arr = (ArrayList)edges[firstOval];
                            arr.Add(secondOval);
                        }
                        else
                        {
                            ArrayList arr = (ArrayList)edges[secondOval];
                            arr.Add(firstOval);
                        }

                        shape = ShapeType.StartLine;
                        firstOval = 0;
                    }
                    else
                        MessageBox.Show("نود اول و دوم یکسان می باشد. نود دیگری را انتخاب نمائید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }
        #endregion

        #region Coloring Button
        void buttonColor_Click(object sender, EventArgs e)
        {
            bool test = true;
            Button btn = (Button)sender;
            while (test && colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (!ExistColor_in_ButtonColor(colorDialog1.Color))
                {
                    btn.BackColor = colorDialog1.Color;
                    test = false;
                }
                else
                {
                    MessageBox.Show("رنگ انتخابی شما تکراری می باشد. رنگ دیگری انتخاب نمائید.", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                }
            }
        }

        private void numericUpDownColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                flowLayoutPanelColorButton.Controls.Clear();
                Create_ColorButton();
            }
        }

        private void Create_ColorButton()
        {
            for (decimal i = 1; i <= numericUpDownColor.Value; i++)
            {
                Button buttonColor = new Button();
                buttonColor.Text = "";
                Random randColor = new Random();
                Color color = Color.FromArgb(randColor.Next(0, 256), randColor.Next(0, 256), randColor.Next(0, 256));
                buttonColor.BackColor = color;
                while (ExistColor_in_ButtonColor(color))
                {
                    color = Color.FromArgb(randColor.Next(0, 256), randColor.Next(0, 256), randColor.Next(0, 256));
                    buttonColor.BackColor = color;
                }
                buttonColor.Name = "btn" + i.ToString();
                buttonColor.FlatStyle = FlatStyle.Flat;
                buttonColor.FlatAppearance.BorderSize = 1;
                buttonColor.Size = new Size(20, 20);
                buttonColor.Click += new EventHandler(buttonColor_Click);
                flowLayoutPanelColorButton.Controls.Add(buttonColor);
            }
        }

        private bool ExistColor_in_ButtonColor(Color color)
        {
            for (int i = 0; i < flowLayoutPanelColorButton.Controls.Count; i++)
            {
                Button btn = (Button)flowLayoutPanelColorButton.Controls[i];
                if (btn.BackColor == color)
                    return true;
            }
            return false;
        }
        #endregion

        #region Make First Generation & Execute
        private void buttonExecute_Click(object sender, EventArgs e)
        {
            FirstGeneration();
            bool fit = false;
            int fitIndex = -1;
            Fitness(out fit, out fitIndex);
            buttonExecute.Enabled = false;

            List<Array> medianPopulation = new List<Array>(population.Count);
            int generationNo = 1;
            int mainGenerationNo = int.Parse(numericUpDownGeneration.Value.ToString());

            while (generationNo <= mainGenerationNo && !fit)
            {
                switch (comboBoxSelection.SelectedIndex)
                {
                    case 0://Roulette
                        new Selection().Roulette(ref medianPopulation, population, fitness);
                        break;

                    case 1://Ranking
                        new Selection().Ranking(ref medianPopulation, population, fitness);
                        break;

                    case 2://Tournament
                        new Selection().Tournament(ref medianPopulation, population, fitness);
                        break;

                    case 3://SUS
                        new Selection().SUS(ref medianPopulation, population, fitness);
                        break;
                }

                switch (comboBoxCrossOver.SelectedIndex)
                {
                    case 0://Uniform
                        new CrossOver().Uniform(ref medianPopulation, (int)double.Parse(textBoxProbCrossOver.Text) * 100);
                        break;

                    case 1://1-Point
                        new CrossOver().PointByPoint(ref medianPopulation, (int)double.Parse(textBoxProbCrossOver.Text) * 100, 1);
                        break;

                    case 2://2-Point
                        new CrossOver().PointByPoint(ref medianPopulation, (int)double.Parse(textBoxProbCrossOver.Text) * 100, 2);
                        break;

                    case 3://3-Point
                        new CrossOver().PointByPoint(ref medianPopulation, (int)double.Parse(textBoxProbCrossOver.Text) * 100, 3);
                        break;
                }

                switch (comboBoxMutation.SelectedIndex)
                {
                    case 0://Bit Fliping
                        new Mutation().BitFliping(ref medianPopulation, (int)(double.Parse(textBoxProbMutation.Text) * 100), flowLayoutPanelColorButton.Controls.Count);
                        break;

                    case 1://Swap
                        new Mutation().Swap(ref medianPopulation, (int)(double.Parse(textBoxProbMutation.Text) * 100));
                        break;
                }

                switch (comboBoxReplacement.SelectedIndex)
                {
                    case 0://Generational With Elitism
                        new Replacement().GenerationalWithElitism(ref population, medianPopulation, Fitness(medianPopulation), fitness);
                        break;

                    case 1://Generational
                        new Replacement().Generational(ref population, medianPopulation);
                        break;

                    case 2://Steady State
                        new Replacement().SteadyState(ref population, medianPopulation, Fitness(medianPopulation), fitness);
                        break;
                }


                Fitness(out fit, out fitIndex);
                if (fit)
                {
                    if (MessageBox.Show("یک جواب پیدا شده است. آیا می خواهید ادامه دهید؟", "اطلاعیه", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) == DialogResult.Yes)
                    {
                        fit = false;

                        int[] bestChrom = (int[])population[fitIndex];
                        for (int i = 0; i < bestChrom.Length; i++)
                        {
                            ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillStyle = FillStyle.Solid;
                            ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillColor = ((Button)flowLayoutPanelColorButton.Controls["btn" + ((int[])population[fitIndex])[i].ToString()]).BackColor;
                            ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillGradientStyle = FillGradientStyle.Central;
                            ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillGradientColor = Color.White;
                        }
                    }
                }
                generationNo++;
            }

            if (fit)
            {
                int[] bestChrom = (int[])population[fitIndex];
                for (int i = 0; i < bestChrom.Length; i++)
                {
                    ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillStyle = FillStyle.Solid;
                    ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillColor = ((Button)flowLayoutPanelColorButton.Controls["btn" + ((int[])population[fitIndex])[i].ToString()]).BackColor;
                    ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillGradientStyle = FillGradientStyle.Central;
                    ((OvalShape)shapeContainer1.Shapes.get_Item(shapeContainer1.Shapes.IndexOfKey((i + 1).ToString()))).FillGradientColor = Color.White;
                }
            }
            else
                MessageBox.Show("با استفاده از الگوریتم ژنتیک با مشخصات تعریفی جوابی برای رنگ آمیزی یافت نشد.", "اطلاعیه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);

            buttonExecute.Enabled = true;
        }

        private void FirstGeneration()
        {
            int populationSize = int.Parse(numericUpDownPopulation.Value.ToString());
            population = new List<Array>(populationSize);
            fitness = new int[populationSize];

            Random rand = new Random();
            for (int i = 0; i < populationSize; i++)
            {
                int[] chromosome = new int[countNode];
                for (int j = 0; j < countNode; j++)
                {
                    chromosome[j] = rand.Next(1, flowLayoutPanelColorButton.Controls.Count + 1);
                }
                population.Add(chromosome);
            }
        }

        private void Fitness(out bool fit, out int fitIndex)
        {
            fit = false;
            fitIndex = -1;
            for (int i = 0; i < fitness.Length; i++)
            {
                int[] chromosome = (int[])population[i];
                int fitnessCount = 0;
                for (int j = 1; j <= chromosome.Length; j++)
                {
                    ArrayList tempEdge = (ArrayList)((ArrayList)edges[j]).Clone();
                    for (int k = 0; k < tempEdge.Count; k++)
                    {
                        if (chromosome[int.Parse(tempEdge[k].ToString()) - 1] == chromosome[j - 1])
                            fitnessCount++;
                    }
                }
                fitness[i] = fitnessCount;

                if (fitnessCount == 0)
                {
                    fit = true;
                    fitIndex = i;
                }
            }
        }

        private int[] Fitness(List<Array> medianPopulation)
        {
            int[] medianFitness = new int[medianPopulation.Count];
            for (int i = 0; i < medianFitness.Length; i++)
            {
                int[] chromosome = (int[])medianPopulation[i];
                int fitnessCount = 0;
                for (int j = 1; j <= chromosome.Length; j++)
                {
                    ArrayList tempEdge = (ArrayList)edges[j];
                    for (int k = 0; k < tempEdge.Count; k++)
                    {
                        if (chromosome[int.Parse(tempEdge[k].ToString()) - 1] == chromosome[j - 1])
                            fitnessCount++;
                    }
                }
                medianFitness[i] = fitnessCount;
            }
            return medianFitness;
        }
        #endregion
    }
}
