using MCC52_SiteKnowledgeSystem.Bases;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {

        }
    }
}
