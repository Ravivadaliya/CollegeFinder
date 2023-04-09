using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
