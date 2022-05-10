using System;
using System.Collections.Generic;

namespace DeepLome.WebApi.Models
{
    public partial class Photo
    {
        public Photo()
        {
            EventPhotos = new HashSet<EventPhoto>();
        }

        public long Id { get; set; }
        public byte[]? Photo1 { get; set; }

        public virtual ICollection<EventPhoto> EventPhotos { get; set; }
    }
}
