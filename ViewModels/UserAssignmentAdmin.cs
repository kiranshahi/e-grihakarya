using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAS
{
    [NotMapped]
    public class UserAssignmentAdmin
    {
        public int UserID { get; set; }
        public int AssignmentID { get; set; }
        public string Assignment { get; set; }
    }
}
