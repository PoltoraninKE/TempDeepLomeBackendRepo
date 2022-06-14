using DeepLome.Models.DatabaseModels;

namespace DeepLome.DTO.ApiModels
{
    public class EventDto
    {
        public EventDto()
        {
            EventPhotos = new HashSet<EventPhoto>();
        }
        
        public long? UserTelegramId { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public byte[] Photo { get; set; }

        public virtual User? Creator { get; set; }
        public virtual ICollection<EventPhoto> EventPhotos { get; set; }
    }
}
