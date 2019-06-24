using System;
using System.Collections.Generic;

namespace egrihakarya
{
    public partial class UserAssignments
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AssignmentId { get; set; }
        public string Assignment { get; set; }
        public bool? IsSubmitted { get; set; }
        public string SubmittedOn { get; set; }
    }
}
