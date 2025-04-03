using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Repositories.Contracts;

namespace BlackFriday.Repositories
{
    public class UserRepository : IRepository<IUser>
    {
        private List<IUser> models;

        public UserRepository()
        {
            this.models = new List<IUser>();
        }

        public IReadOnlyCollection<IUser> Models => models.AsReadOnly();

        public void AddNew(IUser model)
        {
            models.Add(model);
        }

        public IUser GetByName(string name)
        {
            return models.FirstOrDefault(u => u.UserName == name);
        }

        public bool Exists(string name)
        {
            return models.Any(u => u.UserName == name);
        }
    }
}
