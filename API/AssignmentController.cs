using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace egrihakarya
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly ClassroomContext _context;

        public AssignmentController(ClassroomContext context)
        {
            _context = context;
        }

        // GET: api/Assignment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assignments>>> GetAssignment(int classId)
        {
            return await _context.Assignments.FromSqlRaw($"EXECUTE [dbo].[GetAssignmentByClassID] @ClassId = {classId}").ToListAsync();
        }

        // GET: api/Assignment/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Assignments>> GetAssignmentDetail(int id)
        {
            var assignmentDetail = await _context.Assignments.FindAsync(id);
            if (assignmentDetail == null)
            {
                return NotFound();
            }
            return assignmentDetail;
        }

        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutAssignment(int id, Assignments assignmentDetails)
        {
            if (id != assignmentDetails.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignmentDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentDetailExists(id))
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

        // POST: api/Assignment
        [HttpPost]
        public int PostAssignmentDetail(Assignments assignmentDetail)
        {
            return _context.Database.ExecuteSqlRaw($"[dbo].[AddAssignment] @AssinmentID = {assignmentDetail.Id}, @title = {assignmentDetail.Title}, @instructions = {assignmentDetail.Instructions}, @attachment = {assignmentDetail.Attachment}, @duedate ={assignmentDetail.DueDate}, @classid ={assignmentDetail.ClassId}");
        }

        // DELETE: api/Assignment/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<Assignments>> DeleteAssignmentDetail(int id)
        {
            var assignmentDetail = await _context.Assignments.FindAsync(id);
            if (assignmentDetail == null)
            {
                return NotFound();
            }
            _context.Assignments.Remove(assignmentDetail);
            await _context.SaveChangesAsync();
            return assignmentDetail;
        }

        private bool AssignmentDetailExists(int id)
        {
            return _context.Assignments.Any(e => e.Id == id);
        }
    }
}