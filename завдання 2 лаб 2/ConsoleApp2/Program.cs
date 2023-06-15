using System;
using System.Collections.Generic;

class ЗаписВідомості
{
    public string Прізвище { get; set; }
    public decimal Зарплата { get; set; }
    public decimal Утримання { get; set; }

    public decimal Видано => Зарплата - Утримання;
}

class Відомість
{
    private List<ЗаписВідомості> записи = new List<ЗаписВідомості>();

    public void ДодатиЗапис(ЗаписВідомості запис)
    {
        записи.Add(запис);
    }

    public void ВивестиЗначенняS()
    {
        foreach (var запис in записи)
        {
            Console.WriteLine("Значення S (видано) для " + запис.Прізвище + ": " + запис.Видано);
        }
    }
}

class Program
{
    static void Main()
    {
        Відомість відомість = new Відомість();

        // Запитуємо дані від користувача і додаємо записи до відомості
        Console.WriteLine("Введіть дані про працівників. Для завершення введення введіть 'exit'.");

        while (true)
        {
            Console.WriteLine("Введіть прізвище:");
            string прізвище = Console.ReadLine();

            if (прізвище.ToLower() == "exit")
                break;

            Console.WriteLine("Введіть зарплату:");
            decimal зарплата = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Введіть утримання:");
            decimal утримання = Convert.ToDecimal(Console.ReadLine());

            ЗаписВідомості запис = new ЗаписВідомості()
            {
                Прізвище = прізвище,
                Зарплата = зарплата,
                Утримання = утримання
            };

            відомість.ДодатиЗапис(запис);
        }

        // Виводимо значення S для кожного запису відомості
        відомість.ВивестиЗначенняS();
    }
}