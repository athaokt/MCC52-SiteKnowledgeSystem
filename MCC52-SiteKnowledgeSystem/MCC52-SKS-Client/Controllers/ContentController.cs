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

        public IActionResult Detail(int contentId)
        {
            var result = repository.ViewContent(contentId);
            
            return View();
        }
        [HttpGet("Content/viewcontent")]
        public async Task<JsonResult> ViewContent()
        {
            var result = await repository.ViewContent();
            return Json(result);
        }
        [HttpGet("Content/Viewcontent/{contentId}")]
        public async Task<JsonResult> ViewContent(int contentId)
        {
            var result = await repository.ViewContent(contentId);
            return Json(result);
        }

        public async Task<JsonResult> ViewDetail(int contentId)
        {
            var result = await repository.ViewDetail(contentId);
            return Json(result);
        }
    }
}
