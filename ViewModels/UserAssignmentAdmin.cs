using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace egrihakarya
{
    [NotMapped]
    public class UserAssignmentAdmin
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AssignmentID { get; set; }
        public string Assignment { get; set; }
    }
}
