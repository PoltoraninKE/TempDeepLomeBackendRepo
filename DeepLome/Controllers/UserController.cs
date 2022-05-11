using DeepLome.Models.Interfaces;
using DeepLome.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        public IUnitOfWork _unitOfWork;
        public IUserService _userService;

        public UserController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
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
        public IActionResult RegisterUser([FromBody] User user) 
        {
            if (user == null)
                return BadRequest("User is empty");
            var errorsList = _userService.RegisterUser(user);
            if(errorsList.Count > 0)
                return BadRequest(errorsList);
            return Ok("User has been registered");
        }
    }
}
