using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CAS.Entitites
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Token { get; set; }
    }
}
