using System;
using System.Collections.Generic;

namespace DeepLome.Models
{
    public partial class Trash
    {
        public long Id { get; set; }
        public long? UserId { get; set; }
        public double? Longitute { get; set; }
        public double? Latitude { get; set; }
        public byte[]? Photo { get; set; }
        public long? SizeId { get; set; }

        public virtual Size? Size { get; set; }
        public virtual User? User { get; set; }
    }
}
