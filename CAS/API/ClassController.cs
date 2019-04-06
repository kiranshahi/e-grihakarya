using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAS
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly CASContext _context;

        public ClassController(CASContext context)
        {
            _context = context;
        }

        // GET: api/Class
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassView>>> GetClasses(string Role, int UserId)
        {
            return await _context.ClassesView.FromSql($"EXECUTE dbo.GetAllClass @Role = {Role}, @Id = {UserId}").ToListAsync();
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CASClass>> GetClassDetail(int id)
        {
            var classDetail = await _context.Classes.FindAsync(id);
            if (classDetail == null)
            {
                return NotFound();
            }
            return classDetail;
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass(int id, CASClass classDetail)
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
        public int PostClassDetail(CASClass classDetail)
        {
            return _context.Database.ExecuteSqlCommand($"dbo.AddClass @ClassName = {classDetail.ClassName}, @Section = { classDetail.Section }, @Subject = {classDetail.Subject}, @Room = {classDetail.Room}, @AddedBy={classDetail.AddedBy}");
            //return _context.Classes.FromSql(").ToString();
        }

        // DELETE: api/Class/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CASClass>> DeleteClassDetail(int id)
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
