using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Collections;
using System.Threading;
using HtmlAgilityPack;

namespace TokenExtraction
{
    public partial class Form1 : Form
    {
        //--------- Variables -------                        
        //---------------------------
        public Form1()
        {
            InitializeComponent();
        }

        private static Regex _removeRepeatedWhitespaceRegex = new Regex(@"(\s|\n|\r){2,}", RegexOptions.Singleline | RegexOptions.IgnoreCase);


        //public void Extract_all_text_from_webpage(string str)
        //{
        //    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
        //    document.Load(new MemoryStream(File.ReadAllBytes(str)));
        //    Console.WriteLine(ExtractViewableTextCleaned(document.DocumentNode));
        //}

        public static string ExtractViewableTextCleaned(HtmlNode node)
        {
            string textWithLotsOfWhiteSpaces = ExtractViewableText(node);
            return _removeRepeatedWhitespaceRegex.Replace(textWithLotsOfWhiteSpaces, " ");
        }

        public static string ExtractViewableText(HtmlNode node)
        {
            StringBuilder sb = new StringBuilder();
            ExtractViewableTextHelper(sb, node);
            return sb.ToString();
        }

        private static void ExtractViewableTextHelper(StringBuilder sb, HtmlNode node)
        {
            if (node.Name != "script" && node.Name != "style")
            {
                if (node.NodeType == HtmlNodeType.Text)
                {
                    AppendNodeText(sb, node);
                }

                foreach (HtmlNode child in node.ChildNodes)
                {
                    ExtractViewableTextHelper(sb, child);
                }
            }
        }

        private static void AppendNodeText(StringBuilder sb, HtmlNode node)
        {
            string text = ((HtmlTextNode)node).Text;
            if (string.IsNullOrWhiteSpace(text) == false)
            {
                sb.Append(text);

                // If the last char isn't a white-space, add a white space
                // otherwise words will be added ontop of each other when they're only separated by
                // tags
                if (text.EndsWith("\t") || text.EndsWith("\n") || text.EndsWith(" ") || text.EndsWith("\r"))
                {
                    // We're good!
                }
                else
                {
                    sb.Append(" ");
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "HTML File(*.html)|*.html|HTML File(*.htm)|*.htm";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.Load(new MemoryStream(File.ReadAllBytes(openFileDialog1.FileName)), UnicodeEncoding.UTF8 );
                txtOriginal.Text = ExtractViewableTextCleaned(document.DocumentNode).Replace("&gt;", "").Replace("&nbsp;", "");
                //StreamReader file = new StreamReader(openFileDialog1.FileName);
                //txtOriginal.Text = file.ReadToEnd();
                lbFileName.Text = openFileDialog1.FileName;
                //file.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Regex_Patterns.Instance.ClearDigitList();
            Regex_Patterns.Instance.ClearMarkList();
            Regex_Patterns.Instance.ClearTrapList();
            Regex_Patterns.Instance.ClearWordList();
            Regex_Patterns.Instance.ClearSentenceList();
            Regex_Patterns.Instance.ClearTokensList();
            dataGridViewBigram.Rows.Clear();
            dataGridViewDigit.Rows.Clear();
            dataGridViewMark.Rows.Clear();
            listBoxSentence.Items.Clear();
            dataGridViewTrap.Rows.Clear();
            dataGridViewTrigram.Rows.Clear();
            dataGridViewWord.Rows.Clear();

            Regex_Patterns.Instance.Tape = txtOriginal.Text;
            Regex_Patterns.Instance.HeadTape = -1;

            new S_State().Compute();
            while (Regex_Patterns.Instance.State != StateMark.None)
            {
                switch (Regex_Patterns.Instance.State)
                {
                    case StateMark.QD1:
                        new QD1_State().Compute();
                        break;
                    case StateMark.QD2:
                        new QD2_State().Compute();
                        break;
                    case StateMark.QDF:
                        new QDF_State().Compute();
                        break;
                    case StateMark.QL1:
                        new QL1_State().Compute();
                        break;
                    case StateMark.QL2:
                        new QL2_State().Compute();
                        break;
                    case StateMark.QL3:
                        new QL3_State().Compute();
                        break;
                    case StateMark.QL4:
                        new QL4_State().Compute();
                        break;
                    case StateMark.QLF:
                        new QLF_State().Compute();
                        break;
                    case StateMark.QTrap:
                        new Qtrap_State().Compute();
                        break;
                    case StateMark.Start:
                        new S_State().Compute();
                        break;
                    case StateMark.None:
                        break;
                }
            }

            SortedList<string, double> TrapList = Regex_Patterns.Instance._TrapList;
            SortedList<string, double> WordList = Regex_Patterns.Instance._WordList;
            SortedList<string, double> DigitList = Regex_Patterns.Instance._DigitList;
            SortedList<string, double> MarkList = Regex_Patterns.Instance._MarkList;

            SortedList<string, double> TrapListClone = new SortedList<string,double>();
            SortedList<string, double> WordListClone = new SortedList<string, double>();
            SortedList<string, double> DigitListClone = new SortedList<string, double>();
            SortedList<string, double> MarkListClone = new SortedList<string, double>();

            double listsNumber = 0;
            foreach (object key in TrapList.Keys)
                listsNumber += TrapList[key.ToString()];
            foreach (object key in WordList.Keys)
                listsNumber += WordList[key.ToString()];
            foreach (object key in DigitList.Keys)
                listsNumber += DigitList[key.ToString()];
            foreach (object key in MarkList.Keys)
                listsNumber += MarkList[key.ToString()];

            foreach (object key in TrapList.Keys)
            {
                int i = dataGridViewTrap.Rows.Add(1);
                dataGridViewTrap.Rows[i].Cells["KeyTrap"].Value = key.ToString();
                double number = TrapList[key.ToString()];
                dataGridViewTrap.Rows[i].Cells["ValueTrap"].Value = number;
                double probe = number / listsNumber;
                TrapListClone.Add(key.ToString(), probe);
                dataGridViewTrap.Rows[i].Cells["ProbTrap"].Value = probe;
            }
            Regex_Patterns.Instance._TrapList = TrapListClone;

            foreach (object key in WordList.Keys)
            {
                int i = dataGridViewWord.Rows.Add(1);
                dataGridViewWord.Rows[i].Cells["KeyWord"].Value = key.ToString();
                double number = WordList[key.ToString()];
                dataGridViewWord.Rows[i].Cells["ValueWord"].Value = number;
                double probe = number / listsNumber;
                WordListClone.Add(key.ToString(), probe);
                dataGridViewWord.Rows[i].Cells["ProbWord"].Value = probe;
            }
            Regex_Patterns.Instance._WordList = WordListClone;
            
            foreach (object key in DigitList.Keys)
            {
                int i = dataGridViewDigit.Rows.Add(1);
                dataGridViewDigit.Rows[i].Cells["KeyDigit"].Value = key.ToString();
                double number = DigitList[key.ToString()];
                dataGridViewDigit.Rows[i].Cells["ValueDigit"].Value = number;
                double probe = number / listsNumber;
                DigitListClone.Add(key.ToString(), probe);
                dataGridViewDigit.Rows[i].Cells["ProbDigit"].Value = probe;
            }
            Regex_Patterns.Instance._DigitList = DigitListClone;
            
            foreach (object key in MarkList.Keys)
            {
                int i = dataGridViewMark.Rows.Add(1);
                dataGridViewMark.Rows[i].Cells["KeyMark"].Value = key.ToString();
                double number = MarkList[key.ToString()];
                dataGridViewMark.Rows[i].Cells["ValueMark"].Value = number;
                double probe = number / listsNumber;
                MarkListClone.Add(key.ToString(), probe);
                dataGridViewMark.Rows[i].Cells["ProbMark"].Value = probe;
            }
            Regex_Patterns.Instance._MarkList = MarkListClone;

            List<ArrayList> sentences = Regex_Patterns.Instance._SentenceList;
            foreach (ArrayList array in sentences)
            {
                string sentence = String.Empty;
                foreach (object word in array)
                    sentence += word.ToString();
                listBoxSentence.Items.Add(sentence);
            }

            SortedList<string, double> bigram = Regex_Patterns.Instance.FillBigram();
            SortedList<string, double> trigram = Regex_Patterns.Instance.FillTrigram();
            SortedList<string, double> bigramClone = new SortedList<string, double>();
            SortedList<string, double> trigramClone = new SortedList<string, double>();

            double bigramNumber = 0;
            foreach (object key in bigram.Keys)
                bigramNumber += bigram[key.ToString()];
            double trigramNumber = 0;
            foreach (object key in trigram.Keys)
                trigramNumber += trigram[key.ToString()];

            foreach (object key in bigram.Keys)
            {
                int  i = dataGridViewBigram.Rows.Add(1);
                dataGridViewBigram.Rows[i].Cells["Key"].Value = key.ToString();
                double number = bigram[key.ToString()];
                dataGridViewBigram.Rows[i].Cells["Value"].Value = number;
                double probe = number / bigramNumber;
                bigramClone.Add(key.ToString(), probe);
                dataGridViewBigram.Rows[i].Cells["Prob"].Value = probe;
            }
            Regex_Patterns.Instance._BigramList = bigramClone;

            foreach (object key in trigram.Keys)
            {
                int i = dataGridViewTrigram.Rows.Add(1);
                dataGridViewTrigram.Rows[i].Cells["Key1"].Value = key.ToString();
                double number = trigram[key.ToString()];
                dataGridViewTrigram.Rows[i].Cells["Value1"].Value = trigram[key.ToString()];
                double probe = number / trigramNumber;
                trigramClone.Add(key.ToString(), probe);
                dataGridViewTrigram.Rows[i].Cells["Prob1"].Value = probe;
            }
            Regex_Patterns.Instance._TrigramList = trigramClone;
        }
    }
}
