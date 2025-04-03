using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Service : Product
    {
        public Service(string productName, double basePrice) : base(productName, basePrice)
        {
        }

        public override double BlackFridayPrice
        {
            get
            {
                return base.BasePrice * 0.8;
            }
        }
    }
}
