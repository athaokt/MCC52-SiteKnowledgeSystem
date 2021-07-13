using MCC52_SiteKnowledgeSystem.Bases;
using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.Repositories.Data;
using MCC52_SiteKnowledgeSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Controllers
{
    [Authorize]
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
    }
}
