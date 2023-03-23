using System;
using System.Collections.Generic;
using System.Text;

namespace TokenExtraction
{
    class QL4_State
    {
        public void Compute()
        {
            string ch = Regex_Patterns.Instance.ReadTape();

            switch (Regex_Patterns.Instance.GetMarkType(ch))
            {
                case TypeMark.Word:
                case TypeMark.Digit:
                    Regex_Patterns.Instance.AddTOCurrentToken(ch);
                    Regex_Patterns.Instance.State = StateMark.QL4;
                    break;
                case TypeMark.Point:
                    Regex_Patterns.Instance.AddTOCurrentToken(ch);
                    Regex_Patterns.Instance.AddSentence(Regex_Patterns.Instance.GetCurrentSentence());
                    Regex_Patterns.Instance.State = StateMark.QL3;
                    break;
                case TypeMark.Null:
                    Regex_Patterns.Instance.AddWord(Regex_Patterns.Instance.CurrentToken);
                    Regex_Patterns.Instance.State = StateMark.None;
                    break;
                case TypeMark.EndMark:
                    Regex_Patterns.Instance.AddMark(ch);
                    Regex_Patterns.Instance.AddSentence(Regex_Patterns.Instance.GetCurrentSentence());
                    Regex_Patterns.Instance.State = StateMark.QLF;
                    break;
                case TypeMark.Space:
                    Regex_Patterns.Instance.AddTOCurrentSentence(ch);
                    Regex_Patterns.Instance.AddMark(ch);
                    Regex_Patterns.Instance.State = StateMark.QLF;
                    break;
                default:
                    Regex_Patterns.Instance.AddMark(ch);
                    Regex_Patterns.Instance.State = StateMark.QLF;
                    break;
            }
        }
    }
}
