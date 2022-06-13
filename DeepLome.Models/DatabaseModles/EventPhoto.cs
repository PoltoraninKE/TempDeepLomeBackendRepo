﻿namespace DeepLome.Models.DatabaseModles
{
    public partial class EventPhoto
    {
        public long Id { get; set; }
        public long? EventId { get; set; }
        public long? PhotoId { get; set; }

        public virtual Event? Event { get; set; }
        public virtual Photo? Photo { get; set; }
    }
}
