/*
 * 
 case 1: a = 3
 case 2: a = 1
 case 3: a = 173
 case 4: a = 22
 case 5: a = 8
 
 */





using System;

namespace Task4test
{

    class Program
    {
        static double Pow(double x, double n)
        {
            double result = x;
            if (n == 0) return 1;
            for (int j = 1; j < n; j++)
                result *= x;
            return result;
        }

        static double Fac(double n)
        {
            double factorial = 1;
            for (int j = 1; j <= n; j++)
                factorial *= j;
            return factorial;
        }
        static double Sin(double val)
        {
            while (val > 3.14159265359 * 2)
            {
                val -= 3.14159265359 * 2;
            }
            double result = 0;
            for (int i = 0; i < 10; i++)
            {
                double a = Pow(-1, i);
                double x = Pow(val, (2 * i) + 1);

                double f = Fac((2 * i) + 1);

                result += (a * x / f);
            }

            return result;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Input number: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("With Mathematics Library: " + Math.Sin(a));
                Console.WriteLine("Without using a library: " + Sin(a));
            }

        }
    }
}
/*
 * 
 case 1: With Mathematics Library: 0,1411200080598672
         Without using a library: 0,14112000785871492
 case 2: With Mathematics Library: 0,8414709848078965
         Without using a library: 0,8414709848078965
 case 3: With Mathematics Library: 0,8414709848078965
         Without using a library: 0,8414709848078965
 case 4: With Mathematics Library: -0,008851309290403876
         Without using a library: -0,008851309850212466
 case 5: With Mathematics Library: 0,9893582466233818
         Without using a library: 0,9893582466234404
 
 */