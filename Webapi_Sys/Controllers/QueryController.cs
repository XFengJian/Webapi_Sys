using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webapi_Sys.Models;

namespace Webapi_Sys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly ResumeDBContext _context;

        public QueryController(ResumeDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IEnumerable<TbResume> Condition([FromBody] QueryResume resume)
        {
            var res = _context.TbResumes.ToList();
            //过滤
            if (resume.UserName != null)
            {
                res = res.Where(u => u.UserName.Contains(resume.UserName)).ToList();
            }

            if (resume.Tel != " ")
            {
                res = res.Where(u => u.Tel.Contains(resume.Tel)).ToList();
            }

            if (resume.Education != " ")
            {
                res = res.Where(u => u.Education == resume.Education).ToList();
            }

            if (resume.Sex != -1)
            {
                res = res.Where(u => u.Sex == resume.Sex).ToList();
            }

            if (resume.Minage != 0 && resume.Maxage != 0)
            {
                res = res.Where(u => u.Age >resume.Minage && u.Age <resume.Maxage).ToList();
            }
            return res;
        }
    }
}
