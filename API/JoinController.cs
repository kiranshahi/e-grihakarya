using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CAS
{
    [Route("api/[controller]")]
    [ApiController]
    public class JoinController : ControllerBase
    {
        private readonly CASContext _context;
        public JoinController(CASContext context)
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
