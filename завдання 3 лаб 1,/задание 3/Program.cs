using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string inputFilename = "words.txt";
        string outputFilename = "sorted_words.txt";

        // Зчитуємо слова зі вхідного файлу
        string[] words = File.ReadAllLines(inputFilename);

        // Сортуємо слова за алфавітом
        Array.Sort(words);

        // Записуємо відсортовані слова у вихідний файл
        File.WriteAllLines(outputFilename, words);

        Console.WriteLine("Words have been sorted and written to the file: " + outputFilename);
    }
}


