using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IAccountRepository
    {
        IEnumerable<Account> Get();
        Account Get(string employeeId);
        int Insert(Account account);
        int Update(Account account, string employeeId);
        int Delete(string employeeId);
    }
}
