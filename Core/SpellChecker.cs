using System;
using System.Collections.Generic;

namespace NotepadApp.Core
{
    // Версия: 1.0
    // Модуль проверки орфографии
    public enum Language { Russian, English }

    public class SpellChecker
    {
        private Dictionary<Language, HashSet<string>> dictionaries;

        public SpellChecker()
        {
            dictionaries = new Dictionary<Language, HashSet<string>>();
            LoadDictionary(Language.Russian);
            LoadDictionary(Language.English);
        }

        private void LoadDictionary(Language language)
        {
            // Загрузка словаря из файла ресурсов
            dictionaries[language] = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        public bool CheckWord(string word, Language language)
        {
            if (dictionaries.ContainsKey(language))
                return dictionaries[language].Contains(word);
            return true;
        }

        public List<string> GetSuggestions(string word, Language language)
        {
            // Возвращает список вариантов замены для слова
            return new List<string>();
        }

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
