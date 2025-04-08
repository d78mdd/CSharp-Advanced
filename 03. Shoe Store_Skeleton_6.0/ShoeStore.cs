using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name { get; set; }

        public int StorageCapacity { get; set; }

        public List<Shoe> Shoes { get; }

        public int Count { get { return Shoes.Count; } }

        public string AddShoe(Shoe shoe)
        {
            if (Count == StorageCapacity)
            {
                return "No more space in the storage room.";
            }
            else
            {
                Shoes.Add(shoe);

                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
        }

        public int RemoveShoes(string material)
        {
            int removedShoes = Shoes.RemoveAll(shoe => shoe.Material == material);

            return removedShoes;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> shoes = Shoes.FindAll(shoe => shoe.Type.Equals(type, StringComparison.CurrentCultureIgnoreCase));

            return shoes;
        }

        // return the first shoe, with the given size
        public Shoe GetShoeBySize(double size)
        {
            Shoe shoe = Shoes.Find(shoe => shoe.Size == size);

            return shoe;
        }

        public string StockList(double size, string type)
        {
            List<Shoe> shoes = 
                GetShoesByType(type)
                .FindAll(shoe => shoe.Size == size);

            if (shoes.Count == 0)
            {
                return "No matches found!";    
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (Shoe shoe in shoes)
                {
                    sb.AppendLine(shoe.ToString());
                }

                return sb.ToString().Trim();
            }

        }
    }
}
