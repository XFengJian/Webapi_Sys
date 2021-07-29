using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Webapi_Sys.Models;

namespace Webapi_Sys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbResumesController : ControllerBase
    {
        private readonly ResumeDBContext _context;

        public TbResumesController(ResumeDBContext context)
        {
            _context = context;
        }

        #region api
        // GET: api/TbResumes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbResume>>> GetTbResumes()
        {
            return await _context.TbResumes.ToListAsync();
        }

        // GET: api/TbResumes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbResume>> GetTbResume(int id)
        {
            var tbResume = await _context.TbResumes.FindAsync(id);

            if (tbResume == null)
            {
                return NotFound();
            }

            return tbResume;
        }

        // PUT: api/TbResumes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbResume(int id, TbResume tbResume)
        {
            if (id != tbResume.ResumeId)
            {
                return BadRequest();
            }

            _context.Entry(tbResume).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbResumeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TbResumes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbResume>> PostTbResume(TbResume tbResume)
        {
            _context.TbResumes.Add(tbResume);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTbResume", new { id = tbResume.ResumeId }, tbResume);
        }

        // DELETE: api/TbResumes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbResume(int id)
        {
            var tbResume = await _context.TbResumes.FindAsync(id);
            if (tbResume == null)
            {
                return NotFound();
            }

            _context.TbResumes.Remove(tbResume);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbResumeExists(int id)
        {
            return _context.TbResumes.Any(e => e.ResumeId == id);
        }
        #endregion

    }
}
