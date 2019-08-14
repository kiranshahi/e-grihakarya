using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CAS
{
    [NotMapped]
    public class ClassView
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }
        public string Teacher { get; set; }
    }
}
