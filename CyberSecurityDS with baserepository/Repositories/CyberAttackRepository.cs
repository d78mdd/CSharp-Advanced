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
    public class CyberAttackRepository : BaseRepository<ICyberAttack>
    {
        protected override string ExtractUniqueKey(ICyberAttack model)
            => model.AttackName;
    }
}
