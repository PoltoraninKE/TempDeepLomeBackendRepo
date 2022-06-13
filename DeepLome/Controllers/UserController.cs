using DeepLome.Models.DatabaseModles;
using DeepLome.Models.Interfaces;
using DeepLome.Services.Interfaces;
using DeepLome.Services.Services;
using DTO.ApiModels;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IUserService _userService;

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
            var a1 = _unitOfWork.Users.GetAll();

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

            var a2 = _unitOfWork.Users.GetAll();
            
            var errorsList = _userService.RegisterUser(prepUser);
            if(errorsList.Count > 0)
                return BadRequest(errorsList);
            _unitOfWork.Users.Add(prepUser);
            return Ok("User has been registered");
        }
    }
}
