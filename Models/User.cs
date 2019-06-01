using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CAS
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public List<UserClass> UserClass { get; set; }
        public List<Comments> Comments { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}