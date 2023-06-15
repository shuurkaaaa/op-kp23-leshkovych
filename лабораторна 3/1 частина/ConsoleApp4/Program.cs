using System;
using System.Collections;
using System.Collections.Generic;

public class Deque<Item> : IEnumerable<Item>
{
    private Node first;
    private Node last;
    private int count;

    private class Node
    {
        public Item item;
        public Node next;
        public Node previous;
    }

    public Deque()
    {
        first = null;
        last = null;
        count = 0;
    }

    public bool IsEmpty()
    {
        return count == 0;
    }

    public int Size()
    {
        return count;
    }

    public void AddFirst(Item item)
    {
        if (item == null)
            throw new ArgumentNullException();

        Node newNode = new Node
        {
            item = item,
            next = first,
            previous = null
        };

        if (IsEmpty())
        {
            first = newNode;
            last = newNode;
        }
        else
        {
            first.previous = newNode;
            first = newNode;
        }

        count++;
    }

    public void AddLast(Item item)
    {
        if (item == null)
            throw new ArgumentNullException();

        Node newNode = new Node
        {
            item = item,
            next = null,
            previous = last
        };

        if (IsEmpty())
        {
            first = newNode;
            last = newNode;
        }
        else
        {
            last.next = newNode;
            last = newNode;
        }

        count++;
    }

    public Item RemoveFirst()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty");

        Item item = first.item;
        first = first.next;
        count--;

        if (IsEmpty())
            last = null;
        else
            first.previous = null;

        return item;
    }

    public Item RemoveLast()
    {
        if (IsEmpty())
            throw new InvalidOperationException("Deque is empty");

        Item item = last.item;
        last = last.previous;
        count--;

        if (IsEmpty())
            first = null;
        else
            last.next = null;

        return item;
    }

    public IEnumerator<Item> GetEnumerator()
    {
        Node current = first;

        while (current != null)
        {
            yield return current.item;
            current = current.next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Test the Deque implementation
        Deque<int> deque = new Deque<int>();

        deque.AddFirst(1);
        deque.AddFirst(2);
        deque.AddLast(3);
        deque.AddLast(4);

        foreach (int item in deque)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Size: " + deque.Size());

        int removedItem = deque.RemoveFirst();
        Console.WriteLine("Removed item: " + removedItem);

        foreach (int item in deque)
        {
            Console.WriteLine(item);
        }
    }
}