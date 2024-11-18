using System;
using System.Linq;
using System.Windows;

namespace Batenchuk3._3
{
    public partial class MainWindow : Window
    {
        private double[] array;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateArrayButton_Click(object sender, RoutedEventArgs e)
        {
            int n;
            if (int.TryParse(nTextBox.Text, out n) && n > 0)
            {
                array = new double[n];
                Random rnd = new Random();

                for (int i = 0; i < n; i++)
                {
                    array[i] = Math.Round(rnd.NextDouble() * (12.91 + 28.35) - 28.35, 2);
                }
                arrayTextBlock.Text = "Початковий масив: " + string.Join(", ", array);

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

                productTextBlock.Text = hasNegative ? "Добуток індексів від’ємних елементів: " + product : "В масиві немає від’ємних елементів.";
            }
            else
            {
                MessageBox.Show("Введіть коректне значення для n.");
            }
        }

        private void SortArrayButton(object sender, RoutedEventArgs e)
        {
            int k;
            if (int.TryParse(kTextBox.Text, out k) && k > 0 && k <= array.Length)
            {
                Array.Sort(array, 0, k);
                Array.Reverse(array, 0, k);

                sortedArray.Text = "Масив після впорядкування: " + string.Join(", ", array);
            }
            else
            {
                MessageBox.Show("Помилка: k має бути від 1 до n.");
            }
        }
    }
}
