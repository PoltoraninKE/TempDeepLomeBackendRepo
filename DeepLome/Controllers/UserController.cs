using DeepLome.Models.DatabaseModels;
using DeepLome.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    public class UserController : Controller
    {
        public UnitOfWork _unitOfWork;
        public UserService _userService;

        public UserController(UnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetUserById(int userId) 
        {
            var user = _unitOfWork.Users().GetById(userId);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpGet]
        public IActionResult GetUserByName(string name)
        {
            var user = _unitOfWork.Users().GetByName(name);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }

        [HttpPost]
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
