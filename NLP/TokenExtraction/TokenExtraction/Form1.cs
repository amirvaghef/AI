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

        #region HTML Extraction
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
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "HTML File(*.htm)|*.htm|HTML File(*.html)|*.html";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog1.FileName))
            {
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.Load(new MemoryStream(File.ReadAllBytes(openFileDialog1.FileName)), UnicodeEncoding.UTF8);
                txtOriginal.Text = ExtractViewableTextCleaned(document.DocumentNode).Replace("&gt;", "").Replace("&nbsp;", "").Replace("&quot;", "");
                //StreamReader file = new StreamReader(openFileDialog1.FileName);
                //txtOriginal.Text = file.ReadToEnd();
                lbFileName.Text = openFileDialog1.FileName;
                //file.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Clear Corpuse
            Regex_Patterns.Instance.ClearDigitList();
            Regex_Patterns.Instance.ClearMarkList();
            Regex_Patterns.Instance.ClearTrapList();
            Regex_Patterns.Instance.ClearWordList();
            Regex_Patterns.Instance.ClearBigramList();
            Regex_Patterns.Instance.ClearTrigramList();
            Regex_Patterns.Instance.ClearSentenceList();
            Regex_Patterns.Instance.ClearCurrentToken();
            Regex_Patterns.Instance.ClearCurrentSentences();
            //Regex_Patterns.Instance.ClearTokensList();
            dataGridViewBigram.Rows.Clear();
            dataGridViewDigit.Rows.Clear();
            dataGridViewMark.Rows.Clear();
            dataGridViewSentence.Rows.Clear();
            dataGridViewTrap.Rows.Clear();
            dataGridViewTrigram.Rows.Clear();
            dataGridViewWord.Rows.Clear();

            Encoding encoding1256 = Encoding.GetEncoding(1256);
            byte[] inputStrBuf = encoding1256.GetBytes(txtOriginal.Text);
            byte[] inputStrUtf8Buf = Encoding.Convert(encoding1256, Encoding.UTF8, inputStrBuf);
            txtOriginal.Text = Encoding.GetEncoding("utf-8").GetString(inputStrUtf8Buf);

            Regex_Patterns.Instance.Tape = txtOriginal.Text;
            Regex_Patterns.Instance.HeadTape = -1;
            #endregion

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

            SortedList<string, double> TrapListClone = new SortedList<string, double>();
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
            Regex_Patterns.Instance._TrapListCorpuse = TrapListClone;

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
            Regex_Patterns.Instance._WordListCorpuse = WordListClone;

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
            Regex_Patterns.Instance._DigitListCorpuse = DigitListClone;

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
            Regex_Patterns.Instance._MarkListCorpuse = MarkListClone;



            SortedList<string, double> bigram = Regex_Patterns.Instance.FillBigram();
            SortedList<string, double> trigram = Regex_Patterns.Instance.FillTrigram();
            SortedList<string, double> bigramClone = new SortedList<string, double>();
            SortedList<string, double> trigramClone = new SortedList<string, double>();

            //double bigramNumber = 0;
            //foreach (object key in bigram.Keys)
            //    bigramNumber += bigram[key.ToString()];
            //double trigramNumber = 0;
            //foreach (object key in trigram.Keys)
            //    trigramNumber += trigram[key.ToString()];

            foreach (object key in bigram.Keys)
            {
                int i = dataGridViewBigram.Rows.Add(1);
                dataGridViewBigram.Rows[i].Cells["Key"].Value = key.ToString();
                double number = bigram[key.ToString()];
                dataGridViewBigram.Rows[i].Cells["Value"].Value = number;

                string[] parts = key.ToString().Split(new string[] { " | " }, StringSplitOptions.None);
                double singleNumber = 1;
                if (parts[1] != "\n")
                {
                    if (parts[1] != "<s>")
                    {
                        if (TrapList.ContainsKey(parts[1].ToLower()))
                            singleNumber = TrapList[parts[1].ToLower()];
                        else
                            if (WordList.ContainsKey(parts[1].ToLower()))
                                singleNumber = WordList[parts[1].ToLower()];
                            else
                                if (DigitList.ContainsKey(parts[1].ToLower()))
                                    singleNumber = DigitList[parts[1].ToLower()];
                                else
                                    if (MarkList.ContainsKey(parts[1].ToLower()))
                                        singleNumber = MarkList[parts[1].ToLower()];
                                    else
                                        singleNumber = number;
                    }
                    else
                        singleNumber = Regex_Patterns.Instance._SentenceList.Count;
                }
                else
                    singleNumber = Regex_Patterns.Instance._SentenceList.Count;

                double probe = number / singleNumber;
                bigramClone.Add(key.ToString(), probe);
                dataGridViewBigram.Rows[i].Cells["Prob"].Value = probe;
            }
            Regex_Patterns.Instance._BigramListCorpuse = bigramClone;

            foreach (object key in trigram.Keys)
            {
                int i = dataGridViewTrigram.Rows.Add(1);
                dataGridViewTrigram.Rows[i].Cells["Key1"].Value = key.ToString();
                double number = trigram[key.ToString()];
                dataGridViewTrigram.Rows[i].Cells["Value1"].Value = trigram[key.ToString()];

                string[] parts = key.ToString().Split(new string[] {" | "}, StringSplitOptions.None)[1].Split(new string[] {" "}, StringSplitOptions.None);
                double doubleNumber = 1;
                if (parts[1] != "<s>")
                {
                    string bipart = parts[1] + " | " + parts[0];
                    if (bigram.ContainsKey(bipart))
                        doubleNumber = bigram[bipart];
                }
                else
                    doubleNumber = Regex_Patterns.Instance._SentenceList.Count;

                double probe = number / doubleNumber;
                trigramClone.Add(key.ToString(), probe);
                dataGridViewTrigram.Rows[i].Cells["Prob1"].Value = probe;
            }
            Regex_Patterns.Instance._TrigramListCorpuse = trigramClone;



            List<ArrayList> sentences = Regex_Patterns.Instance._SentenceList;
            double unigramAverage = 0;
            double bigramAverage = 0;
            double trigramAverage = 0;
            foreach (ArrayList array in sentences)
            {
                int o = dataGridViewSentence.Rows.Add(1);
                dataGridViewSentence.Rows[o].Cells["Sentence"].Value = GetSentence(array);
                double unigram1 = ProbeUnigram(array, TrapListClone, WordListClone, DigitListClone, MarkListClone);
                unigramAverage += unigram1;
                dataGridViewSentence.Rows[o].Cells["Unigram"].Value = unigram1;
                double bigram1 = ProbeBigram(array, bigramClone);
                bigramAverage += bigram1;
                dataGridViewSentence.Rows[o].Cells["Bigram"].Value = bigram1;
                double trigram1 = ProbeTrigram(array, trigramClone);
                trigramAverage += trigram1;
                dataGridViewSentence.Rows[o].Cells["Trigram"].Value = trigram1;
            }
            lblUnigram.Text = (unigramAverage / (double)sentences.Count).ToString();
            lblBigram.Text = (bigramAverage / (double)sentences.Count).ToString();
            lblTrigram.Text = (trigramAverage / (double)sentences.Count).ToString();
        }

        public string GetSentence(ArrayList array)
        {
            string sentence = "";
            foreach (object word in array)
                sentence += word.ToString() + " ";
            return sentence;
        }

        #region Probability
        public double ProbeUnigram(ArrayList Tokens, SortedList<string, double> TrapList, SortedList<string, double> WordList, SortedList<string, double> DigitList, SortedList<string, double> MarkList)
        {
            double probe = 1;
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (Tokens[i].ToString() != "\n")
                    if (TrapList.ContainsKey(Tokens[i].ToString().ToLower()))
                        probe = TrapList[Tokens[i].ToString().ToLower()] * probe;
                    else
                        if (WordList.ContainsKey(Tokens[i].ToString().ToLower()))
                            probe = WordList[Tokens[i].ToString().ToLower()] * probe;
                        else
                            if (DigitList.ContainsKey(Tokens[i].ToString().ToLower()))
                                probe = DigitList[Tokens[i].ToString().ToLower()] * probe;
                            else
                                if (MarkList.ContainsKey(Tokens[i].ToString().ToLower()))
                                    probe = MarkList[Tokens[i].ToString().ToLower()] * probe;
                                else
                                    return 0;
            }
            return Math.Pow(probe, (1 / (double)Tokens.Count));
        }

        public double ProbeBigram(ArrayList Tokens, SortedList<string, double> bigramList)
        {
            double probe = 1;
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (i == 0)
                {
                    if (bigramList.ContainsKey((Tokens[i] + " | <s>").ToLower()))
                        probe = bigramList[(Tokens[i] + " | <s>").ToLower()] * probe;
                    else
                        return 0;
                }
                else
                    if (!String.IsNullOrWhiteSpace(Tokens[i].ToString()))
                    {
                        if (bigramList.ContainsKey((Tokens[i].ToString() + " | " + Tokens[i - 1].ToString()).ToLower()))
                            probe = bigramList[(Tokens[i].ToString() + " | " + Tokens[i - 1].ToString()).ToLower()] * probe;
                        else
                            return 0;
                    }
            }
            return Math.Pow(probe, (1 / (double)Tokens.Count));
        }

        public double ProbeTrigram(ArrayList Tokens, SortedList<string, double> trigramList)
        {
            double probe = 1;
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (i == 0)
                {
                    if (trigramList.ContainsKey((Tokens[i].ToString() + " | <s> <s>").ToLower()))
                        probe = trigramList[(Tokens[i].ToString() + " | <s> <s>").ToLower()] * probe;
                    else
                        return 0;
                }
                else
                    if (i == 1)
                    {
                        if (trigramList.ContainsKey((Tokens[i].ToString() + " | " + "<s> " + Tokens[i - 1].ToString()).ToLower()))
                            probe = trigramList[(Tokens[i].ToString() + " | " + "<s> " + Tokens[i - 1].ToString()).ToLower()] * probe;
                        else
                            return 0;
                    }
                    else
                        if (!String.IsNullOrWhiteSpace(Tokens[i].ToString()))
                        {
                            if (trigramList.ContainsKey((Tokens[i].ToString() + " | " + Tokens[i - 2].ToString() + " " + Tokens[i - 1].ToString()).ToLower()))
                                probe = trigramList[(Tokens[i].ToString() + " | " + Tokens[i - 2].ToString() + " " + Tokens[i - 1].ToString()).ToLower()] * probe;
                            else
                                return 0;
                        }
            }
            return Math.Pow(probe, (1 / (double)Tokens.Count));
        }
        #endregion

        private void dataGridViewSentence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSentence.Columns[e.ColumnIndex].Name == "Edit")
            {
                new EditSentences().ShowDialog(dataGridViewSentence.Rows[e.RowIndex].Cells["Sentence"].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Regex_Patterns.Instance._TrigramListCorpuse.Count != 0)
                new Form2().ShowDialog();
            else
                MessageBox.Show("لطفاً ابتدا فایل را انتخاب نموده و سپس دکمه اجرا را کلیک نمائید و پس از پردازش متن روی دکمه جاری کلیک نمائید");
        }
    }
}
