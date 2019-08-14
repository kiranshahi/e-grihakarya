using System.ComponentModel.DataAnnotations;

namespace CAS
{
    public class UserClass
    {
        [Key]
        public int UserClassID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int ClassID { get; set; }
        public CASClass Class { get; set; }
    }
}