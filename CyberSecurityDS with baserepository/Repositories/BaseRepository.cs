using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories.Contracts;

/**
 * additional base class here is not needed on exam
 */
namespace CyberSecurityDS.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly Dictionary<string, T> _models;

        public IReadOnlyCollection<T> Models { get; }

        protected BaseRepository()
        {
            this._models = new Dictionary<string, T>();
            Models = this._models.Values;
        }


        public void AddNew(T model)
        {
            string uniqueKey = this.ExtractUniqueKey(model);
            this._models[uniqueKey] = model;
        }

        public T? GetByName(string name)
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
            return this._models.ContainsKey(name);
        }

        protected abstract string ExtractUniqueKey(T model);
    }
}
