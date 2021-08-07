using MCC52_SiteKnowledgeSystem.Bases;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.Repositories.Data;
using MCC52_SiteKnowledgeSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Controllers
{/*
    [Authorize]*/
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    public class EmployeesController : BaseController<Employee, EmployeeRepository, string>
    {
        private EmployeeRepository employeeRepository;
        public EmployeesController(EmployeeRepository employeeRepository) : base(employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVm)
        {
            var insert = employeeRepository.Register(registerVm);
            if (insert == 2)
            {
                return Ok(new { status = HttpStatusCode.OK, result = insert, message = "Success" });
            }
            else if (insert == 1)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = insert, message = "Email tidak boleh sama" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = insert, message = "NIK tidak boleh sama" });
            }
        }


    }
}
