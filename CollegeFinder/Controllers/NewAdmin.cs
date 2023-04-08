using Microsoft.AspNetCore.Mvc;
using CollegeFinder.Areas.User.Models;

namespace CollegeFinder.Controllers
{
    [Area("User")]
    [Route("User/[controller]/[action]")]
    public class NewAdmin : Controller
    {

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
