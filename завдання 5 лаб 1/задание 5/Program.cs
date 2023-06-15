using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string filename = "textfile.txt";

        // Зчитуємо вміст текстового файлу
        string text = File.ReadAllText(filename);

        // Розбиваємо текст на слова
        string[] words = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Створюємо словник для збереження кількості кожного слова
        Dictionary<string, int> wordCounts = new Dictionary<string, int>();

        // Підраховуємо кількість входжень кожного слова
        foreach (string word in words)
        {
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts[word] = 1;
            }
        }

        // Виводимо кількість кожного слова
        foreach (KeyValuePair<string, int> pair in wordCounts)
        {
            Console.WriteLine(pair.Key + ": " + pair.Value);
        }
    }
}