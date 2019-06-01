using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CAS
{
    public class Comments
    {
        [Key]
        public int ID { get; set; }
        public int UserId { get; set; }
        public int AssignmentID { get; set; }
        public string Comment { get; set; }
    }
}
