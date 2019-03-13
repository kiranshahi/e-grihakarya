using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAS.Domain
{
    public class Class
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
