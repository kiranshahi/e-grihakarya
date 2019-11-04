namespace egrihakarya
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AssignmentId { get; set; }
        public string Comments { get; set; }
    }
}