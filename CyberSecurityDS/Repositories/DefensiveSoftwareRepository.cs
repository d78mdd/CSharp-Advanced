using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS.Repositories
{
    public class DefensiveSoftwareRepository : IRepository<IDefensiveSoftware>
    {
        private readonly Dictionary<string, IDefensiveSoftware> _models;

        public IReadOnlyCollection<IDefensiveSoftware> Models { get; }

        public DefensiveSoftwareRepository()
        {
            this._models = new Dictionary<string, IDefensiveSoftware>();
            Models = this._models.Values;
        }


        public void AddNew(IDefensiveSoftware model)
        {
            this._models[model.Name] = model;
        }

        public IDefensiveSoftware? GetByName(string name)
        {
            //ICyberAttack outValue;
            //this._models.TryGetValue(name, out outValue);
            //return outValue;


            if (!this.Exists(name))
                return null;

            return this._models[name];
        }

        public bool Exists(string name)
        {
            this._models.ContainsKey(name);
        }
    }
}
