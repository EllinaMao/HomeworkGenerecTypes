using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{/*Задание 2
Создайте приложение «Англо-французский словарь». Необходимо хранить следующую информацию:

Слово на английском языке;
Варианты перевода на французский.
Для хранения информации используйте Dictionary<T>.

Приложение должно предоставлять такую функциональность:

Добавление слова и вариантов перевода;
Удаление слова;
Удаление варианта перевода;
Изменение слова;
Изменение варианта перевода;
Поиск перевода слова.*/
    internal class DictionaryEngFrench
    {
        Dictionary<string, List<string>> dictionary;
        public DictionaryEngFrench()
        {
            dictionary = new Dictionary<string, List<string>>();
        }
        public void AddWord(string englishWord, List<string> frenchTranslations)
        {
            if (string.IsNullOrWhiteSpace(englishWord) || frenchTranslations == null || frenchTranslations.Count == 0)
            {
                throw new ArgumentException("Слово и переводы не могут быть пустыми.");
            }
            if (dictionary.ContainsKey(englishWord))
            {
                throw new ArgumentException("Слово уже существует в словаре.");
            }
            dictionary[englishWord] = frenchTranslations;
        }
        public void RemoveWord(string englishWord)
        {
            if (!dictionary.ContainsKey(englishWord))
            {
                throw new KeyNotFoundException("Слово не найдено в словаре.");
            }
            dictionary.Remove(englishWord);
        }
        public void RemoveTranslation(string englishWord, string frenchTranslation)
        {
            if (!dictionary.ContainsKey(englishWord))
            {
                throw new KeyNotFoundException("Слово не найдено в словаре.");
            }
            var translations = dictionary[englishWord];
            if (!translations.Remove(frenchTranslation))
            {
                throw new KeyNotFoundException("Французский перевод не найден для данного английского слова.");
            }
            if (translations.Count == 0)
            {
                dictionary.Remove(englishWord);
            }
        }
        public void Clear()
        {
            dictionary.Clear();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var entry in dictionary)
            {
                sb.AppendLine($"{entry.Key}: {string.Join(", ", entry.Value)}");
            }
            return sb.ToString();
        }

        public void UpdateWord(string oldEnglishWord, string newEnglishWord)
        {
            if (string.IsNullOrWhiteSpace(newEnglishWord))
            {
                throw new ArgumentException("Новое слово не может быть пустым.");
            }
            if (!dictionary.ContainsKey(oldEnglishWord))
            {
                throw new KeyNotFoundException("Слово не найдено в словаре.");
            }
            if (dictionary.ContainsKey(newEnglishWord))
            {
                throw new ArgumentException("Слово с новым значением уже существует в словаре.");
            }
            var translations = dictionary[oldEnglishWord];
            dictionary.Remove(oldEnglishWord);
            dictionary[newEnglishWord] = translations;
        }

        public void UpdateTranslation(string englishWord, string oldFrenchTranslation, string newFrenchTranslation)
        {
            if (string.IsNullOrWhiteSpace(newFrenchTranslation))
            {
                throw new ArgumentException("Новое французское слово не может быть пустым.");
            }
            if (!dictionary.ContainsKey(englishWord))
            {
                throw new KeyNotFoundException("Слово не найдено в словаре.");
            }
            var translations = dictionary[englishWord];
            if (!translations.Contains(oldFrenchTranslation))
            {
                throw new KeyNotFoundException("Французский перевод не найден для данного английского слова.");
            }
            translations.Remove(oldFrenchTranslation);
            translations.Add(newFrenchTranslation);
        }
        public List<string> SearchTranslation(string englishWord)
        {
            if (dictionary.TryGetValue(englishWord, out var translations))
            {
                return translations;
            }
            throw new KeyNotFoundException("Слово не найдено в словаре.");
        }

    }
}
