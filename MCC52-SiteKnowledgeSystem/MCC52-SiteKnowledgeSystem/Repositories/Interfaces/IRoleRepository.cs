using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IRoleRepository
    {
        IEnumerable<Role> Get();
        Role Get(int roleId);
        int Insert(Role role);
        int Update(Role role, int roleId);
        int Delete(int roleId);
    }
}
