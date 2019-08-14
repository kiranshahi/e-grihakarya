using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace egrihakarya
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinController : ControllerBase
    {
        private readonly ClassroomContext _context;
        public JoinController(ClassroomContext context)
        {
            _context = context;
        }
        // POST: api/Join
        [HttpPost]
        public void Post(JoinClass joinClass)
        {
            _context.Database.ExecuteSqlCommand($"dbo.JoinClass @UserID = {joinClass.UserID}, @ClassID = { joinClass.ClassID }");
        }
    }
}
