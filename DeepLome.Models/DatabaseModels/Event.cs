namespace DeepLome.Models.DatabaseModels
{
    public partial class Event
    {
        public Event()
        {
            EventPhotos = new HashSet<EventPhoto>();
            UsersAtEvents = new HashSet<UsersAtEvent>();
        }

        public long Id { get; set; }
        public long? UserTelegramId { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public byte[]? StartDateTime { get; set; }
        public byte[]? EndDateTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public virtual User? UserTelegram { get; set; }
        public virtual ICollection<EventPhoto> EventPhotos { get; set; }
        public virtual ICollection<UsersAtEvent> UsersAtEvents { get; set; }
    }
}
