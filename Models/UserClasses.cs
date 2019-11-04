using System.ComponentModel.DataAnnotations;

namespace egrihakarya
{
    public partial class UserClasses
    {
        [Key]
        public int UserClassId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
    }
}