using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IRequestFormRepository
    {
        IEnumerable<RequestForm> Get();
        RequestForm Get(int requestId);
        int Insert(RequestForm requestForm);
        int Update(RequestForm requestForm, int requestId);
        int Delete(int requestId);
    }
}
