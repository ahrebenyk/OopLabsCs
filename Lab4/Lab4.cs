using System.Text;
using static System.Console;

namespace Lab4;

public class Lab4
{
    public static void Main()
    {
        OutputEncoding = Encoding.UTF8;
        WriteLine("Введіть кількість рядків масиву");
        var rows = int.Parse(ReadLine());
        WriteLine("Введіть кількість колонок масиву");
        var cols = int.Parse(ReadLine());
        
        var sourceArray = InitArray(rows, cols);
        WriteLine("Десяткові значення рядків:");
        PrintRowDecimalValues(sourceArray);
    }

    private static int[,] InitArray(int rows, int cols)
    {
        var array = new int[rows, cols];
        for (var i = 0; i < rows; i ++)
        {
            for (var j = 0; j < cols; j++)
            {
                array[i,j] = Random.Shared.Next(0, 2);
            }
        }
        return array;
    }
    
    private static void PrintRowDecimalValues(int[,] array)
    {
        var n = array.GetLength(0);
        var m = array.GetLength(1);
        for (var i = 0; i < n; i++)
        {
            var decimalValue = 0;
            for (var j = 0; j < m; j++)
            {
                Write(array[i, j] + " ");
                if (array[i, j] > 0)
                {
                    decimalValue += (int) Math.Pow(2, m - j - 1);
                }
            }
            Write("\t" + decimalValue + " ");
            WriteLine();
        }
    }
        
}