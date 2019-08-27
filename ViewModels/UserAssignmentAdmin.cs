using System.ComponentModel.DataAnnotations.Schema;

namespace egrihakarya
{
    [NotMapped]
    public class UserAssignmentAdmin
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AssignmentID { get; set; }
        public string Assignment { get; set; }
    }
}
