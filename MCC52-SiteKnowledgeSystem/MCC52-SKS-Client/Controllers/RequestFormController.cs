using MCC52_SKS_Client.Models;
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
    public class RequestFormController : Controller
    {
        private readonly RequestFormRepository repository;

        public RequestFormController(RequestFormRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("requestform/viewrequest")]
        public async Task<JsonResult> ViewRequest()
        {
            var result = await repository.ViewRequest();
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
