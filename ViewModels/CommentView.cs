using System.ComponentModel.DataAnnotations.Schema;

namespace egrihakarya
{
    [NotMapped]
    public class CommentView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}
