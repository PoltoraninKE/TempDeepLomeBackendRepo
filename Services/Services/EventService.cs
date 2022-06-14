using DeepLome.DTO.ApiModels;
using DeepLome.Models.DatabaseModels;
using DeepLome.Services.Interfaces;

namespace DeepLome.Services.Services
{
    public class EventService : IEventService
    {
        public Event ConvertToEvent(EventDto eventDto)
        {
            return new Event
            {
                UserTelegramId = eventDto.UserTelegramId,
                EventName = eventDto.EventName,
                EventDescription = eventDto.EventDescription,
                StartDateTime = eventDto.StartDateTime.HasValue ? BitConverter.GetBytes(eventDto.StartDateTime.Value.Ticks) : BitConverter.GetBytes(DateTime.Now.Ticks),
                EndDateTime = eventDto.EndDateTime.HasValue ? BitConverter.GetBytes(eventDto.EndDateTime.Value.Ticks) : BitConverter.GetBytes(CalculateEndDate()),
                Latitude = eventDto.Latitude,
                Longitude = eventDto.Longitude,
            };
        }

        public long CalculateEndDate()
        {
            return DateTime.Now.AddDays(3).Ticks;
        }
    }
}
