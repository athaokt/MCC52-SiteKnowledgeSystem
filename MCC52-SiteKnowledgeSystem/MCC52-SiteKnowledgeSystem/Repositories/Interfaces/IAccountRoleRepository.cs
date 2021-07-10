using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IAccountRoleRepository
    {
        IEnumerable<AccountRole> Get();
        AccountRole Get(string employeeId);
        int Insert(AccountRole accountRole);
        int Update(AccountRole accountRole, string employeeId);
        int Delete(string employeeId);
    }
}
