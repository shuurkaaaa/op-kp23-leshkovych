using System;

namespace Task1_Tests
{
    class Program
    {
        // <summary> 
        //     test cases: 
        //     1.  
        //     x0 = 3 
        //     xn = 7 
        //     n = 5 
        //      
        //     res: 
        //     output of the program 
        //     x = 3 f(x) = 3,639929390244485 
        //     x = 4 f(x) = 3,6826582412937388 
        //     x = 5 f(x) = 3,7322023713445707 
        //     x = 6 f(x) = 3,7894836048526876 
        //     x = 7 f(x) = 3,8553352414788176 

        //     2.  
        //     x0 = 1 
        //     xn = 4 
        //     n = 4 
        //     res: 
        //     output of the program  
        //     x = 1 f(x) = 3,57053269648137 
        //     x = 2 f(x) = 3,6029691148379386 
        //     x = 3 f(x) = 3,639929390244485 
        //     x = 4 f(x) = 3,6826582412937388 

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
