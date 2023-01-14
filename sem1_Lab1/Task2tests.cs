/*
 case 1: n = 1 result 
 case 2: n = 3 result 
 case 3: n = 8 result 
 case 4: n = 9 resilt 
 */



using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number:");
            int n = Convert.ToInt32(Console.ReadLine());
            bool check = true;

            for (int i = 2; i < n; i++)
            {
                int ost = n % i;

                if (ost == 0)
                {
                    check = false;
                    Console.WriteLine("The number is not prime");
                    break;

                }

            }
            if (check == true)
            {
                Console.WriteLine("The number is prime");
            }
        }
    }
}
/*
 case 1: n = 1
result :The number is prime

 case 2: n = 3
result :The number is prime

 case 3: n = 8 
result :The number is not prime

 case 4: n = 9 
resilt :The number is not prime
 */