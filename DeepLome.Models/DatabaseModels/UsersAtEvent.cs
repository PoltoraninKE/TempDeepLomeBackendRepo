using System;
using System.Collections.Generic;

namespace DeepLome.Models.DatabaseModels
{
    public partial class UsersAtEvent
    {
        public long? EventId { get; set; }
        public long? UserId { get; set; }

        public virtual Event? Event { get; set; }
        public virtual User? User { get; set; }
    }
}
