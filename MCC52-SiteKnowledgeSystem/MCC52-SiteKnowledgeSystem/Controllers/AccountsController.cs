using MCC52_SiteKnowledgeSystem.Bases;
using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.Repositories.Data;
using MCC52_SiteKnowledgeSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : BaseController<Account, AccountRepository, string>
    {
        
        private AccountRepository accountRepository;
        private readonly MyContext myContext;
        public AccountsController(AccountRepository accountRepository, MyContext myContext) : base(accountRepository)
        {
            this.accountRepository = accountRepository;
            this.myContext = myContext;
        }
        [HttpGet("GetAllData")]
        public ActionResult GetAll()
        {
            var get = accountRepository.GetAll();

            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = get, message = "Failed" });
            }
        }
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = accountRepository.Login(loginVM);

            if (login == 2)
            {

                return Ok(new { status = HttpStatusCode.OK, result = login, message = "Berhasil Login" });
            }
            else if (login == 1)
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = login, message = "Password Salah" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = login, message = "Username / Password tidak sesuai yang ada di database" });
            }
        }
    }
}
