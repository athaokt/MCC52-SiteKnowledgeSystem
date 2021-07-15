using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Data
{
    public class ContentRepository : GeneralRepository<MyContext, Content, int>
    {
        private readonly MyContext myContext;

        public ContentRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public IQueryable GetAll()
        {
            var contents = (from ca in myContext.Categories
                                  join c in myContext.Contents on ca.CategoryId equals c.CategoryId
                                  join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                                  select new
                                  {
                                      c.ContentId,
                                      ca.CategoryName,
                                      c.ContentTitle,
                                      e.FullName,
                                      c.ContentDate
                                  });
            return contents;
        }

        public IQueryable GetAll(int contentId)
        {
            var contents = (from ca in myContext.Categories
                                  join c in myContext.Contents on ca.CategoryId equals c.CategoryId
                                  join e in myContext.Employees on c.EmployeeId equals e.EmployeeId
                                  where c.ContentId == contentId
                                  select new
                                  {
                                      c.ContentId,
                                      ca.CategoryName,
                                      c.ContentTitle,
                                      e.FullName,
                                      c.ContentDate
                                  });
            return contents;
        }
    }
}
