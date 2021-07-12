using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public IConfiguration _configuration;
        private readonly MyContext myContext;
        public AccountRepository(IConfiguration config, MyContext myContext) : base(myContext)
        {
            this._configuration = config;
            this.myContext = myContext;
        }
        public IQueryable GetAll()
        {
            var employeeRecord = (from e in myContext.Employees
                                  join s in myContext.Sites on e.SiteId equals s.SiteId
                                  join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                                  join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                                  join r in myContext.Roles on ar.RoleId equals r.RoleId
                                  select new
                                  {
                                      e.EmployeeId,
                                      e.FullName,
                                      e.Email,
                                      a.Username,
                                      e.PhoneNumber,
                                      e.Gender,
                                      s.SiteName,
                                      r.RoleName
                                  });
            return employeeRecord;
        }

        public IQueryable GetAll(string employeeId)
        {


            var employeeRecord = (from e in myContext.Employees
                                  join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                                  join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                                  join r in myContext.Roles on ar.RoleId equals r.RoleId
                                  join s in myContext.Sites on e.SiteId equals s.SiteId
                                  where e.EmployeeId == $"{employeeId}"
                                  select new
                                  {
                                      e.EmployeeId,
                                      e.FullName,
                                      e.Email,
                                      a.Username,
                                      e.PhoneNumber,
                                      e.Gender,
                                      s.SiteName,
                                      r.RoleName
                                  });

            return employeeRecord;
        }

        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
    }
}
