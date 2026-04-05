using System;
using System.Windows.Forms;

namespace NotepadApp.Tools
{
    // Версия: 1.0
    // Модуль поиска и замены текста
    public class SearchReplace
    {
        private RichTextBox textArea;
        private int lastFoundIndex;

        public SearchReplace(RichTextBox textArea)
        {
            this.textArea = textArea;
            lastFoundIndex = -1;
        }

        public bool FindNext(string query, bool matchCase)
        {
            StringComparison comparison = matchCase
                ? StringComparison.Ordinal
                : StringComparison.OrdinalIgnoreCase;

            string text = textArea.Text;
            int startIndex = lastFoundIndex + 1;

            int index = text.IndexOf(query, startIndex, comparison);
            if (index >= 0)
            {
                textArea.Select(index, query.Length);
                textArea.ScrollToCaret();
                lastFoundIndex = index;
                return true;
            }

            lastFoundIndex = -1;
            return false;
        }

        public int ReplaceAll(string query, string replacement, bool matchCase)
        {
            StringComparison comparison = matchCase
                ? StringComparison.Ordinal
                : StringComparison.OrdinalIgnoreCase;

            int count = 0;
            string text = textArea.Text;
            int index = text.IndexOf(query, comparison);

            while (index >= 0)
            {
                textArea.Select(index, query.Length);
                textArea.SelectedText = replacement;
                text = textArea.Text;
                index = text.IndexOf(query, index + replacement.Length, comparison);
                count++;
            }

            return count;
        }

        public void ResetSearch()
        {
            lastFoundIndex = -1;
        }
    }
}
