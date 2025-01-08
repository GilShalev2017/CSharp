using System;
using System.Collections.Generic;
using System.Text;

class CharacterStreamProcessor
{
    private StringBuilder characterStream = new StringBuilder();

    public void Append(string characters)
    {
        characterStream.Append(characters);
    }

    public void Remove(int startIndex, int endIndex)
    {
        if (startIndex >= 0 && startIndex <= endIndex && endIndex < characterStream.Length)
        {
            characterStream.Remove(startIndex, endIndex - startIndex + 1);
        }
    }

    public string GetStream()
    {
        return characterStream.ToString();
    }
}

class Program
{
    static void Main()
    {
        CharacterStreamProcessor processor = new CharacterStreamProcessor();

        processor.Append("abcde");
        Console.WriteLine("Character Stream: " + processor.GetStream());

        processor.Append("fghij");
        Console.WriteLine("Character Stream: " + processor.GetStream());

        processor.Remove(2, 4);
        Console.WriteLine("Character Stream after removal: " + processor.GetStream());
    }
}
