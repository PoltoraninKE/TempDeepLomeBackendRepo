using DeepLome.Models.Interfaces;
using DeepLome.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public IEventService _eventService;

        public EventController(IUnitOfWork unitOfWork, IEventService eventService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
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
        public IActionResult RegisterNewEvent(Event new_event)
        {
            _unitOfWork.Event.Add(new_event);
            return Ok();
        }
    }
}