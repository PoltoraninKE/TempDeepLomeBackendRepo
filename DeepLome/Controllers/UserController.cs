using DeepLome.DTO.ApiModels;
using DeepLome.Models.DatabaseModels;
using DeepLome.Models.Interfaces;
using DeepLome.Services.Interfaces;
using DeepLome.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IUserService _userService;

        public UserController(IUnitOfWork unitOfWork, IUserService userService) 
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpGet("user")]
        public IActionResult GetUserById(int id) 
        {
            var user = _unitOfWork.Users.GetById(id);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserDTO user) 
        {
            var a1 = _unitOfWork.Users.GetAll();

            var prepUser = new User
            {
                UserTelegramId = user.UserTelegramId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                UserName = user.UserName,
                UserPhoto =  string.IsNullOrEmpty(user.UserPhoto) ?
                    null :
                    ImageService.FromBase64StringToBytes(user.UserPhoto)
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
