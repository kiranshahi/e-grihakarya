using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Classroom.Models;

namespace Classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassDetailsController : ControllerBase
    {
        private readonly ClassroomDbContext _context;

        public ClassDetailsController(ClassroomDbContext context)
        {
            _context = context;
        }

        // GET: api/ClassDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassDetail>>> GetClassDetails()
        {
            return await _context.ClassDetails.ToListAsync();
        }

        // GET: api/ClassDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassDetail>> GetClassDetail(int id)
        {
            var classDetail = await _context.ClassDetails.FindAsync(id);

            if (classDetail == null)
            {
                return NotFound();
            }

            return classDetail;
        }

        // PUT: api/ClassDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassDetail(int id, ClassDetail classDetail)
        {
            if (id != classDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(classDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassDetailExists(id))
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

        // POST: api/ClassDetails
        [HttpPost]
        public async Task<ActionResult<ClassDetail>> PostClassDetail(ClassDetail classDetail)
        {
            _context.ClassDetails.Add(classDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassDetail", new { id = classDetail.Id }, classDetail);
        }

        // DELETE: api/ClassDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassDetail>> DeleteClassDetail(int id)
        {
            var classDetail = await _context.ClassDetails.FindAsync(id);
            if (classDetail == null)
            {
                return NotFound();
            }

            _context.ClassDetails.Remove(classDetail);
            await _context.SaveChangesAsync();

            return classDetail;
        }

        private bool ClassDetailExists(int id)
        {
            return _context.ClassDetails.Any(e => e.Id == id);
        }
    }
}
