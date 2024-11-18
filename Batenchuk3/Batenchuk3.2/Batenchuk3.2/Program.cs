using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть кількість рядків (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введіть кількість стовпців (m): ");
        int m = int.Parse(Console.ReadLine());

        double[,] arr = new double[n, m];
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = Math.Round(rnd.NextDouble() * (60.3 + 24.9) - 24.9, 1);
            }
        }
        Console.WriteLine("Початковий масив:");
        PrintArray(arr);

        int nonNegativeRows = 0;
        for (int i = 0; i < n; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < m; j++)
            {
                if (arr[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (!hasNegative) nonNegativeRows++;
        }
        Console.WriteLine("Кількість рядків без жодного від’ємного елемента: " + nonNegativeRows);
        var rowSums = new List<(double[] Row, double Sum)>();

        for (int i = 0; i < n; i++)
        {
            var row = new double[m];
            double sum = 0;
            for (int j = 0; j < m; j++)
            {
                row[j] = arr[i, j];
                sum += row[j];
            }
            rowSums.Add((row, sum));
        }
        rowSums = rowSums.OrderByDescending(r => r.Sum).ToList();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr[i, j] = rowSums[i].Row[j];
            }
        }

        Console.WriteLine("Масив після впорядкування рядків за спаданням сум елементів:");
        PrintArray(arr);
    }
    static void PrintArray(double[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                Console.Write(arr[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
