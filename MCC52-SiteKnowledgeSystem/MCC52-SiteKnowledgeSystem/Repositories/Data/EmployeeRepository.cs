using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext myContext;

        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public int Register(RegisterVM registerVM)
        {
            Employee employee = new Employee();
            Account account = new Account();
            AccountRole accountRole = new AccountRole();
            var cekNik = myContext.Employees.Find(registerVM.EmployeeId);
            if (cekNik == null)
            {
                var cekEmail = myContext.Employees.Where(e => e.Email == registerVM.Email).FirstOrDefault<Employee>();
                if (cekEmail == null)
                {
                    /*var getRandomSalt = BCrypt.Net.BCrypt.GenerateSalt(12);*/

                    employee.EmployeeId = registerVM.EmployeeId;
                    employee.FullName = registerVM.FullName;
                    employee.PhoneNumber = registerVM.PhoneNumber;
  
                    employee.Gender = (Employee.GenderType)registerVM.Gender;
                    employee.Email = registerVM.Email;
                    employee.SiteId = registerVM.SiteId;
                    myContext.Employees.Add(employee);
                    myContext.SaveChanges();

                    var password = BCrypt.Net.BCrypt.HashPassword(registerVM.Password, GetRandomSalt());

                    account.EmployeeId = employee.EmployeeId;
                    account.Username = registerVM.Username;
                    account.Password = registerVM.Password;
                    myContext.Accounts.Add(account);
                    myContext.SaveChanges();

                    accountRole.RoleId = 3;
                    accountRole.EmployeeId = registerVM.EmployeeId;
                    myContext.AccountRoles.Add(accountRole);
                    myContext.SaveChanges();

                    myContext.SaveChanges();

                    return 2;
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }
    }
}
