using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface ISiteRepository
    {
        IEnumerable<Site> Get();
        Site Get(int siteId);
        int Insert(Site site);
        int Update(Site site, int siteId);
        int Delete(int siteId);
    }
}
