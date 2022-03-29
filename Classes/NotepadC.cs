using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Classes
{
    public class NotepadC : SimpleNotepad
    {
        private List<String> CKeywords = new List<string> { "new", "public", "class", "foreach", "this", "bool", "explicit", "private", "true", "break", "export", "protected", "try", "case", "extern", "typedef", "catch", "false", "register", "char", "float", "typename", "for", "return", "union", "const", "short", "unsigned", "const_cast", "goto", "signed", "using", "continue", "if", "sizeof", "virtual", "default", "inline", "static", "void", "delete", "int", "static_cast", "volatile", "do", "long", "struct", "double", "mutable", "switch", "while", "namespace", "template", "operator", "throw", "case", "else", "goto", "int", "not_eq", "or_eq", "and", "not", "asm", "alignof", "alignas" };
        private Color textKeywordColor;
        private bool isCaseSensitive;

        public NotepadC(String title) : base(title)
        {
            textKeywordColor = Color.Red;
            isCaseSensitive = true;
            textFont = "Consolas";
        }

        public bool GetIsCaseSensitive()
        {
            return isCaseSensitive;
        }

        public void SetTextKeywordColor(Color textKeywordColor)
        {
            this.textKeywordColor = textKeywordColor;
        }
        public Color GetTextKeywordColor()
        {
            return textKeywordColor;
        }

        public List<String> GetCKeywords()
        {
            return CKeywords;
        }



    }
}
