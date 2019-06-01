using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CAS.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CASContext _context;
        public CommentController(CASContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Comments>>> GetComments(int id)
        {
            return await _context.Comments.FromSql($"EXECUTE dbo.GetComment @AssignmentID = {id}").ToListAsync();
        }
        [HttpPost]
        public int AddComment(Comments commnet)
        {
            return _context.Database.ExecuteSqlCommand($"dbo.AddComment @UserId = {commnet.UserID}, @AssignmentID = {commnet.AssignmentID}, @Comment = {commnet.Comment}");
        }
    }
}