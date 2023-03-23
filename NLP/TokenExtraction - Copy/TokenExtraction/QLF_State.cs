﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TokenExtraction
{
    class QLF_State
    {
        public void Compute()
        {
            Regex_Patterns.Instance.AddWord(Regex_Patterns.Instance.CurrentToken);
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
                    //Compute(Regex_Patterns.Instance.Tape[++Regex_Patterns.Instance.HeadTape].ToString());
                    Regex_Patterns.Instance.AddTOCurrentSentence(ch);
                    Regex_Patterns.Instance.AddMark(ch);
                    Regex_Patterns.Instance.State = StateMark.QLF;
                    break;
                case TypeMark.Null:
                    Regex_Patterns.Instance.AddWord(Regex_Patterns.Instance.CurrentToken);
                    Regex_Patterns.Instance.State = StateMark.None;
                    break;
                case TypeMark.Point:
                case TypeMark.EndMark:
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
