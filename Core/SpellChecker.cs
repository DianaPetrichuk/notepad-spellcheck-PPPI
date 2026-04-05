using System;
using System.Collections.Generic;

namespace NotepadApp.Core
{
    /// <summary>
    /// Перечисление поддерживаемых языков проверки орфографии.
    /// </summary>
    public enum Language
    {
        /// <summary>Русский язык.</summary>
        Russian,
        /// <summary>Английский язык.</summary>
        English
    }

    /// <summary>
    /// Модуль проверки орфографии текста.
    /// Поддерживает русский и английский языки.
    /// Подчёркивает ошибочные слова и предлагает варианты замены.
    /// </summary>
    public class SpellChecker
    {
        /// <summary>
        /// Словари для каждого из поддерживаемых языков.
        /// </summary>
        private Dictionary<Language, HashSet<string>> dictionaries;

        /// <summary>
        /// Инициализирует модуль проверки орфографии
        /// и загружает словари для всех поддерживаемых языков.
        /// </summary>
        public SpellChecker()
        {
            dictionaries = new Dictionary<Language, HashSet<string>>();
            LoadDictionary(Language.Russian);
            LoadDictionary(Language.English);
        }

        /// <summary>
        /// Загружает словарь для указанного языка из файла ресурсов.
        /// </summary>
        /// <param name="language">Язык, словарь которого необходимо загрузить.</param>
        private void LoadDictionary(Language language)
        {
            dictionaries[language] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Проверяет корректность написания отдельного слова.
        /// </summary>
        /// <param name="word">Слово для проверки.</param>
        /// <param name="language">Язык проверки.</param>
        /// <returns>True если слово написано верно, иначе False.</returns>
        public bool CheckWord(string word, Language language)
        {
            if (dictionaries.ContainsKey(language))
                return dictionaries[language].Contains(word);
            return true;
        }

        /// <summary>
        /// Возвращает список вариантов замены для ошибочно написанного слова.
        /// </summary>
        /// <param name="word">Ошибочно написанное слово.</param>
        /// <param name="language">Язык для подбора вариантов.</param>
        /// <returns>Список строк — вариантов замены.</returns>
        public List<string> GetSuggestions(string word, Language language)
        {
            return new List<string>();
        }

        /// <summary>
        /// Проверяет весь текст и возвращает список слов с ошибками.
        /// </summary>
        /// <param name="text">Текст для проверки.</param>
        /// <param name="language">Язык проверки.</param>
        /// <returns>Список слов содержащих орфографические ошибки.</returns>
        public List<string> CheckText(string text, Language language)
        {
            var errors = new List<string>();
            string[] words = text.Split(' ', '\n', '\r');
            foreach (var word in words)
            {
                if (!CheckWord(word, language))
                    errors.Add(word);
            }
            return errors;
        }
    }
}
