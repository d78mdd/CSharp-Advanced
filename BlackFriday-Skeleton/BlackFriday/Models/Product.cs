using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class Product : IProduct
    {
        public Product(string productName, double basePrice)
        {
            this.ProductName = productName;
            this.BasePrice = basePrice;
        }



        private string productName;
        public string ProductName
        {
            get { return productName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ProductNameRequired);
                }
                productName = value;
            }
        }
        
        private double basePrice;
        public double BasePrice
        {
            get { return basePrice; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.ProductPriceConstraints);
                }
                basePrice = value;
            }
        }

        private double blackFridayPrice;
        public virtual double BlackFridayPrice 
        {
            get { return blackFridayPrice; }
            protected set { blackFridayPrice = value; }
        }

        // initialized false by default
        private bool isSold; 
        public virtual bool IsSold
        {
            get { return isSold; }
        }


        public override string ToString()
        {
            return $"Product: {ProductName}, Price: {BasePrice:F2}, You Save: {(BasePrice - BlackFridayPrice):F2}";
        }

        public void ToggleStatus()
        {
            isSold = !isSold; // ? IsSold = !IsSold
        }

        public void UpdatePrice(double newPriceValue)
        {
            BasePrice = newPriceValue;
        }
    }
}
