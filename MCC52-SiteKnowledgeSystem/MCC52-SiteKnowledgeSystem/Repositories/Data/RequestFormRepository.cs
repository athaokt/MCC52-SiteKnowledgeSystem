using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Data
{
    public class RequestFormRepository : GeneralRepository<MyContext, RequestForm, int>
    {
        public RequestFormRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
