using System;
using System.Collections.Generic;
using System.Text;
/*
class CharacterProcessor
{
    private List<char> characterList;

    public CharacterProcessor()
    {
        characterList = new List<char>();
    }

    public void Add(char character)
    {
        characterList.Add(character);
    }

    public void Remove(int startIndex, int endIndex)
    {
        if (startIndex >= 0 && startIndex <= endIndex && endIndex < characterList.Count)
        {
            characterList.RemoveRange(startIndex, endIndex - startIndex + 1);
        }
    }

    public void Print()
    {
        Console.WriteLine(string.Join("", characterList));
    }
}

class Program
{
    static void Main()
    {
        CharacterProcessor processor = new CharacterProcessor();

        processor.Add('a');
        processor.Add('b');
        processor.Add('c');
        processor.Add('d');

        // Remove characters from index 2 to 3 (inclusive)
        processor.Remove(2, 3);

        // Print the remaining characters
        processor.Print();
    }
}
*/