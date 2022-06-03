﻿using System;
using System.Collections.Generic;

namespace DeepLome.WebApi.Models
{
    public partial class Event
    {
        public Event()
        {
            EventPhotos = new HashSet<EventPhoto>();
        }

        public long Id { get; set; }
        public long? CreatorId { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual User? Creator { get; set; }
        public virtual ICollection<EventPhoto> EventPhotos { get; set; }
    }
}
