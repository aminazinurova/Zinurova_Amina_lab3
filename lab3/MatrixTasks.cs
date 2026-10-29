using lab3;
using System;
namespace var3
{
    internal class MatrixTasks
    {
        private int[,] _matrix;

        //ЗАДАНИЕ 1
        public MatrixTasks(int n, int m)
        {
            _matrix = new int[n, m];
            Console.WriteLine("Заполнение первого массива (по столбцам):");
            for (int j = 0; j < m; j++) 
            {
                for (int i = 0; i < n; i++) 
                {
                    _matrix[i, j] = Checked.ReadInt($"Элемент [{i},{j}]: ");
                }
            }
        }
        public MatrixTasks(int n)
        {
            _matrix = new int[n, n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + j < n - 1) 
                    {
                        _matrix[i, j] = rnd.Next(-12, 4566);
                    }
                    else 
                    {
                        _matrix[i, j] = rnd.Next(-1024, 1025);
                    }
                }
            }
        }
        public MatrixTasks(int n, bool isThirdMatrix)
        {
            _matrix = new int[n, n];
            int val = 1;

            for (int d = 2 * n - 2; d >= n - 1; d--)
            {
                int startI = Math.Min(n - 1, d);
                int endI = d - (n - 1);
                for (int i = startI; i >= endI; i--)
                {
                    int j = d - i;
                    _matrix[i, j] = val;
                    val++;
                }
            }
        }
        public MatrixTasks(int rows, int cols, bool isEmpty)
        {
            _matrix = new int[rows, cols];
        }


        //ЗАДАНИЕ 2
        public int FindMax3x3Sum()
        {
            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);

            if (rows < 3 || cols < 3)
            {
                Console.WriteLine("Матрица слишком мала для поиска подмассива 3х3");
                return 0;
            }

            int maxSum = int.MinValue;

            for (int i = 0; i <= rows - 3; i++)
            {
                for (int j = 0; j <= cols - 3; j++)
                {
                    int currentSum = 0;
                    for (int r = i; r < i + 3; r++)
                    {
                        for (int c = j; c < j + 3; c++)
                        {
                            currentSum += _matrix[r, c];
                        }
                    }
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                    }
                }
            }
            return maxSum;
        }


        //ЗАДАНИЕ 3
        public MatrixTasks Transpose()
        {
            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);

            MatrixTasks result = new MatrixTasks(cols, rows, true);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result._matrix[j, i] = this._matrix[i, j];
                }
            }
            return result;
        }
        public static MatrixTasks operator +(MatrixTasks a, MatrixTasks b)
        {
            int rows = a._matrix.GetLength(0);
            int cols = a._matrix.GetLength(1);

            MatrixTasks result = new MatrixTasks(rows, cols, true);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result._matrix[i, j] = a._matrix[i, j] + b._matrix[i, j];
                }
            }
            return result;
        }
        public static MatrixTasks operator *(int k, MatrixTasks a)
        {
            int rows = a._matrix.GetLength(0);
            int cols = a._matrix.GetLength(1);

            MatrixTasks result = new MatrixTasks(rows, cols, true);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result._matrix[i, j] = k * a._matrix[i, j];
                }
            }
            return result;
        }
        // ВЫВОД
        public override string ToString()
        {
            string result = "";
            int rows = _matrix.GetLength(0);
            int cols = _matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result += _matrix[i, j].ToString().PadLeft(5) + " ";
                }
                result += "\n";
            }
            return result;
        }
    }
}