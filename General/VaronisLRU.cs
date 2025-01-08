using System;
using System.Collections.Generic;

class LRUCache<TKey, TValue>
{
    private readonly int capacity;
    private readonly Dictionary<TKey, LinkedListNode<CacheItem>> cache;
    private readonly LinkedList<CacheItem> lruList;

    public LRUCache(int capacity)
    {
        this.capacity = capacity;
        cache = new Dictionary<TKey, LinkedListNode<CacheItem>>(capacity);
        lruList = new LinkedList<CacheItem>();
    }

    public TValue Get(TKey key)
    {
        if (cache.TryGetValue(key, out var node))
        {
            lruList.Remove(node);  // Move the accessed item to the front of the list
            lruList.AddFirst(node);
            return node.Value.Value;
        }

        return default(TValue);
    }

    public void Set(TKey key, TValue value)
    {
        if (cache.TryGetValue(key, out var node))
        {
            // Update existing item
            node.Value.Value = value;
            lruList.Remove(node);
            lruList.AddFirst(node);
        }
        else
        {
            // Add new item
            if (cache.Count >= capacity)
            {
                // Remove least recently used item
                var lastNode = lruList.Last;
                cache.Remove(lastNode.Value.Key);
                lruList.RemoveLast();
            }

            // Add new item to the front of the list
            var newNode = new LinkedListNode<CacheItem>(new CacheItem(key, value));
            lruList.AddFirst(newNode);
            cache.Add(key, newNode);
        }
    }

    private class CacheItem
    {
        public TKey Key { get; }
        public TValue Value { get; set; }

        public CacheItem(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}

class Program
{
    static void Main()
    {
        LRUCache<string, int> cache = new LRUCache<string, int>(3);

        cache.Set("a", 1);
        cache.Set("b", 2);
        cache.Set("c", 3);

        Console.WriteLine(cache.Get("a")); // Output: 1
        Console.WriteLine(cache.Get("b")); // Output: 2
        Console.WriteLine(cache.Get("c")); // Output: 3

        cache.Set("d", 4);

        Console.WriteLine(cache.Get("a")); // Output: 0 (not found)
        Console.WriteLine(cache.Get("b")); // Output: 2
        Console.WriteLine(cache.Get("c")); // Output: 3
        Console.WriteLine(cache.Get("d")); // Output: 4
    }
}
