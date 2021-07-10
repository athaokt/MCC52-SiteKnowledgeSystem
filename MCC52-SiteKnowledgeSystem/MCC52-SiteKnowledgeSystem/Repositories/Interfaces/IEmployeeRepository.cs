using MCC52_SiteKnowledgeSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Interfaces
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();
        Employee Get(string employeeId);
        int Insert(Employee employee);
        int Update(Employee employee, string employeeId);
        int Delete(string employeeId);
    }
}
