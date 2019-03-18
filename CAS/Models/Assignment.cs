using System;
using System.ComponentModel.DataAnnotations;

namespace CAS
{
    public class Assignment
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Attachment { get; set; }
        public DateTime DueDate { get; set; }
    }
}
