using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
        }

        public int ButtonCapacity { get; set; }

        public List<Drink> Drinks { get; set; }

        public int GetCount { get { return Drinks.Count; } }


        public void AddDrink(Drink drink)
        {
            if (Drinks.Count < ButtonCapacity)
            {
                Drinks.Add(drink);
            }
        }

        public bool RemoveDrink(string name)
        {
            return Drinks.Remove(Drinks.Find(d => d.Name == name));
        }

        public Drink GetLongest()
        {
            return Drinks.OrderByDescending(d => d.Volume).First();
        }

        public Drink GetCheapest()
        {
            return Drinks.OrderBy(d => d.Price).First();
        }

        public string BuyDrink(string name)
        {
            return Drinks.First(d => d.Name == name).ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Drinks available:");

            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString();
        }
    }
}
