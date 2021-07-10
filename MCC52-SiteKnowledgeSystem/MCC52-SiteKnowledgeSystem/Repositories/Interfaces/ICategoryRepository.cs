using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface ICategoryRepository
    {
        IEnumerable<Category> Get();
        Category Get(string categoryId);
        int Insert(Category category);
        int Update(Category category, string categoryId);
        int Delete(string categoryId);
    }
}
