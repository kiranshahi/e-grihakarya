using System;
using System.Collections.Generic;

namespace egrihakarya
{
    public partial class UserClasses
    {
        public int UserClassId { get; set; }
        public int UserId { get; set; }
        public int ClassId { get; set; }
        public ICollection<Classes> Uclass { get; set; }
        public Users User { get; set; }
    }
}
