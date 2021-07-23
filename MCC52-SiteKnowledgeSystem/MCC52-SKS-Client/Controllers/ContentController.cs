using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SKS_Client.Models;
using MCC52_SKS_Client.Repository.Data;
using MCC52_SKS_Client.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MCC52_SKS_Client.Controllers
{
    public class ContentController : Controller
    {
        private readonly ContentRepository repository;

        public ContentController(ContentRepository repository)
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
        [HttpGet("Content/viewcontent")]
        public async Task<JsonResult> ViewContent()
        {
            var result = await repository.ViewContent();
            return Json(result);
        }
        public async Task<IActionResult> Detail(int contentId)
        {
            GetContentVM result = await repository.ViewDetail(contentId);
            
            return View(result);
        }
        
        public async Task<string> InsertContent(Content content)
        {
            content.EmployeeId = HttpContext.Session.GetString("employeeId");
            var result = await repository.InsertContent(content);
            return result;
        }

    }
}
