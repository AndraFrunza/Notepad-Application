using Notepad.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SimpleNotepad simpleNotepad = new SimpleNotepad("New File");
            Text = simpleNotepad.GetTitle();
            Height = simpleNotepad.GetHeight();
            Width = simpleNotepad.GetWidth();
            textBox.Font = new Font(simpleNotepad.GetTextFont(), simpleNotepad.GetTextSize(), simpleNotepad.GetTextFontStyle());
            textBox.SelectionColor = simpleNotepad.GetTextColor();
            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String text = textBox.Text;
            SaveFileDialog theDialog = new SaveFileDialog();
            theDialog.Title = "Save file";
            theDialog.Filter = "Text documents(*.txt)|*.txt";
            theDialog.InitialDirectory = @"C:\";

            String path;
            if (theDialog.ShowDialog() == DialogResult.OK) {
                path = theDialog.FileName;
                File.WriteAllText(path, text);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open file";
            theDialog.Filter = "Text documents(*.txt)|*.txt";
            theDialog.InitialDirectory = @"C:\";

            String path;
            String text;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                path = theDialog.FileName;
                text = File.ReadAllText(path);
                textBox.Text = text;

            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = String.Empty;
        }

        private void hexadecimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textToolStripMenuItem.Checked = false;
            binaryToolStripMenuItem.Checked = false;

            if (hexadecimalToolStripMenuItem.Checked == true)
            {
                textBox.Text = convertToHexa(textBox.Text);
            }
            else
            {
                textBox.Text = convertFromHexadecimalToText(textBox.Text);
                textToolStripMenuItem.Checked = true;
            }
        }

        private string convertToHexa(string text)
        {
            byte[] ba = Encoding.Default.GetBytes(text);
            String hexString = BitConverter.ToString(ba);
            return hexString;
        }

        private void binaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textToolStripMenuItem.Checked = false;
            hexadecimalToolStripMenuItem.Checked = false;

            if (binaryToolStripMenuItem.Checked == true)
            {
                textBox.Text = convertToBinary(textBox.Text);
            }
            else
            {
                textToolStripMenuItem.Checked = true;
                textBox.Text = convertFromBinaryToText(textBox.Text);
           
            }
        }

        private string convertToBinary(string text)
        {
            return ToBinary(ConvertToByteArray(text));
        }
        private byte[] ConvertToByteArray(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }

        private void cCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadC notepadc = new NotepadC("New C File");

            cCToolStripMenuItem.Checked = true;
            javaToolStripMenuItem.Checked = false;
            assemblyToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;

            Text = notepadc.GetTitle();
            Height = notepadc.GetHeight();
            Width = notepadc.GetWidth();
            textBox.Font = new Font(notepadc.GetTextFont(), notepadc.GetTextSize(), notepadc.GetTextFontStyle());
            textBox.SelectionColor = notepadc.GetTextColor();

            String text = notepadc.ReplacesPunctuation(textBox.Text);

            List<String> words = text.Split(' ', '\n','\r').ToList();
            int position = 0;

            foreach(String word in words)
            {
                textBox.SelectionStart = position;
                textBox.SelectionLength = word.Length;

                foreach(String keyword in notepadc.GetCKeywords())
                {
                    if (notepadc.GetIsCaseSensitive())
                    {

                        if (String.Equals(word, keyword))
                        {
                            textBox.SelectionColor = notepadc.GetTextKeywordColor();
                            break;
                        }
                    }
                    else
                    { 
                        if (String.Equals(word, keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            textBox.SelectionColor = notepadc.GetTextKeywordColor();
                            break;
                        }
                    }
                    
                }
                position = position + word.Length + 1;
            }
           
        }

        private void javaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadJava notepadjava = new NotepadJava("New Java File");

            javaToolStripMenuItem.Checked = true;
            cCToolStripMenuItem.Checked = false;
            assemblyToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;

            Text = notepadjava.GetTitle();
            Height = notepadjava.GetHeight();
            Width = notepadjava.GetWidth();
            textBox.Font = new Font(notepadjava.GetTextFont(), notepadjava.GetTextSize(), notepadjava.GetTextFontStyle());
            textBox.SelectionColor = notepadjava.GetTextColor();

            String text = notepadjava.ReplacesPunctuation(textBox.Text);

            List<String> words = text.Split(' ', '\n', '\r').ToList();
            int position = 0;

            foreach (String word in words)
            {
                textBox.SelectionStart = position;
                textBox.SelectionLength = word.Length;

                foreach (String keyword in notepadjava.GetJavaKeywords())
                {
                    if (notepadjava.GetIsCaseSensitive())
                    {

                        if (String.Equals(word, keyword))
                        {
                            textBox.SelectionColor = notepadjava.GetTextKeywordColor();
                            break;
                        }
                    }
                    else
                    {
                        if (String.Equals(word, keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            textBox.SelectionColor = notepadjava.GetTextKeywordColor();
                            break;
                        }
                    }

                }
                position = position + word.Length + 1;
            }

        }

        private void assemblyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotepadAsm notepadasm = new NotepadAsm("New Asm File");

            assemblyToolStripMenuItem.Checked = true;
            cCToolStripMenuItem.Checked = false;
            javaToolStripMenuItem.Checked = false;
            noneToolStripMenuItem.Checked = false;

            Text = notepadasm.GetTitle();
            Height = notepadasm.GetHeight();
            Width = notepadasm.GetWidth();
            textBox.Font = new Font(notepadasm.GetTextFont(), notepadasm.GetTextSize(), notepadasm.GetTextFontStyle());
            textBox.SelectionColor = notepadasm.GetTextColor();

            String text = notepadasm.ReplacesPunctuation(textBox.Text);

            List<String> words = text.Split(' ', '\n', '\r').ToList();
            int position = 0;

            foreach (String word in words)
            {
                textBox.SelectionStart = position;
                textBox.SelectionLength = word.Length;

                foreach (String keyword in notepadasm.GetAsmKeywords())
                {
                    if (notepadasm.GetIsCaseSensitive())
                    {

                        if (String.Equals(word, keyword))
                        {
                            textBox.SelectionColor = notepadasm.GetTextKeywordColor();
                            break;
                        }
                    }
                    else
                    {
                        if (String.Equals(word, keyword, StringComparison.OrdinalIgnoreCase))
                        {
                            textBox.SelectionColor = notepadasm.GetTextKeywordColor();
                            break;
                        }
                    }

                }
                position = position + word.Length + 1;
            }

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox.SelectionColor = Color.Black;

            if (binaryToolStripMenuItem.Checked && (e.KeyChar != (int)'0' && e.KeyChar != (int)'1'))
            {
                e.Handled = true;
            }
            if(hexadecimalToolStripMenuItem.Checked && (e.KeyChar < '0' || e.KeyChar > '9') && (e.KeyChar < 'A' || e.KeyChar > 'F') && (e.KeyChar < 'a' || e.KeyChar > 'f'))
            {
                e.Handled = true;
            }
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(binaryToolStripMenuItem.Checked)
            {
                textBox.Text = convertFromBinaryToText(textBox.Text);
            }
            if(hexadecimalToolStripMenuItem.Checked)
            {
                textBox.Text = convertFromHexadecimalToText(textBox.Text);
            }
            binaryToolStripMenuItem.Checked = false;
            hexadecimalToolStripMenuItem.Checked = false;

        }

        private string convertFromHexadecimalToText(String hexadecimal)
        {
            byte[] data = FromHex(hexadecimal);
            string text = Encoding.ASCII.GetString(data);
            return text;
        }
        public byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        private String convertFromBinaryToText(String binary)
        {
            var data = GetBytesFromBinaryString(binary.Replace(" ", ""));
            var text = Encoding.ASCII.GetString(data);
            return text;
        }
        public Byte[] GetBytesFromBinaryString(String binary)
        {
            var list = new List<Byte>();

            for (int i = 0; i < binary.Length; i += 8)
            {
                String t = binary.Substring(i, 8);

                list.Add(Convert.ToByte(t, 2));
            }

            return list.ToArray();
        }
    }
    }

