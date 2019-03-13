using Microsoft.AspNetCore.Mvc;

namespace Classroom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        //// GET: api/Class
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
        //{
        //    return await _context.Class.ToListAsync();
        //}

        //// GET: api/Class/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Class>> GetClassDetail(int id)
        //{
        //    var classDetail = await _context.Class.FindAsync(id);
        //    if (classDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    return classDetail;
        //}

        //// PUT: api/Class/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutClass(int id, Class classDetail)
        //{
        //    if (id != classDetail.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(classDetail).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClassDetailExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Class
        //[HttpPost]
        //public async Task<ActionResult<Class>> PostClassDetail(Class classDetail)
        //{
        //    _context.Class.Add(classDetail);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetClassDetail", new { id = classDetail.Id }, classDetail);
        //}

        //// DELETE: api/Class/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Class>> DeleteClassDetail(int id)
        //{
        //    var classDetail = await _context.Class.FindAsync(id);
        //    if (classDetail == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Class.Remove(classDetail);
        //    await _context.SaveChangesAsync();
        //    return classDetail;
        //}

        //private bool ClassDetailExists(int id)
        //{
        //    return _context.Class.Any(e => e.Id == id);
        //}
    }
}
