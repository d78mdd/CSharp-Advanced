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
    public class CyberAttackRepository :IRepository<ICyberAttack>
    {
        private readonly Dictionary<string, ICyberAttack> _models;

        public IReadOnlyCollection<ICyberAttack> Models { get; }

        public CyberAttackRepository()
        {
            this._models = new Dictionary<string, ICyberAttack>();
            Models = this._models.Values;
        }


        public void AddNew(ICyberAttack model)
        {
            this._models[model.AttackName] = model;
        }

        public ICyberAttack? GetByName(string name)
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
