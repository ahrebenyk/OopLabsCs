using System.Text;
using static System.Console;

namespace Lab17;

public static class Threads {
    private const int MinValue = -10;
    private const int MaxValue = 40;

    public static void Main() {
        OutputEncoding = Encoding.UTF8;
        WriteLine("Введіть розмір матриці:");
        var rows = int.Parse(ReadLine());
        var cols = int.Parse(ReadLine());
        var matrix = GenerateMatrix(rows, cols);
        WriteLine("Згенерована матриця:");
        PrintMatrix(matrix);

        var t1 = new Thread(() => GetSumOfPositiveColumns(matrix));
        var t2 = new Thread(() => GetMinSumOfRowAbs(matrix));
        t1.Start();
        t2.Start();
    }

    private static int[,] GenerateMatrix(int rows, int cols) {
        var rand = new Random();
        var matrix = new int[rows, cols];

        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                matrix[i, j] = rand.Next(MinValue, MaxValue);
            }
        }
        return matrix;
    }

    private static void GetSumOfPositiveColumns(int[,] matrix) {
        WriteLine("GetSumOfPositiveColumns: Початок обчислень");
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        var sum = 0;

        for (var j = 0; j < cols; j++) {
            var hasNegative = false;
            var colSum = 0;

            for (var i = 0; i < rows; i++) {
                if (matrix[i, j] < 0) {
                    hasNegative = true;
                    WriteLine($"GetSumOfPositiveColumns: Колонка {j} має негативний елемент: {matrix[i, j]}");
                    break;
                }

                colSum += matrix[i, j];
            }

            if (hasNegative) continue;
            
            WriteLine($"GetSumOfPositiveColumns: Сума елементів колонки {j}: {colSum}");
            sum += colSum;
        }
        WriteLine($"GetSumOfPositiveColumns: Сума елементів стовпців що не містять від'ємних елементів: {sum}");
        WriteLine("GetSumOfPositiveColumns: Кінець обчислень");
    }

    private static void GetMinSumOfRowAbs(int[,] matrix) {
        WriteLine("GetMinSumOfRowAbs: Початок обчислень");
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        var minSum = int.MaxValue;

        for (var i = 0; i < rows; i++) {
            var currentRowSum = 0;
            for (var j = 0; j < cols; j++) {
                currentRowSum += Math.Abs(matrix[i, j]);
            }
            WriteLine($"GetMinSumOfRowAbs: Сума модулів елементів рядка {i}: {currentRowSum}");

            if (currentRowSum < minSum) {
                minSum = currentRowSum;
            }
        }
        WriteLine($"GetMinSumOfRowAbs: Мінімальна сума модулів елементів рядків: {minSum}");
        WriteLine("GetMinSumOfRowAbs: Кінець обчислень");
    }

    private static void PrintMatrix(int[,] matrix) {
        var rows = matrix.GetLength(0);
        var cols = matrix.GetLength(1);
        for (var i = 0; i < rows; i++) {
            for (var j = 0; j < cols; j++) {
                Write($"{matrix[i, j],4} ");
            }

            WriteLine();
        }
    }
}