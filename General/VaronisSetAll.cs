using System;
using System.Collections.Generic;

class ConstantTimeDataStructure<T>
{
    private Dictionary<int, T> dictionary;
    private Queue<int> queue;
    private T setAllValue;

    public ConstantTimeDataStructure()
    {
        dictionary = new Dictionary<int, T>();
        queue = new Queue<int>();
    }

    public void Set(int index, T value)
    {
        dictionary[index] = value;
        queue.Enqueue(index);
    }

    public T Get(int index)
    {
        if (dictionary.ContainsKey(index))
        {
            return dictionary[index];
        }

        return default(T); // Or throw an exception, depending on your requirement
    }

    public void SetAll(T value)
    {
        setAllValue = value;
        queue.Clear();
    }

    public T GetAll()
    {
        if (queue.Count > 0)
        {
            return dictionary[queue.Peek()];
        }

        return setAllValue;
    }
}

class Program
{
    static void Main()
    {
        ConstantTimeDataStructure<int> dataStructure = new ConstantTimeDataStructure<int>();

        dataStructure.Set(0, 10);
        dataStructure.Set(1, 20);
        dataStructure.Set(2, 30);

        Console.WriteLine(dataStructure.Get(0)); // Output: 10
        Console.WriteLine(dataStructure.Get(1)); // Output: 20
        Console.WriteLine(dataStructure.Get(2)); // Output: 30

        dataStructure.SetAll(100);

        Console.WriteLine(dataStructure.Get(0)); // Output: 100
        Console.WriteLine(dataStructure.Get(1)); // Output: 100
        Console.WriteLine(dataStructure.Get(2)); // Output: 100

        Console.WriteLine(dataStructure.GetAll()); // Output: 100
    }
}
