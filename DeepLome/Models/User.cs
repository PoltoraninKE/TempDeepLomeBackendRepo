using System;
using System.Collections.Generic;

namespace DeepLome.Models
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
            Trashes = new HashSet<Trash>();
        }

        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public byte[]? UserPhoto { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Trash> Trashes { get; set; }
    }
}
