using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.Classes
{
   public class SimpleNotepad
    {
        protected String title;
        protected int height;
        protected int width;
        protected Color textColor;
        protected FontStyle textFontStyle;
        protected int textSize;
        protected String textFont;

        public SimpleNotepad(String title)
        {
            this.title = "Notepad - " + title;
            height = 400;
            width = 800;
            textColor = Color.Black;
            textFontStyle = FontStyle.Regular;
            textSize = 14;
            textFont = "Arial";
        }

        public String ReplacesPunctuation(string text)
        {
            foreach (Char c in text)
            {
                if (Char.IsPunctuation(c))
                {
                    text = text.Replace(c, ' ');
                }
            }
            return text;
        }

        public void SetTextFont(String textFont)
        {
            this.textFont = textFont;
        }
        public String GetTextFont()
        {
            return textFont;
        }

        public void SetTextSize(int textSize)
        {
            this.textSize = textSize;
        }
        public int GetTextSize()
        {
            return textSize;
        }

        public void SetTextFontStyle(FontStyle textFontStyle)
        {
            this.textFontStyle = textFontStyle;
        }
        public FontStyle GetTextFontStyle()
        {
            return textFontStyle;
        }

        public void SetTextColor(Color textColor)
        {
            this.textColor = textColor;
        }
        public Color GetTextColor()
        {
            return textColor;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }
        public int GetWidth()
        {
            return width;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }
        public int GetHeight()
        {
            return height;
        }

        public void SetTitle(String title)
        {
            this.title = title;
        }
        public String GetTitle()
        {
            return title;
        }

        

    }
}
