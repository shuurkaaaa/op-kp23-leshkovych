using System;

class Program
{
    static void Main()
    {
        // Запитуємо дані від користувача
        Console.WriteLine("Введіть ваше прізвище:");
        string прізвище = Console.ReadLine();

        Console.WriteLine("Введіть вашу зарплату:");
        decimal зарплата = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Введіть утримання:");
        decimal утримання = Convert.ToDecimal(Console.ReadLine());

        // Обчислюємо значення S (видано)
        decimal видано = зарплата - утримання;

        // Виводимо результат
        Console.WriteLine("Значення S (видано): " + видано);
    }
}