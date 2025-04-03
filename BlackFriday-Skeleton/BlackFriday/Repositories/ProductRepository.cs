using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories
{
    public class ProductRepository : IRepository<IProduct>
    {
        private List<IProduct> models;

        public ProductRepository()
        {
            this.models = new List<IProduct>();
        }

        public IReadOnlyCollection<IProduct> Models => models.AsReadOnly();

        public void AddNew(IProduct model)
        {
            models.Add(model);
        }

        public IProduct GetByName(string name)
        {
            return models.FirstOrDefault(p => p.ProductName == name);
        }

        public bool Exists(string name)
        {
            return models.Any(p => p.ProductName == name);
        }
    }
}
