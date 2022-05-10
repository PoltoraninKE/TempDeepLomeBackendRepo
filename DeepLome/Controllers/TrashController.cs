using Microsoft.AspNetCore.Mvc;

namespace DeepLome.WebApi.Controllers
{
    public class TrashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
