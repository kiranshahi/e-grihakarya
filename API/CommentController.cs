using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace egrihakarya
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ClassroomContext _context;
        public CommentController(ClassroomContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CommentView>>> GetComments(int id)
        {
            return await _context.CommentViews.FromSql($"EXECUTE [dbo].[GetComment] @AssignmentID = {id}").ToListAsync();
        }
        [HttpPost]
        public int AddComment(Comment commnet)
        {
            return _context.Database.ExecuteSqlCommand($"[dbo].[AddComment] @UserId = {commnet.UserId}, @AssignmentID = {commnet.AssignmentId}, @Comment = {commnet.Comments}");
        }
    }
}