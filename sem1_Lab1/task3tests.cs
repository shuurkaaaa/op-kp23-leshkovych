/*
 case 1: n = 4, x = 3, ask = deg
 case 2: n = 5, x = 2, ask = <Fac>
 case 3: n = 6, x = 4, ask = ffc
 */


using System;

namespace Task3tests


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
/*
 case 1: result - 81
 case 2:"You've choosen wrong manipulation!"
 case 3: "You've choosen wrong manipulation!"
 */