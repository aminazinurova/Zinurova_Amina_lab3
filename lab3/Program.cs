using lab3;
using System;
using System.IO; 
using System.Xml.Serialization;
namespace var3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.3");
            Console.WriteLine("\n1.Первый массив:");
            MatrixTasks m1 = new MatrixTasks(2, 3);
            Console.WriteLine(m1);
            Console.WriteLine("\n2.Второй массив (4x4):");
            MatrixTasks m2 = new MatrixTasks(4);
            Console.WriteLine(m2);
            Console.WriteLine("\n3.Третий массив (5x5):");
            MatrixTasks m3 = new MatrixTasks(5, true);
            Console.WriteLine(m3);

            Console.WriteLine("\nЗадание 2.3");
            MatrixTasks matrixForTask2 = new MatrixTasks(4);
            Console.WriteLine("Случайная матрица 4x4 для проверки:");
            Console.WriteLine(matrixForTask2);
            int maxSum = matrixForTask2.FindMax3x3Sum();
            Console.WriteLine($"Максимальная сумма подмассива 3x3: {maxSum}");


            Console.WriteLine("\nЗадание 3.3");
            MatrixTasks A = new MatrixTasks(3);
            MatrixTasks B = new MatrixTasks(3);
            MatrixTasks C = new MatrixTasks(3);
            Console.WriteLine("Матрица A:");
            Console.WriteLine(A);
            Console.WriteLine("Матрица B:");
            Console.WriteLine(B);
            Console.WriteLine("Матрица C:");
            Console.WriteLine(C);
            MatrixTasks A_T = A.Transpose();
            MatrixTasks C_T = C.Transpose();
            MatrixTasks twoB = 2 * B;
            MatrixTasks result = A_T + twoB + C_T;
            Console.WriteLine("Результат (A^T + 2*B + C^T):");
            Console.WriteLine(result);

            Console.WriteLine("\nЗадание 4.3");
            string binaryPath = "numbers.bin";
            string resultBinaryPath = "result_numbers.bin";
            FileTasks.FillBinaryFile(binaryPath, 20);
            Console.WriteLine($"Файл {binaryPath} создан и заполнен");
            Console.Write("Исходные числа: ");
            using (BinaryReader reader = new BinaryReader(File.Open(binaryPath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Console.Write(reader.ReadInt32() + " ");
                }
            }
            Console.WriteLine();
            int m = Checked.ReadInt("Введите m (делитель, на который ДОЛЖНО делиться): ");
            int n = Checked.ReadInt("Введите n (делитель, на который НЕ ДОЛЖНО делиться): ");
            Console.WriteLine($"\nИщем числа, которые делятся на {m} и не делятся на {n}");
            FileTasks.Task4_3(binaryPath, resultBinaryPath, m, n);
            Console.Write($"\nЧисла в новом файле {resultBinaryPath}: ");
            using (BinaryReader reader = new BinaryReader(File.Open(resultBinaryPath, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    Console.Write(reader.ReadInt32() + " ");
                }
            }
            Console.WriteLine();


            Console.WriteLine("\nЗадание 5.3");
            string xmlBinPath = "passengers.bin";
            FileTasks.FillBinaryXmlFile(xmlBinPath, 10);
            Console.WriteLine($"Файл {xmlBinPath} создан и заполнен");
            XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
            using (FileStream fs = new FileStream(xmlBinPath, FileMode.Open))
            {
                Passenger[] list = (Passenger[])serializer.Deserialize(fs);
                for (int i = 0; i < list.Length; i++)
                {
                    Console.WriteLine($"Пассажир {i + 1}: {list[i]}");
                }
            }
            double M = 5.0;
            bool found = FileTasks.Task5_3(xmlBinPath, m);
            Console.WriteLine($"\nИмеется ли пассажир с одной вещью массой менее {M} кг? {found}");


            Console.WriteLine("\nЗадание 6.3");
            string textPath6 = "task6.txt";
            FileTasks.FillTextFile6(textPath6, 10);
            Console.WriteLine($"Файл {textPath6} создан и заполнен");
            Console.WriteLine("Числа в файле:");
            string[] lines6 = File.ReadAllLines(textPath6);
            foreach (string line in lines6)
            {
                Console.Write(line + " ");
            }
            Console.WriteLine();
            int diff = FileTasks.Task6_3(textPath6);
            Console.WriteLine($"Разность максимального и минимального элементов: {diff}");

            Console.WriteLine("\nЗадание 7.3");
            string textPath7 = "task7.txt";
            FileTasks.FillTextFile7(textPath7, 5); 
            Console.WriteLine($"Файл {textPath7} создан и заполнен");
            Console.WriteLine("Содержимое файла:");
            Console.WriteLine(File.ReadAllText(textPath7));
            int minValue = FileTasks.Task7_3(textPath7);
            Console.WriteLine($"Минимальный элемент: {minValue}");

            Console.WriteLine("\nЗадание 8.3");
            string inputPath8 = "task8_input.txt";
            string outputPath8 = "task8_output.txt";
            FileTasks.FillTextFile8(inputPath8);
            Console.WriteLine($"Файл {inputPath8} создан");
            Console.Write("Введите символ, с которого должны начинаться строки: ");
            char searchChar = Checked.ReadChar();
            FileTasks.Task8_3(inputPath8, outputPath8, searchChar);
            Console.WriteLine($"\nСтроки, начинающиеся на '{searchChar}', записаны в {outputPath8}:");
            Console.WriteLine(File.ReadAllText(outputPath8));

            Console.WriteLine("\nНажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}