using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Controllers
{
    public class Courses : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
