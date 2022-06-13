using System;
using System.Collections.Generic;

namespace DeepLome.WebApi.DatabaseModles
{
    public partial class UsersAtEvent
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? UserId { get; set; }

        public virtual Event? Event { get; set; }
    }
}
