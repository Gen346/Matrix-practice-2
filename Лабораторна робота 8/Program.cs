using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Input n of columns and rows: ");
        int n = int.Parse(Console.ReadLine());
        int rows = n; // кількість рядків
        int cols = n; // кількість стовпчиків

        // Генеруємо випадкову матрицю A
        Random random = new Random();
        int[,] matrixA = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrixA[i, j] = random.Next(-10, 11); // випадкові значення від -10 до 10
            }
        }

        // Обчислюємо транспоновану матрицю B
        int[,] matrixB = new int[cols, rows];
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                matrixB[i, j] = matrixA[j, i];
            }
        }

        // Обчислюємо добутки від'ємних елементів останніх стовпчиків матриць A і B
        int productA = 1;
        int productB = 1;
        for (int i = 0; i < rows; i++)
        {
            productA *= matrixA[i, cols - 1];
            productB *= matrixB[i, cols - 1];
        }

        // Порівнюємо добутки і виконуємо відповідну операцію
        if (productA == productB)
        {
            // Формуємо вектор з додатних діагональних елементів матриці A
            int[] diagonalVector = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                diagonalVector[i] = matrixA[i, i];
            }

            // Виводимо вектор на екран
            Console.WriteLine("Vector with additional diagonal matrix A: ");
            Console.WriteLine(string.Join(" ", diagonalVector));
        }
        else
        {
            // Знаходимо добуток матриць A і B
            int[,] productMatrix = new int[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < rows; k++)
                    {
                        productMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            // Виводимо добуток матриць на екран
            Console.WriteLine("Multiply A and B:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(productMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
