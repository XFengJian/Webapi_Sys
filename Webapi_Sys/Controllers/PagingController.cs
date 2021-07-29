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
    public class PagingController : ControllerBase
    {
        private readonly ResumeDBContext _context;

        public PagingController(ResumeDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IEnumerable<TbResume> GetPaging(int pageindex, int size)
        {
            return _context.TbResumes.ToList().Skip((pageindex - 1) * size).Take(size);
        }
    }
}
