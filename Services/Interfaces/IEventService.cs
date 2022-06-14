using DeepLome.DTO.ApiModels;
using DeepLome.Models.DatabaseModels;

namespace DeepLome.Services.Interfaces
{
    public interface IEventService
    {
        public Event ConvertToEvent(EventDto eventDto);

        public long CalculateEndDate();
    }
}
