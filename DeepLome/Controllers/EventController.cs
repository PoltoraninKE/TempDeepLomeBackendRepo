using DeepLome.DTO.ApiModels;
using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces;
using DeepLome.Services.Interfaces;
using DeepLome.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _eventService;

        public EventController(IUnitOfWork unitOfWork, IEventService eventService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
        }

        [HttpPost("/try_in_photo")]
        public IActionResult TryInPhoto([FromBody] byte[] photoInBase64)
        {
            // Тут должно идти на нейросетку
            if (photoInBase64.Length == 0)
                return BadRequest("Photo is null");
            ImageService.SaveImage(photoInBase64);
            return Ok();
        }

        [HttpGet("/get_all")]
        public IActionResult GetAllEvents()
        {
            return Ok(_unitOfWork.Event.GetAll());
        }

        [HttpGet("/get_by_id")]
        public IActionResult GetEventById(int eventId)
        {
            var foundEvent = _unitOfWork.Event.GetById(eventId);
            if (foundEvent == null)
                return BadRequest();
            return Ok(foundEvent);
        }

        [HttpPost("/new_event")]
        public IActionResult RegisterNewEvent(EventDto newEvent)
        {

            var a = _eventService.ConvertToEvent(newEvent);

            var userEvent = new Event
            {
                UserTelegramId = newEvent.UserTelegramId,
                EventName = newEvent.EventName,
                EventDescription = newEvent.EventDescription,
                StartDateTime = newEvent.StartDateTime.HasValue 
                    ? BitConverter.GetBytes(newEvent.StartDateTime.Value.Ticks) 
                    : BitConverter.GetBytes(DateTime.Now.Ticks),
                EndDateTime = newEvent.EndDateTime.HasValue 
                    ? BitConverter.GetBytes(newEvent.EndDateTime.Value.Ticks) 
                    : BitConverter.GetBytes(_eventService.CalculateEndDate()),
                Latitude = newEvent.Latitude,
                Longitude = newEvent.Longitude,
            };

            _unitOfWork.Event.Add(userEvent);
            return Ok();
        }
    }
}