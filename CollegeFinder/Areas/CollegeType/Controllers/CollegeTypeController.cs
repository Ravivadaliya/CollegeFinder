using Microsoft.AspNetCore.Mvc;
using CollegeFinder.BAL;
namespace CollegeFinder.Areas.CollegeType.Controllers
{
    [CheckAccess]
    [Area("CollegeType")]
    [Route("CollegeType/[controller]/[action]")]
    public class CollegeTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
