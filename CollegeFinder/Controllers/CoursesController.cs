using Microsoft.AspNetCore.Mvc;

namespace CollegeFinder.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult AllCourses()
        {
            return View();
        }

        public IActionResult SingleCourse()
        {
            return View();
        }
    }
}
