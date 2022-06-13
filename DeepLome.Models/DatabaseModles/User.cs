namespace DeepLome.Models.DatabaseModles
{
    public partial class User
    {
        public User()
        {
            Events = new HashSet<Event>();
            UsersAtEvents = new HashSet<UsersAtEvent>();
        }
        public long Id { get; set; }
        public long UserTelegramId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Phone { get; set; }
        public byte[]? UserPhoto { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<UsersAtEvent> UsersAtEvents { get; set; }
    }
}
