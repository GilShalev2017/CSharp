using System;
using System.Collections;
using System.Collections.Generic;
/*
class AboveDiagonalIterator<T> : IEnumerator<T>
{
    private T[,] matrix;
    private int size;
    private int row;
    private int col;

    public AboveDiagonalIterator(T[,] matrix)
    {
        this.matrix = matrix;
        size = matrix.GetLength(0);
        Reset();
    }

    public T Current => matrix[row, col];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (col == size - 1)
        {
            row++;
            col = row + 1;
        }
        else
        {
            col++;
        }

        return row < size && col < size;
    }

    public void Reset()
    {
        row = 0;
        col = 0;
    }

    public void Dispose()
    {
        // No resources to release
    }
}

class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        foreach (int num in AboveDiagonal(matrix))
        {
            Console.Write(num + " ");
        }

        Console.WriteLine();
    }

    static IEnumerable<T> AboveDiagonal<T>(T[,] matrix)
    {
        return new AboveDiagonalEnumerable<T>(matrix);
    }
}

class AboveDiagonalEnumerable<T> : IEnumerable<T>
{
    private T[,] matrix;

    public AboveDiagonalEnumerable(T[,] matrix)
    {
        this.matrix = matrix;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new AboveDiagonalIterator<T>(matrix);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
*/