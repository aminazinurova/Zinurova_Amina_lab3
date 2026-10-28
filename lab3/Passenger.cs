using System;
namespace var3
{
    [Serializable]
    public struct Baggage
    {
        public string Name; 
        public double Weight;

        public Baggage(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public override string ToString()
        {
            return $"{Name} ({Weight} кг)";
        }
    }
    [Serializable]
    public class Passenger
    {
        public Baggage[] Items;
        public Passenger()
        {
            Items = new Baggage[0];
        }

        public Passenger(Baggage[] items)
        {
            Items = items;
        }

        public override string ToString()
        {
            string result = "Багаж: ";
            for (int i = 0; i < Items.Length; i++)
            {
                result += Items[i].ToString();
                if (i < Items.Length - 1) result += "; ";
            }
            return result;
        }
    }
}