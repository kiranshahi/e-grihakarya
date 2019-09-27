using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egrihakarya
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassroomContext _context;

        public ClassController(ClassroomContext context)
        {
            _context = context;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassView>>> GetClasses(string Role, int UserId)
        {
            return await _context.ClassViews.FromSqlRaw($"EXECUTE [dbo].[GetAllClass] @Role = {Role}, @Id = {UserId}").ToListAsync();
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Classes>> GetClassDetail(int id)
        {
            var classDetail = await _context.Classes.FromSqlRaw($"EXECUTE [dbo].[GetClassByID] @ClassID = {id}").FirstAsync();
            if (classDetail == null)
            {
                return NotFound();
            }
            return classDetail;
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, Classes classDetail)
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
        public int PostClassDetail(Classes classDetail)
        {
            return _context.Database.ExecuteSqlRaw($"[dbo].[AddClass] @ClassName = {classDetail.ClassName}, @Section = { classDetail.Section }, @Subject = {classDetail.Subject}, @Room = {classDetail.Room}, @AddedBy={classDetail.AddedBy}");
        }

        // DELETE: api/Class/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Classes>> DeleteClassDetail(int id)
        {
            var classDetail = await _context.Classes.FindAsync(id);
            if (classDetail == null)
            {
                return NotFound();
            }
            _context.Classes.Remove(classDetail);
            await _context.SaveChangesAsync();
            return classDetail;
        }

        private bool ClassDetailExists(int id)
        {
            return _context.Classes.Any(e => e.Id == id);
        }
    }
}
