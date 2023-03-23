using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace TokenExtraction
{
    public partial class EditSentences : Form
    {
        public EditSentences()
        {
            InitializeComponent();
        }

        public void ShowDialog(string sentence)
        {
            txtSentence.Text = sentence;
            this.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
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

            Encoding encoding1256 = Encoding.GetEncoding(1256);
            byte[] inputStrBuf = encoding1256.GetBytes(txtSentence.Text);
            byte[] inputStrUtf8Buf = Encoding.Convert(encoding1256, Encoding.UTF8, inputStrBuf);
            txtSentence.Text = Encoding.GetEncoding("utf-8").GetString(inputStrUtf8Buf);

            Regex_Patterns.Instance.Tape = txtSentence.Text;
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


            List<ArrayList> sentences = Regex_Patterns.Instance._SentenceList;
            foreach (ArrayList array in sentences)
            {
                lblUnigram.Text = ProbeUnigram(array, Regex_Patterns.Instance._TrapListCorpuse, Regex_Patterns.Instance._WordListCorpuse, Regex_Patterns.Instance._DigitListCorpuse, Regex_Patterns.Instance._MarkListCorpuse).ToString();
                lblBigram.Text = ProbeBigram(array, Regex_Patterns.Instance._BigramListCorpuse).ToString();
                lblTrigram.Text = ProbeTrigram(array, Regex_Patterns.Instance._TrigramListCorpuse).ToString();
            }
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
    }
}
