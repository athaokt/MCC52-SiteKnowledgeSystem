using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IContentRepository
    {
        IEnumerable<Content> Get();
        Content Get(int contentId);
        int Insert(Content content);
        int Update(Content content, int contentId);
        int Delete(int contentId);
    }
}
