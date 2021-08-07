using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SKS_Client.Base;
using MCC52_SKS_Client.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SKS_Client.Controllers
{
    public class AccountController : BaseController<Employee, EmployeeRepository, string>
    {
        private readonly EmployeeRepository repository;
        public AccountController(EmployeeRepository repository) : base(repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> ViewRegistered()
        {
            var result = await repository.ViewRegistered();
            return Json(result);
        }
    }
}
