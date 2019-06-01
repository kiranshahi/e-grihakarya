using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAS
{
    public class Comments
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AssignmentID { get; set; }
        public string Comment { get; set; }
        [ForeignKey("UserID")]
        public User User { get; set; }
        [ForeignKey("AssignmentID")]
        public Assignment Assignment { get; set; }
    }
}
