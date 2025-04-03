using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Models
{
    public class Application : IApplication
    {
        private IRepository<IProduct> products;
        public IRepository<IProduct> Products => products;

        private IRepository<IUser> users;
        public IRepository<IUser> Users => users;

        public Application()
        {
            products = new ProductRepository();
            users = new UserRepository();
        }
    }
}
