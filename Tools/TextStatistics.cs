using System;
using System.Linq;

namespace NotepadApp.Tools
{
    // Версия: 1.0
    // Модуль статистики текста
    public class TextStatistics
    {
        public int CountCharacters(string text)
        {
            return text.Length;
        }

        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(new char[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public int CountLines(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            return text.Split('\n').Length;
        }

        public int CountParagraphs(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(new string[] { "\n\n" },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public string GetFullStatistics(string text)
        {
            return $"Символов: {CountCharacters(text)} | " +
                   $"Слов: {CountWords(text)} | " +
                   $"Строк: {CountLines(text)} | " +
                   $"Абзацев: {CountParagraphs(text)}";
        }
    }
}
