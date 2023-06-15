using System;

class Vessel
{
    public virtual void PrepareToMovement()
    {
        Console.WriteLine("Vessel: Підготовка до руху");
    }

    public virtual void Move()
    {
        Console.WriteLine("Vessel: Рух");
    }
}

class SailingVessel : Vessel
{
    public override void PrepareToMovement()
    {
        Console.WriteLine("SailingVessel: Підготовка до руху парусника");
    }

    public override void Move()
    {
        Console.WriteLine("SailingVessel: Рух парусника");
    }
}

class Submarine : Vessel
{
    public override void PrepareToMovement()
    {
        Console.WriteLine("Submarine: Підготовка до руху підводного човна");
    }

    public override void Move()
    {
        Console.WriteLine("Submarine: Рух підводного човна");
    }
}

class Program
{
    static void Main()
    {
        Vessel[] vessels = new Vessel[] { new SailingVessel(), new Submarine() };

        foreach (var vessel in vessels)
        {
            vessel.PrepareToMovement();
            vessel.Move();
            Console.WriteLine();
        }

        int[] vector1 = { -2, 3, 0, -5, 8 };
        int[] vector2 = { 1, -4, 0, 6, -9 };

        int sumOfNegatives = GetSumOfNegatives(vector1, vector2);
        Console.WriteLine("Сума від'ємних елементів двох векторів: " + sumOfNegatives);

        int productOfEvenIndices = GetProductOfEvenIndices(vector1, vector2);
        Console.WriteLine("Добуток елементів двох векторів з парними індексами: " + productOfEvenIndices);

        int zeroCount = GetZeroCount(vector1, vector2);
        Console.WriteLine("Кількість елементів двох векторів, рівних 0: " + zeroCount);
    }

    static int GetSumOfNegatives(params int[][] vectors)
    {
        int sum = 0;

        foreach (var vector in vectors)
        {
            foreach (var element in vector)
            {
                if (element < 0)
                {
                    sum += element;
                }
            }
        }

        return sum;
    }

    static int GetProductOfEvenIndices(params int[][] vectors)
    {
        int product = 1;

        foreach (var vector in vectors)
        {
            for (int i = 0; i < vector.Length; i += 2)
            {
                product *= vector[i];
            }
        }

        return product;
    }

    static int GetZeroCount(params int[][] vectors)
    {
        int count = 0;

        foreach (var vector in vectors)
        {
            foreach (var element in vector)
            {
                if (element == 0)
                {
                    count++;
                }
            }
        }

        return count;
    }
}