using System;

namespace Task3_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter n:");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter x:");
            float x = float.Parse(Console.ReadLine());
            int fac = 1;
            float deg = 1;

            Console.WriteLine("What kind of manipulation do you wanna do? (<Fac> or <Deg>)");
            string ask = Console.ReadLine();

            if (ask == "fac" || ask == "Fac")
            {
                for (int i = 1; i < n + 1; i++)
                {
                    fac = fac * i;
                }
                Console.WriteLine(fac);
            }

            if (ask == "deg" || ask == "Deg")
            {
                for (int i = 1; i <= n; i++)
                {
                    deg *= x;
                }
                Console.WriteLine(deg);
            }

            else
            {
                Console.WriteLine("You've choosen wrong manipulation!");
                return;
            }
        }
    }
}