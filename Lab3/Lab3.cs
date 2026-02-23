using System.Text;
using static System.Console;

namespace Lab3;

public class Lab3
{
    public static void Main()
    {
        OutputEncoding = Encoding.UTF8;
        WriteLine("Введіть кількість рядків масиву");
        var rows = ReadInt();
        WriteLine("Введіть мін кількість елементів в рядку масиву");
        var minRowSize = ReadInt();
        WriteLine("Введіть макс кількість елементів в рядку масиву");
        var maxRowSize = ReadInt();
        
        var sourceArray = InitArray(rows, minRowSize, maxRowSize);
        WriteLine("Початковий масив:");
        PrintArray(sourceArray);

        var flatArray = GetFlatArray(sourceArray);
        WriteLine("Одновимірний масив:");
        PrintArray(flatArray);
        
        SortArray(flatArray);
        WriteLine("Відсортований масив:");
        PrintArray(flatArray);

        var matrix = FlatArrayToMatrix(flatArray);
        WriteLine("Відсортована таблиця:");
        PrintArray(matrix);
    }

    private static int ReadInt()
    {
        return int.Parse(ReadLine());
    }

    private static int[][] InitArray(int rows, int minRowSize, int maxRowSize)
    {
        var array = new int[rows][];
        var numOfElements = 0;
        for (var i = 0; i < rows; i ++)
        {
            var rowSize = i == rows - 1 
                ? GetNextSquare(numOfElements) - numOfElements
                : Random.Shared.Next(minRowSize, maxRowSize + 1);

            numOfElements += rowSize;
            array[i] = new int[rowSize];
            for (var j = 0; j < rowSize; j++)
            {
                array[i][j] = Random.Shared.Next(0, 100);
            }
        }
        return array;
    }

    private static void PrintArray(int[][] array)
    {
        foreach (var row in array)
        {
            PrintArray(row);
        }
    }
    
    private static void PrintArray(int[] array)
    {
        WriteLine(string.Join(" ", array));
    }
    
    private static void PrintArray(int[,] array)
    {
        var n = array.GetLength(0);
        var m = array.GetLength(1);
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                Write(array[i, j] + " "); 
            }
            WriteLine();
        }
    }
    
    private static int GetNextSquare(int n)
    {
        var nextRoot = (int) Math.Floor(Math.Sqrt(n)) + 1;
        return nextRoot * nextRoot;
    }

    private static int GetTotalElements(int[][] array)
    {
        var totalElements = 0;
        foreach (var row in array)
        {
            totalElements += row.Length;
        }    
        return totalElements;
    }
        
    private static int[] GetFlatArray(int[][] array)
    {
        int[] flatArray = new int[GetTotalElements(array)];
        var index = 0;

        for (var i = 0; i < array.Length; i++)
        {
            for (var j = 0; j < array[i].Length; j++)
            {
                flatArray[index] = array[i][j];
                index++;
            }
        }
        return flatArray;
    }
        
    private static void SortArray(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            (array[minIndex], array[i]) = (array[i], array[minIndex]);
        }    
    }
        
    private static int[,] FlatArrayToMatrix(int[] array)
    {
        var n = (int) Math.Sqrt(array.Length);
        var matrix = new int[n, n];
            
        var index = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
               matrix[i, j] = array[index]; 
               index++;
            }
        }

        return matrix;
    }
        
}