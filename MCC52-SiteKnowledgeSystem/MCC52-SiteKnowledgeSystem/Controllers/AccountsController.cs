using MCC52_SiteKnowledgeSystem.Bases;
using MCC52_SiteKnowledgeSystem.Context;
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
{
    
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
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
        public ActionResult GetAllData()
        {
            var get = accountRepository.GetAllData();

            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = get, message = "Failed" });
            }
        }
        [HttpGet("GetAllData/{employeeId}")]
        public ActionResult GetAllData(string employeeId)
        {
            var get = accountRepository.GetAllData(employeeId);

            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = get, message = "Failed" });
            }
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public ActionResult Login(LoginVM loginVM)
        {
            var login = accountRepository.Login(loginVM);

            if (login == 2)
            {
                var pos = Ok(new JWTokenVM { Status = HttpStatusCode.OK, Token = accountRepository.GenerateTokenLogin(loginVM), Message = "Berhasil Login" });
                return pos;
                //return Ok(new { status = HttpStatusCode.OK, result = login, message = "Berhasil Login" });
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
        [AllowAnonymous]
        [HttpPost("ResetPassword")]
        public ActionResult ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var reset = accountRepository.ResetPassword(resetPasswordVM);
            if (reset > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result = reset, message = "Email berhasil dikirim" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.OK, result = reset, message = "Gagal mengirim email" });
            }
        }
        [AllowAnonymous]
        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var reset = accountRepository.ChangePassword(changePasswordVM);
            if (reset > 0)
            {
                return Ok(new { status = HttpStatusCode.OK, result = reset, message = "Berhasil Ganti Password" });
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.OK, result = reset, message = "Gagal Ganti Password" });
            }
        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterVM registerVm)
        {
            var insert = accountRepository.Register(registerVm);
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
