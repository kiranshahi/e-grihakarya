using System;

namespace egrihakarya
{
    public partial class Classes
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string Subject { get; set; }
        public string Room { get; set; }
        public DateTime AddedOn { get; set; }
        public int? AddedBy { get; set; }
        public string SubjectCode { get; set; }
    }
}