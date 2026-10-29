using System;
using System.IO;
using System.Xml.Serialization;
namespace var3
{
    internal class FileTasks
    {
        public static void FillBinaryFile(string path, int count)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                Random rnd = new Random();
                for (int i = 0; i < count; i++)
                {
                    writer.Write(rnd.Next(-10, 11));
                }
            }
        }
        //ЗАДАНИЕ 4
        public static void Task4_3(string inputPath, string outputPath, int m, int n)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(inputPath, FileMode.Open)))
            using (BinaryWriter writer = new BinaryWriter(File.Open(outputPath, FileMode.Create)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int val = reader.ReadInt32();
                    if (val % m == 0 && val % n != 0)
                    {
                        writer.Write(val);
                    }
                }
            }
        }

        //ЗАДАНИЕ 5
        public static void FillBinaryXmlFile(string path, int count)
        {
            Random rnd = new Random();
            string[] names = { "Чемодан", "Сумка", "Коробка", "Рюкзак" };

            Passenger[] passengers = new Passenger[count];

            for (int i = 0; i < count; i++)
            {
                int itemsCount = rnd.Next(1, 4);
                Baggage[] items = new Baggage[itemsCount];

                for (int j = 0; j < itemsCount; j++)
                {
                    string name = names[rnd.Next(names.Length)];
                    double weight = Math.Round(rnd.NextDouble() * 20 + 1, 1);
                    items[j] = new Baggage(name, weight);
                }

                passengers[i] = new Passenger(items);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(fs, passengers);
            }
        }


        public static bool Task5_3(string path, double m)
        {
            Passenger[] passengers;
            XmlSerializer serializer = new XmlSerializer(typeof(Passenger[]));
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                passengers = (Passenger[])serializer.Deserialize(fs);
            }
            for (int i = 0; i < passengers.Length; i++)
            {
                if (passengers[i].Items.Length == 1 && passengers[i].Items[0].Weight < m)
                {
                    return true;
                }
            }

            return false;
        }

        //ЗАДАНИЕ 6
        public static void FillTextFile6(string path, int count)
        {
            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.WriteLine(rnd.Next(-100, 100));
                }
            }
        }
        public static int Task6_3(string path)
        {
            string[] lines = File.ReadAllLines(path);

            if (lines.Length == 0)
                return 0; 
            int min = int.MaxValue;
            int max = int.MinValue;
            for (int i = 0; i < lines.Length; i++)
            {
                if (int.TryParse(lines[i], out int val))
                {
                    if (val < min) min = val;
                    if (val > max) max = val;
                }
            }

            return max - min;
        }
    
        //ЗАДАНИЕ 7
        public static void FillTextFile7(string path, int rows)
        {
            Random rnd = new Random();
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 0; i < rows; i++)
                {
                    int countInRow = rnd.Next(3, 6); 
                    for (int j = 0; j < countInRow; j++)
                    {
                        writer.Write(rnd.Next(-50, 50) + " "); 
                    }
                    writer.WriteLine();
                }
            }
        }

        public static int Task7_3(string path)
        {
            string[] lines = File.ReadAllLines(path);
            int min = int.MaxValue;

            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string part in parts)
                {
                    if (int.TryParse(part, out int val))
                    {
                        if (val < min)
                            min = val;
                    }
                }
            }
            return min;
        }
        //ЗАДАНИЕ 8
        public static void FillTextFile8(string path)
        {
            Console.WriteLine("Введите текст (для окончания ввода введите пустую строку):");
            using (StreamWriter writer = new StreamWriter(path))
            {
                while (true)
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }
                    writer.WriteLine(line);
                }
            }
        }
        public static void Task8_3(string inputPath, string outputPath, char symbol)
        {
            string[] lines = File.ReadAllLines(inputPath);

            using (StreamWriter writer = new StreamWriter(outputPath))
            {
                foreach (string line in lines)
                {
                    if (line.Length > 0 && line[0] == symbol)
                    {
                        writer.WriteLine(line);
                    }
                }
            }
        }
    }
}

