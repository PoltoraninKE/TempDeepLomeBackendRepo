using DeepLome.DTO.ApiModels;
using DeepLome.Models.Interfaces;
using DeepLome.Services.Services;
using DeepLome.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IEventService _eventService;

        public EventController(IUnitOfWork unitOfWork, IEventService eventService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
        }

        [HttpPost("/try_in_photo")]
        public IActionResult TryInPhoto(string photoInBase64)
        {
            if (string.IsNullOrEmpty(photoInBase64))
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
            var userEvent = new Event
            {
                CreatorId = newEvent.CreatorId,
                EventName = newEvent.EventName,
                EventDescription = newEvent.EventDescription,
                StartDateTime = newEvent.StartDateTime,
                EndDateTime = newEvent.EndDateTime,
                Latitude = newEvent.Latitude,
                Longitude = newEvent.Longitude
            };
            _unitOfWork.Event.Add(userEvent);
            return Ok();
        }
    }
}