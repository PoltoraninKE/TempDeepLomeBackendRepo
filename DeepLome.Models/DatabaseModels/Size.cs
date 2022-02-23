using System;
using System.Collections.Generic;

namespace DeepLome.Models.DatabaseModels
{
    public partial class Size
    {
        public Size()
        {
            Trashes = new HashSet<Trash>();
        }

        public long Id { get; set; }
        public string? SizeName { get; set; }

        public virtual ICollection<Trash> Trashes { get; set; }
    }
}
