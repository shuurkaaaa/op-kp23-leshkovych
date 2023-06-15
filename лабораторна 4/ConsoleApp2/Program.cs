using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    public class HashTable<KItem, VItem>
    {
        private const int DefaultCapacity = 16;
        private LinkedList<KeyValuePair<KItem, VItem>>[] buckets;

        public HashTable()
        {
            buckets = new LinkedList<KeyValuePair<KItem, VItem>>[DefaultCapacity];
        }

        public HashTable(int initialCapacity)
        {
            buckets = new LinkedList<KeyValuePair<KItem, VItem>>[initialCapacity];
        }

        private int GetBucketIndex(KItem key)
        {
            int hashCode = key.GetHashCode();
            return Math.Abs(hashCode) % buckets.Length;
        }

        public void Add(KItem key, VItem value)
        {
            int index = GetBucketIndex(key);
            if (index < buckets.Length)
            {
                if (buckets[index] == null)
                {
                    buckets[index] = new LinkedList<KeyValuePair<KItem, VItem>>();
                }
                else
                {
                    foreach (var pair in buckets[index])
                    {
                        if (pair.Key.Equals(key))
                        {
                            // Key already exists, remove the existing pair
                            buckets[index].Remove(pair);
                            break;
                        }
                    }
                }

                buckets[index].AddLast(new KeyValuePair<KItem, VItem>(key, value));
            }
        }

        public bool ContainsKey(KItem key)
        {
            int index = GetBucketIndex(key);
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public VItem Get(KItem key)
        {
            int index = GetBucketIndex(key);
            if (buckets[index] != null)
            {
                foreach (var pair in buckets[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        return pair.Value;
                    }
                }
            }
            throw new KeyNotFoundException("Key not found in the hash table.");
        }

        public void Remove(KItem key)
        {
            int index = GetBucketIndex(key);
            if (buckets[index] != null)
            {
                LinkedListNode<KeyValuePair<KItem, VItem>> currentNode = buckets[index].First;
                while (currentNode != null)
                {
                    if (currentNode.Value.Key.Equals(key))
                    {
                        buckets[index].Remove(currentNode);
                        return;
                    }
                    currentNode = currentNode.Next;
                }
            }
            throw new KeyNotFoundException("Key not found in the hash table.");
        }

        public void Clear()
        {
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = null;
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            
            HashTable<string, bool> dictionary = new HashTable<string, bool>();

            
            dictionary.Add("apple", true);
            dictionary.Add("banana", true);
            dictionary.Add("cat", true);
            dictionary.Add("dog", true);
            dictionary.Add("elephant", true);
          

            Console.WriteLine("Введiть слов для перевiрки (для вихода введите '0'):");

            while (true)
            {
                string word = Console.ReadLine();

                if (word == "0")
                    break;

                // 
                if (dictionary.ContainsKey(word))
                {
                    Console.WriteLine("ok");
                }
                else
                {
                    Console.WriteLine("WrongSpelling");
                }

            }

        }
    }
}
