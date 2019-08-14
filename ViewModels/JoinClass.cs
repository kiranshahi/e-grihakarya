using System.ComponentModel.DataAnnotations.Schema;

namespace CAS
{
    [NotMapped]
    public class JoinClass
    {
        public int Id { get; set; }
        public int UserID { get; set; }
        public string ClassID { get; set; }
    }
}