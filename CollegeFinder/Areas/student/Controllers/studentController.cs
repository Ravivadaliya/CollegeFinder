using CollegeFinder.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Data;
using CollegeFinder.Areas.student;
using CollegeFinder.BAL;

namespace CollegeFinder.Areas.student.Controllers
{
    [CheckAccess]
    [Area("student")]
    [Route("student/[controller]/[action]")]
    public class studentController : Controller
    {
        private IConfiguration Configuration;


        public studentController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();
            DataTable dt = dalLOC.Student_SelectAll(connectionstr);
            return View("Index", dt);
        }

        public IActionResult Delete(int? studentid)
        {
            string connectionstr = Configuration.GetConnectionString("myConnectionStrings");
            AllData dalLOC = new AllData();

            if (Convert.ToBoolean(dalLOC.studentdelete(connectionstr, studentid)))
                TempData["AlertMsg"] = "Record Delete Successfully";

            return RedirectToAction("Index");

        }

        public IActionResult studentAddEdit()
        {
            return View();
        }
    }
}
