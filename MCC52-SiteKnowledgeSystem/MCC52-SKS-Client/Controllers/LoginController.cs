using MCC52_SiteKnowledgeSystem.ViewModel;
using MCC52_SKS_Client.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SKS_Client.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepository repository;

        public LoginController(LoginRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Auth(LoginVM login)
        {
            var jwToken = await repository.Auth(login);
            if (jwToken == null)
            {
                return RedirectToAction("index");
            }

            HttpContext.Session.SetString("JWToken", jwToken.Token);
            HttpContext.Session.SetString("fullName", repository.JwtName(jwToken.Token));
            HttpContext.Session.SetString("role", repository.JwtRole(jwToken.Token));
            HttpContext.Session.SetString("employeeId", repository.JwtEmployeeId(jwToken.Token));

            return RedirectToAction("Index", "Dashboard");
        }
    }
}
