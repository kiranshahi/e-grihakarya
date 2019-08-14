using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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
