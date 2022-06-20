using DeepLome.DTO.ApiModels;
using DeepLome.Models.Interfaces;
using DeepLome.Services.Interfaces;
using DeepLome.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _eventService;

        public EventController(IUnitOfWork unitOfWork, IEventService eventService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
        }

        [HttpPost("try_in_photo")]
        public IActionResult TryInPhoto([FromBody] byte[] photoInBase64)
        {
            if (photoInBase64.Length == 0)
                return BadRequest("Photo is null");

            var client = new HttpClient();
            var body = new StringContent(photoInBase64.ToString());
            client.BaseAddress = new Uri("http://localhost");
            var response = client.PostAsync("/photo_validation", body);
            if (!response.IsCompletedSuccessfully) 
                return BadRequest(response.Result.ToString());

            ImageService.SaveImage(photoInBase64);
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAllEvents()
        {
            return Ok(_unitOfWork.Event.GetAll());
        }

        [HttpGet("event")]
        public IActionResult GetEventById(int id)
        {
            var foundEvent = _unitOfWork.Event.GetById(id);
            if (foundEvent == null)
                return BadRequest();
            return Ok(foundEvent);
        }

        [HttpPost("new_event")]
        public IActionResult RegisterNewEvent(EventDto newEvent)
        {
            var userEvent = _eventService.ConvertToEvent(newEvent);
            _unitOfWork.Event.Add(userEvent);
            return Ok();
        }
    }
}