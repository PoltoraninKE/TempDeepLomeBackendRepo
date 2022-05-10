using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
