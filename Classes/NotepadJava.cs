using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Classes
{
    public class NotepadJava : SimpleNotepad
    {
        private List<String> JavaKeywords = new List<string> { "class", "package", "abstract", "assert", "break", "byte", "case", "catch", "char", "double", "do", "else", "final", "finally", "float", "for", "implements", "import", "instanceof", "int", "native", "null", "new", "public", "return", "short", "static", "switch", "synchronized", "this", "throw", "true", "try", "void", "volatile", "extends", "false", "goto", "if", "interface", "long", "private", "protected", "super", "transient", "while", "boolean", "throws" };
        private Color textKeywordColor;
        private bool isCaseSensitive;

        public NotepadJava(String title) : base(title)
        {
            textKeywordColor = Color.Blue;
            isCaseSensitive = true;
            textFont = "Century";
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

        public List<String> GetJavaKeywords()
        {
            return JavaKeywords;
        }
    }

    
}
