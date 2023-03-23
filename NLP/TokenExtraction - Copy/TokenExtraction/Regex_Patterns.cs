using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace TokenExtraction
{
    public enum TypeMark
    {
        Word,
        Mark,
        Digit,
        Space,
        MathMark,
        EndMark,
        Comment,
        Point,
        Null
    }
    public enum StateMark
    {
        QD1,
        QD2,
        QDF,
        QL1,
        QL2,
        QL3,
        QL4,
        QLF,
        QTrap,
        Start,
        None
    }
    public class Regex_Patterns
    {
        public static Regex_Patterns Instance;
        static Regex_Patterns()
        {
            Instance = new Regex_Patterns();
        }

        #region Variables
        public string Tape;
        public int HeadTape;
        public StateMark State = StateMark.Start;
        private SortedList<string, double> WordList = new SortedList<string, double>();
        private SortedList<string, double> DigitList = new SortedList<string, double>();
        private SortedList<string, double> TrapList = new SortedList<string, double>();
        private SortedList<string, double> MarkList = new SortedList<string, double>();

        private ArrayList Tokens = new ArrayList();
        private List<ArrayList> SentenceList = new List<ArrayList>();
        private SortedList<string, double> bigramList = new SortedList<string, double>();
        private SortedList<string, double> trigramList = new SortedList<string, double>();

        public string CurrentToken;
        private ArrayList CurrentSentence = new ArrayList();
        private Regex WordMarks = new Regex(@"([a-z|A-Z]|([ض|ص|ث|ق|ف|غ|ع|ه|خ|ح|ج|چ|پ|گ|ک|م|ن|ت|ا|ل|ب|ی|س|ش|ظ|ط|ز|ر|ذ|د|ئ|و|آ|ژ|ي|ۀ|ء|أ|ة|ك|ؤ|]))");
        private Regex DigitMarks = new Regex(@"[0-9۰-۹]");
        private Regex SpaceMarks = new Regex(@"[(\r\n)|\s| ]");
        private Regex MathMarks = new Regex(@"[<|>|\|%|^|*|-|=|+]");
        private Regex EndMarks = new Regex(@"[?|؟|،|;|:|,|!]");
        private Regex CommentMarks = new Regex("[<|>|'|\"|[|]|{|}|(|)]");
        private Regex PointMark = new Regex(@"[.]"); 
        #endregion

        #region Get, Set And Clear Lists
        public SortedList<string, double> _BigramList
        {
            get
            {
                return bigramList;
            }
            set
            {
                bigramList = value;
            }
        }

        public SortedList<string, double> _TrigramList
        {
            get
            {
                return trigramList;
            }
            set
            {
                trigramList = value;
            }
        }

        public SortedList<string, double> _WordList
        {
            get
            {
                return WordList;
            }
            set
            {
                WordList = value;
            }
        }

        public void ClearTokensList()
        {
            Tokens.Clear();
        }

        public void ClearWordList()
        {
            WordList.Clear();
        }

        public SortedList<string, double> _DigitList
        {
            get
            {
                return DigitList;
            }
            set
            {
                DigitList = value;
            }
        }

        public void ClearDigitList()
        {
            DigitList.Clear();
        }

        public SortedList<string, double> _TrapList
        {
            get
            {
                return TrapList;
            }
            set
            {
                TrapList = value;
            }
        }

        public void ClearSentenceList()
        {
            SentenceList.Clear();
        }

        public List<ArrayList> _SentenceList
        {
            get
            {
                return SentenceList;
            }
            set
            {
                SentenceList = value;
            }
        }

        public void ClearTrapList()
        {
            TrapList.Clear();
        }

        public SortedList<string, double> _MarkList
        {
            get
            {
                return MarkList;
            }
            set
            {
                MarkList = value;
            }
        }

        public void ClearMarkList()
        {
            MarkList.Clear();
        }

        public ArrayList GetCurrentSentence()
        {
            return CurrentSentence;
        }
        #endregion

        public void AddTOCurrentSentence(string ch)
        {
            if (ch != " ")
                CurrentSentence.Add(ch);
            else
            {
                if (CurrentSentence.Count != 0 && CurrentSentence[CurrentSentence.Count - 1] != " ")
                {
                    CurrentSentence.Add(ch);
                }
            }
        }

        public void AddTOCurrentToken(string ch)
        {
            CurrentToken += ch;
        }

        #region Fill Grams
        public SortedList<string, double> FillBigram()
        {
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (i == 0)
                    bigramList.Add(Tokens[i] + " | <s>", 1);
                else
                    if (!String.IsNullOrWhiteSpace(Tokens[i].ToString()))
                    {
                        if (bigramList.ContainsKey((Tokens[i].ToString() + " | " + Tokens[i - 1].ToString()).ToLower()))
                            bigramList[(Tokens[i].ToString() + " | " + Tokens[i - 1].ToString()).ToLower()] = bigramList[(Tokens[i].ToString() + " | " + Tokens[i - 1].ToString()).ToLower()] + 1;
                        else
                            bigramList.Add((Tokens[i].ToString() + " | " + Tokens[i - 1].ToString()).ToLower(), 1);
                    }
            }
            return bigramList;
        }

        public SortedList<string, double> FillTrigram()
        {
            for (int i = 0; i < Tokens.Count; i++)
            {
                if (i == 0)
                    trigramList.Add(Tokens[i].ToString() + " | <s> <s>", 1);
                else
                    if (i == 1)
                        trigramList.Add(Tokens[i].ToString() + " | " + "<s> " + Tokens[i - 1].ToString(), 1);
                    else
                        if (!String.IsNullOrWhiteSpace(Tokens[i].ToString()))
                        {
                            if (trigramList.ContainsKey((Tokens[i].ToString() + " | " + Tokens[i - 2].ToString() + " " + Tokens[i - 1].ToString()).ToLower()))
                                trigramList[(Tokens[i].ToString() + " | " + Tokens[i - 2].ToString() + " " + Tokens[i - 1].ToString()).ToLower()] = trigramList[(Tokens[i].ToString() + " | " + Tokens[i - 2].ToString() + " " + Tokens[i - 1].ToString()).ToLower()] + 1;
                            else
                                trigramList.Add((Tokens[i].ToString() + " | " + Tokens[i - 2].ToString() + " " + Tokens[i - 1].ToString()).ToLower(), 1);
                        }
            }
            return trigramList;
        } 
        #endregion

        #region Add Sorted Lists
        public void AddSentence(ArrayList sentence)
        {
            if (sentence.Count >= 3)
                SentenceList.Add((ArrayList)sentence.Clone());
            CurrentSentence.Clear();
        }

        public void AddMark(string str)
        {
            if (!String.IsNullOrWhiteSpace(str) && str.Trim() != String.Empty)
            {
                if (MarkList.ContainsKey(str.ToLower()))
                    MarkList[str.ToLower()] = MarkList[str.ToLower()] + 1;
                else
                    MarkList.Add(str.ToLower(), 1);

                Tokens.Add(str);
                AddTOCurrentSentence(str);
            }
        }

        public void AddWord(string str)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (WordList.ContainsKey(str.ToLower()))
                    WordList[str.ToLower()] = WordList[str.ToLower()] + 1;
                else
                    WordList.Add(str.ToLower(), 1);

                Tokens.Add(str);
                AddTOCurrentSentence(str);
            }
            CurrentToken = "";
        }

        public void AddDigit(string str)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (DigitList.ContainsKey(str.ToLower()))
                    DigitList[str.ToLower()] = DigitList[str.ToLower()] + 1;
                else
                    DigitList.Add(str.ToLower(), 1);

                Tokens.Add(str);
                AddTOCurrentSentence(str);
            }
            CurrentToken = "";
        }

        public void AddTrap(string str)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                if (TrapList.ContainsKey(str.ToLower()))
                    TrapList[str.ToLower()] = TrapList[str.ToLower()] + 1;
                else
                    TrapList.Add(str.ToLower(), 1);

                Tokens.Add(str);
                AddTOCurrentSentence(str);
            }
        } 
        #endregion

        public TypeMark GetMarkType(string ch)
        {
            if (!String.IsNullOrEmpty(ch))
            {
                if (ch == "None")
                    return TypeMark.Null;
                else if (WordMarks.Match(ch).Success)
                    return TypeMark.Word;
                else if (DigitMarks.Match(ch).Success)
                    return TypeMark.Digit;
                else if (SpaceMarks.Match(ch).Success)
                    return TypeMark.Space;
                else if (MathMarks.Match(ch).Success)
                    return TypeMark.MathMark;
                else if (EndMarks.Match(ch).Success)
                    return TypeMark.EndMark;
                else if (CommentMarks.Match(ch).Success)
                    return TypeMark.Comment;
                else if (PointMark.Match(ch).Success)
                    return TypeMark.Point;
                else return TypeMark.Mark;
            }
            else
                return TypeMark.Null;
        }

        public string ReadTape()
        {
            try
            {
                return Tape[++HeadTape].ToString();
            }
            catch
            {
                return "None";
            }
        }
    }
}
