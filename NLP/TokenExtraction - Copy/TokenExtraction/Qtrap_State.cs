using System;
using System.Collections.Generic;
using System.Text;

namespace TokenExtraction
{
    class Qtrap_State
    {
        public void Compute()
        {
            Regex_Patterns.Instance.AddTrap(Regex_Patterns.Instance.CurrentToken);
            string ch = Regex_Patterns.Instance.ReadTape();

            switch (Regex_Patterns.Instance.GetMarkType(ch))
            {
                case TypeMark.Word:
                case TypeMark.Comment:
                    Regex_Patterns.Instance.AddTOCurrentToken(ch);
                    Regex_Patterns.Instance.State = StateMark.QL1;
                    break;
                case TypeMark.Digit:
                    Regex_Patterns.Instance.AddTOCurrentToken(ch);
                    Regex_Patterns.Instance.State = StateMark.QD1;
                    break;
                case TypeMark.Space:
                    Regex_Patterns.Instance.AddTOCurrentSentence(ch);
                    Regex_Patterns.Instance.AddTrap(ch);
                    Regex_Patterns.Instance.State = StateMark.QTrap;
                    break;
                case TypeMark.Null:
                    Regex_Patterns.Instance.State = StateMark.None;
                    break;
                case TypeMark.EndMark:
                case TypeMark.Point:
                    Regex_Patterns.Instance.AddTrap(ch);
                    Regex_Patterns.Instance.AddSentence(Regex_Patterns.Instance.GetCurrentSentence());
                    Regex_Patterns.Instance.State = StateMark.QTrap;
                    break;
                default:
                    Regex_Patterns.Instance.AddTrap(ch);
                    Regex_Patterns.Instance.State = StateMark.QTrap;
                    break;
            }
        }
    }
}
