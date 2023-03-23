using System;
using System.Collections.Generic;
using System.Text;

namespace TokenExtraction
{
    public class S_State
    {
        public void Compute()
        {
            string ch = Regex_Patterns.Instance.ReadTape();
            switch (Regex_Patterns.Instance.GetMarkType(ch))
            {
                case TypeMark.Word:
                case TypeMark.Comment:
                    //--- save current char for token ---------------
                    Regex_Patterns.Instance.AddTOCurrentToken(ch);
                    //-----------------------------------------------
                    //  call next state
                    Regex_Patterns.Instance.State = StateMark.QL1;
                    break;
                case TypeMark.Space:
                    //return and call  itself
                    Regex_Patterns.Instance.AddTOCurrentSentence(ch);
                    Regex_Patterns.Instance.State = StateMark.Start;
                    break;
                case TypeMark.Digit:
                    //--- save current char for token ---------------
                    Regex_Patterns.Instance.AddTOCurrentToken(ch);
                    //-----------------------------------------------
                    Regex_Patterns.Instance.State = StateMark.QD1;
                    break;
                case TypeMark.Null:
                    Regex_Patterns.Instance.State = StateMark.None;
                    break;
                default:
                    //--- save current char for token ---------------
                    Regex_Patterns.Instance.AddTrap(ch);
                    Regex_Patterns.Instance.State = StateMark.QTrap;
                    break;
            }
        }
    }
}
