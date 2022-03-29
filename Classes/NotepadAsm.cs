using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Classes
{
    public class NotepadAsm : SimpleNotepad
    {
        private List<String> AsmKeywords = new List<string> { "mov", "align", ".alpha", "and", "assume", "at", "byte", ".code", "@code", "@codesize", "comm", "comment", ".const", ".cref", "@curseg", "@data", ".data", "@data?", ".data?", "@datasize", "db", "dd", "df", "dq", "ds", "dt", "dup", "dw", "dword", "else", "end", "endif", "endm", "endp", "ends", "eq", "equ", ".err", ".err1", ".err2", "even", "exitm", "extrn", "far", "@fardata", ".fardata", "@fardata?", ".fardata?", "@filename", "fword", "ge", "group", "gt", "high", "if", "if1", "if2", "ifb", "ifdef", "ifgif", "ifde", "ifidn", "ifnb", "ifndef", "include", "includelib", "irp", "irpc", "label", ".lall", "large", "le", "length", ".lfcond", ".list", "local", "low", "lt", "macro", "mask", "medium", "mod", ".model", "name", "ne", "near", "not", "nothing", "offset", "or", "org", "%out", "page", "para", "proc", "ptr", "public", "purge", "qword", ".radix", "record", "rept", ".sall", "seg", "segment", ".seq", ".sfcond", "shl", "short", "shr", "size", "small", "stack", "@stack", ".stack", "struc", "subttl", "tbyte", ".tfcond", "this", "title", "type", ".type", "width", "word", "@wordsize", ".xall", ".xcrep", ".xlist", "xor", "add", "rol", "ror", "inc", "sub" };
        private Color textKeywordColor;
        private bool isCaseSensitive;

        public NotepadAsm(String title) : base(title)
        {
            textKeywordColor = Color.Coral;
            isCaseSensitive = false;
            textFont = "Tahoma";
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

        public List<String> GetAsmKeywords()
        {
            return AsmKeywords;
        }
    }
}
