using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS_with_baserepository.Repositories;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;
using CyberSecurityDS.Repositories.Contracts;

namespace CyberSecurityDS_with_baserepository.Models
{
    public class SystemManager : ISystemManager
    {
        public IRepository<ICyberAttack> CyberAttacks { get; }

        public IRepository<IDefensiveSoftware> DefensiveSoftwares { get; }

        public SystemManager()
        {
            this.CyberAttacks = new CyberAttackRepository();
            this.DefensiveSoftwares = new DefensiveSoftwareRepository();
        }
    }
}
