using System;
using System.Collections;
using System.Collections.Generic;

public class RandomizedQueue<Item> : IEnumerable<Item>
{
    private Item[] array;
    private int count;
    private Random random;

    public RandomizedQueue()
    {
        array = new Item[2];
        count = 0;
        random = new Random();
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public int Size()
    {
        return count;
    }

    public void Enqueue(Item item)
    {
        if (item == null)
            throw new ArgumentNullException();

        if (count == array.Length)
            ResizeArray(2 * array.Length);

        array[count++] = item;
    }

    public Item Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Randomized queue is empty");

        int randomIndex = random.Next(count);
        Item item = array[randomIndex];

        array[randomIndex] = array[count - 1];
        array[count - 1] = default(Item);

        count--;

        if (count > 0 && count == array.Length / 4)
            ResizeArray(array.Length / 2);

        return item;
    }

    public Item Sample()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Randomized queue is empty");

        int randomIndex = random.Next(count);
        return array[randomIndex];
    }

    public IEnumerator<Item> GetEnumerator()
    {
        Item[] randomizedArray = new Item[count];
        Array.Copy(array, randomizedArray, count);
        Shuffle(randomizedArray);

        foreach (Item item in randomizedArray)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private void ResizeArray(int capacity)
    {
        Item[] newArray = new Item[capacity];
        Array.Copy(array, newArray, count);
        array = newArray;
    }

    private void Shuffle(Item[] items)
    {
        int n = items.Length;
        for (int i = 0; i < n; i++)
        {
            int randomIndex = i + random.Next(n - i);
            Item temp = items[randomIndex];
            items[randomIndex] = items[i];
            items[i] = temp;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Test the RandomizedQueue implementation
        RandomizedQueue<int> randomizedQueue = new RandomizedQueue<int>();

        randomizedQueue.Enqueue(1);
        randomizedQueue.Enqueue(2);
        randomizedQueue.Enqueue(3);
        randomizedQueue.Enqueue(4);

        foreach (int item in randomizedQueue)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Size: " + randomizedQueue.Size());

        int removedItem = randomizedQueue.Dequeue();
        Console.WriteLine("Removed item: " + removedItem);

        foreach (int item in randomizedQueue)
        {
            Console.WriteLine(item);
        }
    }
}