using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAS
{
    public class CASClass
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string ClassName { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Section { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Subject { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Room { get; set; }
        public string SubjectCode { get; set; }
        public List<Assignment> Assignment { get; set; }
        [Required]
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public int AddedBy { get; set; }
    }
}
