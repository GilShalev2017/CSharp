using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GeneralCompany
{
    using System.Collections.Generic;

    public class SetAllDataStructure<T>
    {
        private Dictionary<int, T> data;
        private List<int> setAllIndices;
        private T setAllValue;

        public SetAllDataStructure()
        {
            data = new Dictionary<int, T>();
            setAllIndices = new List<int>();
            setAllValue = default(T);
        }

        public void Set(int index, T value)
        {
            if (data.ContainsKey(index))
            {
                data[index] = value;
            }
            else
            {
                data.Add(index, value);
            }
        }

        public T Get(int index)
        {
            if (setAllIndices.Contains(index))
            {
                return setAllValue;
            }
            else if (data.ContainsKey(index))
            {
                return data[index];
            }
            else
            {
                return default(T);
            }
        }

        public void SetAll(T value)
        {
            setAllIndices.Clear();
            setAllValue = value;
        }
    }

    public class MatrixIterator
    {
        private int[,] matrix;
        private int size;
        private int row;
        private int col;

        public MatrixIterator(int[,] matrix)
        {
            this.matrix = matrix;
            this.size = matrix.GetLength(0);
            this.row = 0;
            this.col = 1; // Start from the cell above the main diagonal
        }

        public bool MoveNext()
        {
            while (row < size - 1)
            {
                if (col >= size)
                {
                    // Move to the next row above the main diagonal
                    row++;
                    col = row + 1;
                }
                else
                {
                    // Process the current cell and move to the next column
                    Current = matrix[row, col];
                    col++;
                    return true;
                }
            }

            return false; // Reached the end of the iterator
        }

        public int Current { get; private set; }
    }

}
/*
In this implementation, the SetAllDataStructure<T> class uses a Dictionary<int, T> to store the individual values at each index, where the index is the key and the value is the corresponding data.Additionally, we maintain a List<int> called setAllIndices to keep track of the indices that have been set to the "setAll" value.

The Set method allows setting a specific index to a given value. If the index already exists in the data dictionary, the value is updated.Otherwise, a new key- value pair is added to the dictionary.

The Get method retrieves the value at a specified index. If the index is present in the setAllIndices list, it means that it has been set to the "setAll" value. In that case, the method returns the setAllValue. If the index is present in the data dictionary, the method returns the corresponding value. If the index is not present in either the setAllIndices or the data dictionary, the method returns the default value of type T.

The SetAll method sets all the indices to a specified value. It clears the setAllIndices list and updates the setAllValue.

Note that this implementation assumes that the indices used are integers and start from 0. Also, the T type can be replaced with any data type you desire.

Using this data structure, you can perform set, get, and setAll operations in O(1) time complexity.

*/



