using System;
using System.Linq;

namespace NotepadApp.Tools
{
    /// <summary>
    /// Модуль статистики текста.
    /// В режиме реального времени подсчитывает количество
    /// символов, слов, строк и абзацев в документе.
    /// </summary>
    public class TextStatistics
    {
        /// <summary>
        /// Возвращает количество символов в тексте.
        /// </summary>
        /// <param name="text">Текст для подсчёта.</param>
        /// <returns>Количество символов.</returns>
        public int CountCharacters(string text)
        {
            return text.Length;
        }

        /// <summary>
        /// Возвращает количество слов в тексте.
        /// </summary>
        /// <param name="text">Текст для подсчёта.</param>
        /// <returns>Количество слов.</returns>
        public int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;
            return text.Split(new char[] { ' ', '\n', '\r', '\t' },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Возвращает количество строк в тексте.
        /// </summary>
        /// <param name="text">Текст для подсчёта.</param>
        /// <returns>Количество строк.</returns>
        public int CountLines(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;
            return text.Split('\n').Length;
        }

        /// <summary>
        /// Возвращает количество абзацев в тексте.
        /// Абзацы разделяются двойным переносом строки.
        /// </summary>
        /// <param name="text">Текст для подсчёта.</param>
        /// <returns>Количество абзацев.</returns>
        public int CountParagraphs(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;
            return text.Split(new string[] { "\n\n" },
                StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Формирует строку сводной статистики по тексту.
        /// </summary>
        /// <param name="text">Текст для анализа.</param>
        /// <returns>Строка со статистикой для отображения в строке состояния.</returns>
        public string GetStatisticsSummary(string text)
        {
            return $"Символов: {CountCharacters(text)} | " +
                   $"Слов: {CountWords(text)} | " +
                   $"Строк: {CountLines(text)} | " +
                   $"Абзацев: {CountParagraphs(text)}";
        }
    }
}
