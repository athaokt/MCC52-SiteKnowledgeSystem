using MCC52_SiteKnowledgeSystem.Bases;
using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.Repositories.Data;
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
    public class ContentsController : BaseController<Content, ContentRepository, int>
    {
        private ContentRepository contentRepository;
        private readonly MyContext myContext;
        public ContentsController(ContentRepository contentRepository, MyContext myContext) : base(contentRepository)
        {
            this.contentRepository = contentRepository;
            this.myContext = myContext;
        }
        [HttpGet("GetAllData")]
        public ActionResult GetAll()
        {
            var get = contentRepository.GetAll();

            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = get, message = "Failed" });
            }
        }

        [HttpGet("GetAllData/{contentId}")]
        public ActionResult GetAll(int contentId)
        {
            var get = contentRepository.GetAll(contentId);

            if (get != null)
            {
                return Ok(get);
            }
            else
            {
                return BadRequest(new { status = HttpStatusCode.BadRequest, result = get, message = "Failed" });
            }
        }
    }
}
