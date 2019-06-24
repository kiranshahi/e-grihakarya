using System;
using System.Collections.Generic;

namespace egrihakarya
{
    public partial class Assignments
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
        public string Attachment { get; set; }
        public string DueDate { get; set; }
        public int? CasclassId { get; set; }
        public int ClassId { get; set; }
        public string AddedOn { get; set; }
    }
}
