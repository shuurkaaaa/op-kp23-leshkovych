using System;

namespace Task1_Lab1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            double x0 = 0;
            double xn = 0;
            double n = 0;
            double b = 34.5;

            Console.Write("Enter x0 - ");
            x0 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter xn - ");
            xn = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter n - ");
            n = Convert.ToDouble(Console.ReadLine());

            double dx = (xn - x0) / (n - 1);
            for (double x = x0; x <= xn; x += dx)
            {
                double y = ResFormula(x, b);
                Console.WriteLine("x = " + x + " f(x) = " + y);
            }


        }

        static double ResFormula(double x, double b)
        {
            if (x == b)
            {
                return 0;
            }

            double degree = 5.0 / 2.0;


            double abs = Math.Pow(Math.Abs(x), degree);
            double pow = Math.Pow(10, -3);
            double logE = Math.Log(Math.Abs(x + b));

            return abs * pow + logE;

        }
    }
}
