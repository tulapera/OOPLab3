using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть кількість елементів масиву (n): ");
        int n = int.Parse(Console.ReadLine());

        double[] array = new double[n];
        Random rnd = new Random();

        for (int i = 0; i < n; i++)
        {
            array[i] = Math.Round(rnd.NextDouble() * (12.91 + 28.35) - 28.35, 2);
        }
        Console.WriteLine("Початковий масив:");
        Console.WriteLine(string.Join(", ", array));

        long product = 1;
        bool hasNegative = false;

        for (int i = 0; i < n; i++)
        {
            if (array[i] < 0)
            {
                product *= i;
                hasNegative = true;
            }
        }

        if (hasNegative)
        {
            Console.WriteLine("Добуток індексів від’ємних елементів: " + product);
        }
        else
        {
            Console.WriteLine("В масиві немає від’ємних елементів.");
        }

        Console.Write("Введіть кількість перших елементів для впорядкування (k): ");
        int k = int.Parse(Console.ReadLine());

        if (k > n)
        {
            Console.WriteLine("Помилка: k не може перевищувати n.");
            return;
        }
        Array.Sort(array, 0, k);
        Array.Reverse(array, 0, k);

        Console.WriteLine("Масив після впорядкування перших k елементів:");
        Console.WriteLine(string.Join(", ", array));
    }
}

