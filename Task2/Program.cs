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
    internal class Program
    {
        static void Main(string[] args)
        {
            DictionaryEngFrench dictionary = new DictionaryEngFrench();
            dictionary.AddWord("Hello", new List<string> { "Bonjour", "Salut" });
            dictionary.AddWord("Goodbye", new List<string> { "Au revoir" });
            Console.WriteLine("Словарь после добавления слов:");
            Console.WriteLine(dictionary);
            dictionary.RemoveWord("Hello");
            Console.WriteLine("Словарь после удаления слова 'Hello':");
            Console.WriteLine(dictionary);
            dictionary.AddWord("Hello", new List<string> { "Bonjour", "Salut" });
            dictionary.AddWord("Good night", new List<string> { "Bonne nuit" });
            dictionary.RemoveTranslation("Hello", "Bonjour");
            Console.WriteLine("Словарь после удаления перевода 'Bonjour' из слова 'Good morning':");
            Console.WriteLine(dictionary);
        }
    }
}
