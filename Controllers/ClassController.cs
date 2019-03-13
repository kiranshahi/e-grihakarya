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

        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> GetClassDetails()
        {
            return await _context.ClassDetails.ToListAsync();
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> GetClassDetail(int id)
        {
            var classDetail = await _context.ClassDetails.FindAsync(id);

            if (classDetail == null)
            {
                return NotFound();
            }

            return classDetail;
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClassDetail(int id, Class classDetail)
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

        // POST: api/Class
        [HttpPost]
        public async Task<ActionResult<Class>> PostClassDetail(Class classDetail)
        {
            _context.ClassDetails.Add(classDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassDetail", new { id = classDetail.Id }, classDetail);
        }

        // DELETE: api/Class/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Class>> DeleteClassDetail(int id)
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
