using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Classroom.Models
{
    public class ClassDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string SubjectName { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string SubjectCode { get; set; }
        [Required]
        public DateTime AddedOn { get; set; } = DateTime.Now;
    }
}
