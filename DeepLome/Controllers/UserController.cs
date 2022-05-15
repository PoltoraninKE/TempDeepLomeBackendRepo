using DeepLome.Models.Interfaces;
using DeepLome.Services.Services;
using DeepLome.WebApi.Models;
using DTO.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public IUserService _userService;

        public UserController(IUnitOfWork unitOfWork, IUserService userService) 
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpGet("/get_by_id/{userId}")]
        public IActionResult GetUserById(int userId) 
        {
            var user = _unitOfWork.Users.GetById(userId);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpGet("/get_by_name/{name}")]
        public IActionResult GetUserByName(string name)
        {
            var user = _unitOfWork.Users.GetByName(name);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost("/register")]
        public IActionResult RegisterUser([FromBody] UserDTO user) 
        {
            var prepUser = new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                UserName = user.UserName,
                UserPhoto =  string.IsNullOrEmpty(user.UserPhoto) ?
                    null :
                    ImageService.FromBase64StringToBytes(user.UserPhoto),
                Events = user.Events,
            };
            
            var errorsList = _userService.RegisterUser(prepUser);
            if(errorsList.Count > 0)
                return BadRequest(errorsList);
            return Ok("User has been registered");
        }
    }
}
