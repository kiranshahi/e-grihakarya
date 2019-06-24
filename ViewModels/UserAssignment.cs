namespace CAS
{
    public class UserAssignment
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int AssignmentID { get; set; }
        public string Assignment { get; set; }
        public bool IsSubmitted { get; set; }
        public string SubmittedOn { get; set; }
        public string Name { get; set; }
    }
}
