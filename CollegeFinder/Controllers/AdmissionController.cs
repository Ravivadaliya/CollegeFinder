using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Controllers
{
    public class AdmissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
