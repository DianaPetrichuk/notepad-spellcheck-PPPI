using System;
using System.Windows.Forms;

namespace NotepadApp.Tools
{
    /// <summary>
    /// Модуль поиска и замены текста.
    /// Поддерживает поиск с учётом и без учёта регистра,
    /// а также массовую замену всех вхождений.
    /// </summary>
    public class SearchReplace
    {
        /// <summary>
        /// Текстовое поле редактора для выполнения операций поиска и замены.
        /// </summary>
        private RichTextBox textArea;

        /// <summary>
        /// Инициализирует модуль поиска и замены.
        /// </summary>
        /// <param name="textArea">Текстовое поле редактора.</param>
        public SearchReplace(RichTextBox textArea)
        {
            this.textArea = textArea;
        }

        /// <summary>
        /// Находит следующее вхождение строки поиска в тексте
        /// и выделяет его.
        /// </summary>
        /// <param name="query">Строка для поиска.</param>
        /// <param name="matchCase">Учитывать ли регистр при поиске.</param>
        /// <returns>True если вхождение найдено, иначе False.</returns>
        public bool FindNext(string query, bool matchCase)
        {
            StringComparison comparison = matchCase
                ? StringComparison.Ordinal
                : StringComparison.OrdinalIgnoreCase;

            string text = textArea.Text;
            int startIndex = textArea.SelectionStart + textArea.SelectionLength;
            int index = text.IndexOf(query, startIndex, comparison);

            if (index >= 0)
            {
                textArea.Select(index, query.Length);
                textArea.ScrollToCaret();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Заменяет все вхождения строки поиска на строку замены.
        /// </summary>
        /// <param name="query">Строка для поиска.</param>
        /// <param name="replacement">Строка замены.</param>
        /// <param name="matchCase">Учитывать ли регистр при поиске.</param>
        /// <returns>Количество выполненных замен.</returns>
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
                text = text.Remove(index, query.Length).Insert(index, replacement);
                index = text.IndexOf(query, index + replacement.Length, comparison);
                count++;
            }

            textArea.Text = text;
            return count;
        }
    }
}
