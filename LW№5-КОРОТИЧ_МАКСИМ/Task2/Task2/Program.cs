using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MathOperations
    {
        // Перевантажений метод Add для двох чисел
        public static double Add(double a, double b) => a + b;

        // Перевантажений метод Add для масиву чисел
        public static double Add(double[] numbers)
        {
            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        // Перевантажений метод Add для матриць
        public static double[,] Add(double[,] matrix1, double[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            {
                throw new ArgumentException("Матриці повинні мати однакові розміри.");
            }

            double[,] result = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        // Метод Subtract для матриць
        public static double[,] Subtract(double[,] matrix1, double[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);

            if (rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
            {
                throw new ArgumentException("Матриці повинні мати однакові розміри.");
            }

            double[,] result = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }
            return result;
        }

        // Метод Multiply для чисел
        public static double Multiply(double a, double b) => a * b;

        // Метод Multiply для масиву чисел
        public static double Multiply(double[] numbers)
        {
            double product = 1;
            foreach (var number in numbers)
            {
                product *= number;
            }
            return product;
        }
    }

    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Додавання чисел:");
            Console.WriteLine(MathOperations.Add(3, 5));

            Console.WriteLine("\nДодавання масиву чисел:");
            Console.WriteLine(MathOperations.Add(new double[] { 1, 2, 3, 4, 5 }));

            Console.WriteLine("\nДодавання матриць:");
            double[,] matrix1 = { { 1, 2 }, { 3, 4 } };
            double[,] matrix2 = { { 5, 6 }, { 7, 8 } };
            double[,] result = MathOperations.Add(matrix1, matrix2);

            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nМноження чисел:");
            Console.WriteLine(MathOperations.Multiply(6, 7));

            Console.WriteLine("\nМноження масиву чисел:");
            Console.WriteLine(MathOperations.Multiply(new double[] { 2, 3, 4 }));
        }
    }
}
