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
    public class UserAssignController : ControllerBase
    {
        private readonly CASContext _context;
        public UserAssignController(CASContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAssignment>>> GetUserAssign(int assignId)
        {
            return await _context.UserAssignments.FromSql($"EXECUTE dbo.GetUserAssignment @AssignmentID = {assignId}").ToListAsync();
        }
    }
}