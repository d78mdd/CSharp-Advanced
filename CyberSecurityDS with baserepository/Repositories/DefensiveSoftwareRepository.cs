using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyberSecurityDS.Models.Contracts;
using CyberSecurityDS.Repositories;

namespace CyberSecurityDS_with_baserepository.Repositories
{
    public class DefensiveSoftwareRepository : BaseRepository<IDefensiveSoftware>
    {
        protected override string ExtractUniqueKey(IDefensiveSoftware model)
            => model.Name;
    }
}
